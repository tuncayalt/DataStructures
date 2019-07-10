using System;
namespace DataStructuresLibrary.Stacks
{
    public class StackWithLinkedList<T> : IStack<T>
    {
        private readonly int _capacity;
        private int _size;
        private Node<T> _current;

        /// <summary>
        /// Non bounded stack
        /// </summary>
        public StackWithLinkedList()
        {
            _capacity = int.MaxValue;
            _size = 0;
            _current = null;
        }

        /// <summary>
        /// Bounded stack
        /// </summary>
        /// <param name="capacity">Capacity.</param>
        public StackWithLinkedList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _capacity = capacity;
            _size = 0;
            _current = null;
        }

        public int GetMaxCapacity()
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
                throw new InvalidOperationException("The stack is empty");
            }

            return _current.Data;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty");
            }

            var result = _current.Data;
            _current = _current.Next;
            _size--;
            return result;
        }

        public void Push(T newValue)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("The stack is full");
            }

            var newNode = new Node<T>(newValue)
            {
                Next = _current
            };
            _current = newNode;
            _size++;
        }
    }
}
