using System;

namespace DataStructuresLibrary.Heaps
{
    public class MaxHeap<T> : AbstractHeap<T> where T : IComparable
    {
        protected override bool SiftDownComparator(int value)
            => value >= 0;

        protected override bool SiftUpComparator(int value)
            => value > 0;
    }
}
