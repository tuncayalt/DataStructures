using System;

namespace DataStructuresLibrary.Lists
{
    public class LinkedList<T> : IList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _size;

        public void Add(T newElement)
        {
            if (IsEmpty())
            {
                _tail = new Node<T>(newElement);
                _head = _tail;
            }
            else
            {
                var temp = new Node<T>(newElement)
                {
                    prev = _tail
                };
                _tail.next = temp;
                _tail = temp;
            }

            _size++;
        }

        public int Count()
        {
            return _size;
        }

        public bool Find(T element)
        {
            throw new System.NotImplementedException();
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException();
            }

            var curr = _head;
            for (var i = 0; i < index; i++)
            {
                curr = curr.next;
            }

            return curr.data;
        }

        public int GetMaxCapacity()
        {
            return int.MaxValue;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Remove(T element)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}
