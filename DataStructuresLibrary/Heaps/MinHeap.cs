using System;

namespace DataStructuresLibrary.Heaps
{
    public class MinHeap<T> : AbstractHeap<T> where T : IComparable
    {
        protected override bool SiftDownComparator(T less, T greater)
            => less.CompareTo(greater) <= 0;

        protected override bool SiftUpComparator(T less, T greater)
            => less.CompareTo(greater) < 0;
    }
}
