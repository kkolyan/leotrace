using System;
using System.Collections.Generic;


namespace Leopotam.Ecs
{
    public enum ComponentUsageType
    {
        Check,
        Read,
        Write,
        Delete,
    }

    public readonly struct ComponentUsage : IEquatable<ComponentUsage>
    {
        public readonly Type system;
        public readonly Type component;
        public readonly ComponentUsageType usageType;

        public ComponentUsage(Type system, Type component, ComponentUsageType usageType)
        {
            this.system = system;
            this.component = component;
            this.usageType = usageType;
        }

        public bool Equals(ComponentUsage other)
        {
            return system == other.system && component == other.component && usageType == other.usageType;
        }

        public override bool Equals(object obj)
        {
            return obj is ComponentUsage other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (system != null ? system.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (component != null ? component.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)usageType;
                return hashCode;
            }
        }
    }
    
    public class EcsTrace
    {
        private Type _currentSystem;

        private HashSet<ComponentUsage> _usages = new HashSet<ComponentUsage>();

        private List<IComponentModTracker> _modTrackers = new List<IComponentModTracker>();

        public IEnumerable<ComponentUsage> GetComponentUsages()
        {
            return _usages;
        }

        public void Get<T>(EcsComponentPool<T> pool, int idx) where T : struct
        {
            _usages.Add(new ComponentUsage(_currentSystem, typeof(T), ComponentUsageType.Read));
            if (ComponentModTracker<T>.instance == null)
            {
                ComponentModTracker<T>.instance = new ComponentModTracker<T>(pool);
                _modTrackers.Add(ComponentModTracker<T>.instance);
            }

            ComponentModTracker<T>.instance.Track(idx);
        }

        public void GetRef<T>(EcsComponentPool<T> pool, int idx) where T : struct
        {
            Get(pool, idx);
        }

        public void Filter(Type[] includedTypes, Type[] excludedTypes)
        {
            foreach (Type type in includedTypes)
            {
                _usages.Add(new ComponentUsage(_currentSystem, type, ComponentUsageType.Check));
            }

            foreach (Type type in excludedTypes)
            {
                _usages.Add(new ComponentUsage(_currentSystem, type, ComponentUsageType.Check));
            }
        }

        public void Update<T>() where T : struct
        {
            _usages.Add(new ComponentUsage(_currentSystem, typeof(T), ComponentUsageType.Write));
        }

        public void Delete(Type componentType)
        {
            _usages.Add(new ComponentUsage(_currentSystem, componentType, ComponentUsageType.Delete));
        }

        public void Delete<T>()
        {
            _usages.Add(new ComponentUsage(_currentSystem, typeof(T), ComponentUsageType.Delete));
        }

        public void Has<T>() where T : struct
        {
            _usages.Add(new ComponentUsage(_currentSystem, typeof(T), ComponentUsageType.Check));
        }

        public void BeforeSystemInit(IEcsSystem system) { }

        public void AfterSystemsInit() { }

        public void BeforeSystemRun(IEcsRunSystem system)
        {
            if (_currentSystem != null)
            {
                foreach (IComponentModTracker tracker in _modTrackers)
                {
                    if (tracker.IsModified())
                    {
                        _usages.Add(new ComponentUsage(_currentSystem, tracker.ComponentType, ComponentUsageType.Write));
                    }

                    tracker.Clear();
                }
            }

            _currentSystem = system.GetType();
        }

        public void AfterSystemsRun()
        {
            _currentSystem = null;
        }
    }
    
    internal interface IComponentModTracker
    {
        bool IsModified();
        void Clear();
        void Track(int idx);
        Type ComponentType { get; }
    }

    internal class ComponentModTracker<T> : IComponentModTracker where T : struct
    {
        // that's intended
        // ReSharper disable once StaticMemberInGenericType
        public static IComponentModTracker instance;

        private EcsComponentPool<T> _pool;
        private EcsGrowList<int> _indices;
        private EcsGrowList<T> _prevValues;

        public ComponentModTracker(EcsComponentPool<T> pool)
        {
            _pool = pool;
            _indices = new EcsGrowList<int>(1024);
            _prevValues = new EcsGrowList<T>(1024);
        }

        public bool IsModified()
        {
            for (int i = 0; i < _indices.Count; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(_prevValues.Items[i], _pool.Items[_indices.Items[i]]))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            _indices.Count = 0;
            _prevValues.Count = 0;
        }

        public void Track(int idx)
        {
            _prevValues.Add(_pool.Items[idx]);
            _indices.Add(idx);
        }

        public Type ComponentType { get; } = typeof(T);
    }
}