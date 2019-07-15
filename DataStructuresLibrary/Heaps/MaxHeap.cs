using System;

namespace DataStructuresLibrary.Heaps
{
    public class MaxHeap<T> : AbstractHeap<T> where T : IComparable
    {
        protected override bool SiftDownComparator(T greater, T less)
            => greater.CompareTo(less) >= 0;

        protected override bool SiftUpComparator(T greater, T less)
            => greater.CompareTo(less) > 0;
    }
}
