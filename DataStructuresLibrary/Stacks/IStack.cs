using System;
namespace DataStructuresLibrary.Stacks
{
    public interface IStack<T>
    {
        bool IsEmpty();
        bool IsFull();
        void Push(T newValue);
        T Peek();
        T Pop();
        int GetMaxCapacity();
        int GetCurrentSize();
    }
}
