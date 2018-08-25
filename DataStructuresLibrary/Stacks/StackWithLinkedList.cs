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

        public StackWithLinkedList()
        {
            _capacity = 100;
            _size = 0;
            current = null;
        }
        public StackWithLinkedList(int capacity)
        {
            _capacity = capacity;
            _size = 0;
            current = null;
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
            return current._data;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            T result = current._data;
            current = current._next;
            _size--;
            return result;
        }

        public void Push(T newValue)
        {
            if (IsFull()){
                throw new StackOverflowException();
            }
            Node<T> newNode = new Node<T>(newValue);
            newNode._next = current;
            current = newNode;
            _size++;
        }
    }
}
