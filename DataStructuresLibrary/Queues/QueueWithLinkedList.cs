using System;
namespace DataStructuresLibrary.Queues
{
    public class QueueWithLinkedList<T> : IQueue<T>
    {
        private readonly int _capacity;
        private int _size;
        private Node<T> _first;
        private Node<T> _last;

        /// <summary>
        /// Non bounded queue
        /// </summary>
        public QueueWithLinkedList()
        {
            _capacity = int.MaxValue;
            _size = 0;
        }

        /// <summary>
        /// Bounded queue
        /// </summary>
        /// <param name="capacity">Capacity.</param>
        public QueueWithLinkedList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _capacity = capacity;
            _size = 0;
        }

        public int GetCurrentSize()
        {
            return _size;
        }

        public int GetMaxCapacity()
        {
            return _capacity;
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
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _first.Data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }

            if (HasOneElement())
            {
                _last = null;
            }

            var result = _first.Data;
            _first = _first.Next;
            _size--;
            return result;
        }

        public void Enqueue(T newValue)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("The queue is full");
            }

            if (IsEmpty())
            {
                _last = new Node<T>(newValue);
                _first = _last;
            }
            else
            {
                _last.Next = new Node<T>(newValue);
                _last = _last.Next;
            }

            _size++;
        }

        private bool HasOneElement()
        {
            return _size == 1;
        }
    }
}
