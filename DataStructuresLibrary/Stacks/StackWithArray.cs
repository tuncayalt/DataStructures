using System;
namespace DataStructuresLibrary.Stacks
{
    public class StackWithArray<T> : IStack<T>
    {
        private readonly int _capacity;
        private readonly T[] _arr;
        private int _size;

        public StackWithArray(int capacity)
        {
            _capacity = capacity;
            _size = 0;
            _arr = new T[_capacity];
        }
        public StackWithArray()
        {
            _capacity = 100;
            _size = 0;
            _arr = new T[_capacity]; 
        }

        public int GetCapacity()
        {
            return _capacity;
        }

        public int GetCurrentSize()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public bool IsFull()
        {
            return _size == _capacity;
        }

        public T Peek()
        {
            if (IsEmpty()){
                throw new InvalidOperationException();
            }
            return _arr[_size - 1];
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            T result = _arr[_size - 1];
            _arr[--_size] = default(T);
            return result;
        }

        public void Push(T newValue)
        {
            if (IsFull()){
                throw new StackOverflowException();
            }
            _arr[_size] = newValue;
            _size++;
        }
    }
}
