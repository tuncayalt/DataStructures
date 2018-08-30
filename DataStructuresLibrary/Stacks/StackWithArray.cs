using System;
namespace DataStructuresLibrary.Stacks
{
    public class StackWithArray<T> : IStack<T>
    {
        private int _capacity;
        private T[] _arr;
        private int _size;
        private readonly bool _bounded;

        /// <summary>
        /// Bounded stack
        /// </summary>
        /// <param name="capacity">Capacity.</param>
        public StackWithArray(int capacity)
        {
            if (capacity <= 0){
                throw new ArgumentOutOfRangeException();
            }
                
            _capacity = capacity;
            _size = 0;
            _arr = new T[_capacity];
            _bounded = true;
        }

        /// <summary>
        /// Non bounded stack
        /// </summary>
        public StackWithArray()
        {
            _capacity = 16;
            _size = 0;
            _arr = new T[_capacity];
            _bounded = false;
        }

        public int GetMaxCapacity()
        {
            return _bounded ? _capacity : int.MaxValue;
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
            return _size == GetMaxCapacity();
        }

        public T Peek()
        {
            if (IsEmpty()){
                throw new InvalidOperationException("The stack is empty");
            }
            return _arr[_size - 1];
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T result = _arr[_size - 1];
            _arr[--_size] = default(T);
            return result;
        }

        public void Push(T newValue)
        {
            if (IsFull()){
                throw new InvalidOperationException("The stack is full");
            }
            if (_size >= _capacity){
                long tempCap = _capacity * 2;
                _capacity = Convert.ToInt32(Math.Min(tempCap, int.MaxValue));
                Array.Resize(ref _arr, _capacity);
            }
            _arr[_size] = newValue;
            _size++;
        }
    }
}
