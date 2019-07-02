using System;
using System.Collections.Generic;

namespace DataStructuresLibrary.Lists
{
    public interface IList<T> : IEnumerable<T>
    {
        bool IsEmpty();
        int GetMaxCapacity();
        int Count();
        void Add(T newElement);
        void AddFirst(T newElement);
        void Remove(T element);
        void RemoveAt(int index);
        T Get(int index);
        bool Find(T element);
        int FindFirstIndex(T element);
        int FindFirstIndex(Predicate<T> predicate);
    }
}
