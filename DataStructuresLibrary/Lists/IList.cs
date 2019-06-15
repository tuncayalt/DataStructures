using System;
namespace DataStructuresLibrary.Lists
{
    public interface IList<T>
    {
        bool IsEmpty();
        int GetMaxCapacity();
        int Count();
        void Add(T newElement);
        void Remove(T element);
        void RemoveAt(int index);
        T Get(int index);
        bool Find(T element);
    }
}
