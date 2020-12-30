namespace Leopotam.Ecs
{
    public struct Record
    {
        public EcsFilter _filter;

        public int idx;

        public Record(EcsFilter filter, int idx) : this()
        {
            _filter = filter;
            this.idx = idx;
        }

        public ref EcsEntity Get()
        {
            return ref _filter.Entities[idx];
        }
    }
    
    public struct Record<T1>
        where T1 : struct
    {
        public EcsFilter<T1> _filter1;

        public int idx;

        public Record(EcsFilter<T1> filter1, int idx): this()
        {
            _filter1 = filter1;
            this.idx = idx;
        }

        public ref T1 Get1()
        {
            return ref _filter1._pool1.Items[_filter1._get1[idx]];
        }
    }
    
    public struct Record<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        
        public EcsFilter<T1, T2> _filter2;

        public int idx;

        public Record(EcsFilter<T1, T2> filter2, int idx): this()
        {
            _filter2 = filter2;
            this.idx = idx;
        }

        public ref T1 Get1()
        {
            return ref _filter2._pool1.Items[_filter2._get1[idx]];
        }

        public ref T2 Get2()
        {
            return ref _filter2._pool2.Items[_filter2._get2[idx]];
        }
    }
    
    public struct Record<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        
        public EcsFilter<T1, T2, T3> _filter3;

        public int idx;

        public Record(EcsFilter<T1, T2, T3> filter3, int idx): this()
        {
            _filter3 = filter3;
            this.idx = idx;
        }

        public ref T1 Get1()
        {
            return ref _filter3._pool1.Items[_filter3._get1[idx]];
        }

        public ref T2 Get2()
        {
            return ref _filter3._pool2.Items[_filter3._get2[idx]];
        }

        public ref T3 Get3()
        {
            return ref _filter3._pool3.Items[_filter3._get3[idx]];
        }
    }
}