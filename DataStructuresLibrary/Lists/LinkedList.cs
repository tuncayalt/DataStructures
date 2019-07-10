using System;
using System.Collections;
using System.Collections.Generic;

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
                    Prev = _tail
                };
                _tail.Next = temp;
                _tail = temp;
            }

            _size++;
        }

        public void AddFirst(T newElement)
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
                    Next = _head
                };
                _head.Prev = temp;
                _head = temp;
            }

            _size++;
        }

        public int Count()
        {
            return _size;
        }

        public bool Find(T element)
        {
            var curr = _head;
            while(curr != null)
            {
                if (curr.Data.Equals(element))
                {
                    return true;
                }
                curr = curr.Next;
            }

            return false;
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
                curr = curr.Next;
            }

            return curr.Data;
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
            var curr = _head;

            while (curr != null)
            {
                if (curr.Data.Equals(element))
                {
                    RemoveNode(curr);
                }
                curr = curr.Next;
            }
        }

        private void RemoveNode(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (node.Prev == null && node.Next == null)
            {
                _head = null;
                _tail = null;
            }
            else if (node.Prev == null)
            {
                _head = node.Next;
                node.Next.Prev = node.Prev;
            }
            else if (node.Next == null)
            {
                _tail = node.Prev;
                node.Prev.Next = node.Next;
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }

            _size--;
            node = null;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            var forward = false;

            if (index <= _size / 2)
            {
                forward = true;
            }

            if (forward)
            {
                RemoveAtForward(index);
            }
            else
            {
                RemoveAtBackward(index);
            }
        }

        private void RemoveAtBackward(int index)
        {
            var curr = _tail;

            for (var i = _size - 1; i > index; i--)
            {
                curr = curr.Prev;
            }

            RemoveNode(curr);
        }

        private void RemoveAtForward(int index)
        {
            var curr = _head;

            for (var i = 0; i < index; i++)
            {
                curr = curr.Next;
            }

            RemoveNode(curr);
        }

        public int FindFirstIndex(T element)
        {
            var curr = _head;
            var index = 0;
            while (curr != null)
            {
                if (curr.Data.Equals(element))
                {
                    return index;
                }
                curr = curr.Next;
                index++;
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curr = _head;
            while (curr != null)
            {
                yield return curr.Data;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int FindFirstIndex(Predicate<T> predicate)
        {
            var curr = _head;
            var index = 0;
            while (curr != null)
            {
                if (predicate(curr.Data))
                {
                    return index;
                }
                curr = curr.Next;
                index++;
            }

            return -1;
        }
    }
}
