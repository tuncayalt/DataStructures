using System;
namespace DataStructuresLibrary.Stacks
{
    public class StackWithLinkedList<T> : IStack<T>
    {
        private readonly int _capacity;
        private int _size;

        class Node<U>{
            internal U _data;
            internal Node<U> _next;

            public Node(U data)
            {
                _data = data;
            }
        }

        Node<T> current;

        /// <summary>
        /// Non bounded stack
        /// </summary>
        public StackWithLinkedList()
        {
            _capacity = int.MaxValue;
            _size = 0;
            current = null;
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
            current = null;
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
            return current._data;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T result = current._data;
            current = current._next;
            _size--;
            return result;
        }

        public void Push(T newValue)
        {
            if (IsFull()){
                throw new InvalidOperationException("The stack is full");
            }
            Node<T> newNode = new Node<T>(newValue);
            newNode._next = current;
            current = newNode;
            _size++;
        }
    }
}
