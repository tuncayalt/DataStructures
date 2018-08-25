using System;
namespace DataStructuresLibrary.Queues
{
    public class QueueWithLinkedList<T> : IQueue<T>
    {
        private int _capacity;
        private int _size;
        private Node<T> first;
        private Node<T> last;

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

        class Node<U>
        {
            internal U data;
            internal Node<U> next;

            public Node(U newValue)
            {
                data = newValue;
            }
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
            return first.data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }
            if (HasOneElement())
            {
                last = null;
            }
            T result = first.data;
            first = first.next;
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
                last = new Node<T>(newValue);
                first = last;
            }
            else
            {
                last.next = new Node<T>(newValue);
                last = last.next;
            }
            _size++;
        }

        private bool HasOneElement()
        {
            return _size == 1;
        }
    }
}
