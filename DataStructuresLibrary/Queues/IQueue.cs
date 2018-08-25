using System;
namespace DataStructuresLibrary.Queues
{
    public interface IQueue<T>
    {
        int GetMaxCapacity();
        int GetCurrentSize();
        bool IsEmpty();
        bool IsFull();
        T Peek();
        T Dequeue();
        void Enqueue(T newValue);
    }
}
