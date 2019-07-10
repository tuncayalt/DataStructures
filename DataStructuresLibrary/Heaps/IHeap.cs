using System;

namespace DataStructuresLibrary.Heaps
{
    public interface IHeap<T> where T : IComparable
    {
        T GetFirst();
        T ExtractFirst();
        void Add(T value);
        int Count { get; }
    }
}
