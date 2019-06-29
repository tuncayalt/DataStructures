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
                    prev = _tail
                };
                _tail.next = temp;
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
                    next = _head
                };
                _head.prev = temp;
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
                if (curr.data.Equals(element))
                {
                    return true;
                }
                curr = curr.next;
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
            var curr = _head;

            while (curr != null)
            {
                if (curr.data.Equals(element))
                {
                    RemoveNode(curr);
                }
                curr = curr.next;
            }
        }

        private void RemoveNode(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (node.prev == null && node.next == null)
            {
                _head = null;
                _tail = null;
            }
            else if (node.prev == null)
            {
                _head = node.next;
                node.next.prev = node.prev;
            }
            else if (node.next == null)
            {
                _tail = node.prev;
                node.prev.next = node.next;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
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
                curr = curr.prev;
            }

            RemoveNode(curr);
        }

        private void RemoveAtForward(int index)
        {
            var curr = _head;

            for (var i = 0; i < index; i++)
            {
                curr = curr.next;
            }

            RemoveNode(curr);
        }

        public int FindFirstIndex(T element)
        {
            var curr = _head;
            var index = 0;
            while (curr != null)
            {
                if (curr.data.Equals(element))
                {
                    return index;
                }
                curr = curr.next;
                index++;
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curr = _head;
            while (curr != null)
            {
                yield return curr.data;
                curr = curr.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int FindFirstIndex(Func<T, bool> predicate)
        {
            var curr = _head;
            var index = 0;
            while (curr != null)
            {
                if (predicate(curr.data))
                {
                    return index;
                }
                curr = curr.next;
                index++;
            }

            return -1;
        }
    }
}
