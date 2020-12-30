using System;
using System.Runtime.CompilerServices;

namespace Leopotam.Ecs
{
    public struct EcsFilterEnumerator : IDisposable
    {
        readonly EcsFilter _filter;
        readonly int _count;
        int _idx;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal EcsFilterEnumerator(EcsFilter filter)
        {
            _filter = filter;
            _count = _filter.GetEntitiesCount();
            _idx = -1;
            _filter.Lock();
        }

        public Record Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Record(_filter, _idx);
        }

#if ENABLE_IL2CPP
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            _filter.Unlock();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            return ++_idx < _count;
        }
    }
    
    public struct EcsFilterEnumerator<T> : IDisposable 
        where T : struct
    {
        readonly EcsFilter<T> _filter;
        readonly int _count;
        int _idx;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal EcsFilterEnumerator(EcsFilter<T> filter)
        {
            _filter = filter;
            _count = _filter.GetEntitiesCount();
            _idx = -1;
            _filter.Lock();
        }

        public Record<T> Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Record<T>(_filter, _idx);
        }

#if ENABLE_IL2CPP
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            _filter.Unlock();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            return ++_idx < _count;
        }
    }
    
    public struct EcsFilterEnumerator<T,T2> : IDisposable 
        where T : struct 
        where T2 : struct
    {
        readonly EcsFilter<T,T2> _filter;
        readonly int _count;
        int _idx;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal EcsFilterEnumerator(EcsFilter<T,T2> filter)
        {
            _filter = filter;
            _count = _filter.GetEntitiesCount();
            _idx = -1;
            _filter.Lock();
        }

        public Record<T,T2> Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Record<T,T2>(_filter, _idx);
        }

#if ENABLE_IL2CPP
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            _filter.Unlock();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            return ++_idx < _count;
        }
    }
    
    public struct EcsFilterEnumerator<T,T2,T3> : IDisposable 
        where T : struct 
        where T2 : struct
        where T3 : struct
    {
        readonly EcsFilter<T,T2,T3> _filter;
        readonly int _count;
        int _idx;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal EcsFilterEnumerator(EcsFilter<T,T2,T3> filter)
        {
            _filter = filter;
            _count = _filter.GetEntitiesCount();
            _idx = -1;
            _filter.Lock();
        }

        public Record<T,T2,T3> Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Record<T,T2,T3>(_filter, _idx);
        }

#if ENABLE_IL2CPP
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
            [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            _filter.Unlock();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            return ++_idx < _count;
        }
    }
}