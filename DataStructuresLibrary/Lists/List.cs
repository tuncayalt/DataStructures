using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary.Lists
{
    public class List<T> : IList<T>
    {
        private T[] _arr;
        private int _size;

        public List()
        {
            _size = 0;
            _arr = new T[16];
        }

        public List(int initialLength)
        {
            if (initialLength <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size = 0;
            _arr = new T[initialLength];
        }

        public void Add(T newElement)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("The list is full");
            }
            if (_size == _arr.Length)
            {
                long temp = _arr.Length * 2;
                var capacity = Convert.ToInt32(Math.Min(temp, int.MaxValue));
                Array.Resize(ref _arr, capacity);
            }
            _arr[_size] = newElement;
            _size++;
        }

        public void AddFirst(T newElement)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("The list is full");
            }
            if (_size == _arr.Length)
            {
                long temp = _arr.Length * 2;
                var capacity = Convert.ToInt32(Math.Min(temp, int.MaxValue));
                Array.Resize(ref _arr, capacity);
            }
            for (var i = _size - 1; i >= 0; i--)
            {
                _arr[i + 1] = _arr[i];
            }
            _arr[0] = newElement;
            _size++;
        }

        public int Count()
        {
            return _size;
        }

        public bool Find(T element)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _arr[index];
        }

        public int GetMaxCapacity()
        {
            return int.MaxValue;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        private bool IsFull()
        {
            return _size == GetMaxCapacity();
        }

        public void Remove(T element)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty");
            }

            var found = false;
            for (var i = 0; i < _size; i++)
            {
                if (_arr[i].Equals(element))
                {
                    found = true;
                    _size--;
                }
                if (found && i < _size)
                {
                    _arr[i] = _arr[i + 1];
                }
            }

            DecreaseArrayLength();
        }

        public void RemoveAt(int index)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty");
            }
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _size; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            _size--;

            DecreaseArrayLength();
        }

        private void DecreaseArrayLength()
        {
            if (_size * 4 < _arr.Length && _arr.Length > 16)
            {
                Array.Resize(ref _arr, Math.Max(16, _arr.Length / 2));
            }
        }

        public int FindFirstIndex(T element)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in _arr)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int FindFirstIndex(Predicate<T> predicate)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (predicate(_arr[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
