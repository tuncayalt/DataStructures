using System;
namespace DataStructuresLibrary.Lists
{
    public class List<T> : IList<T>
    {
        private T[] _arr;
        private readonly bool _bounded;
        private int _capacity;
        private int _size;

        public List()
        {
            _capacity = 16;
            _size = 0;
            _arr = new T[_capacity];
            _bounded = false;
        }

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _capacity = capacity;
            _size = 0;
            _arr = new T[_capacity];
            _bounded = true;
        }

        public void Add(T newElement)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("The list is full");
            }
            if (_size == _capacity)
            {
                long temp = _capacity * 2;
                _capacity = Convert.ToInt32(Math.Min(temp, int.MaxValue));
                Array.Resize(ref _arr, _capacity);
            }
            _arr[_size] = newElement;
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
            return _bounded ? _capacity : int.MaxValue;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public bool IsFull()
        {
            return _size == GetMaxCapacity();
        }

        public void Remove(T element)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty");
            }
            bool found = false;
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(element))
                {
                    found = true;
                    _size--;
                }
                if (found && i < _arr.Length - 1)
                {
                    _arr[i] = _arr[i + 1];
                }
            }
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
            for (int i = index; i < _arr.Length - 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            _size--;
        }
    }
}
