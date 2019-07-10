using System;

namespace DataStructuresLibrary.Heaps
{
    public class MinHeap<T> : IHeap<T> where T : IComparable
    {
        private const int DefaultSize = 2;
        private T[] _arr;

        public int Count { get; private set; }

        public MinHeap()
        {
            _arr = new T[DefaultSize];
        }

        public T GetFirst()
        {
            if (_arr == null || Count <= 0)
            {
                throw new EmptyHeapException();
            }

            return _arr[0];
        }

        public T ExtractFirst()
        {
            if (_arr == null || Count <= 0)
            {
                throw new EmptyHeapException();
            }

            var returnVal = _arr[0];

            if (--Count == 0)
            {
                _arr[0] = default;
            }
            else
            {
                _arr[0] = _arr[Count];
                _arr[Count] = default;

                SiftDown();
            }

            ShrinkArray();

            return returnVal;
        }

        public void Add(T value)
        {
            ExpandArray();
            
            _arr[Count] = value;
            Count++;

            SiftUp();
        }

        private void ExpandArray()
        {
            if (Count == _arr.Length)
            {
                var newArr = new T[Convert.ToInt32(Math.Min((long)_arr.Length * 2, int.MaxValue))];
                Array.Copy(_arr, newArr, Count);
                _arr = newArr;
            }
        }

        private void ShrinkArray()
        {
            if (Count <= _arr.Length / 3 && _arr.Length >= DefaultSize * 2)
            {
                var newArr = new T[Math.Max(_arr.Length / 2, DefaultSize)];
                Array.Copy(_arr, newArr, Count);
                _arr = newArr;
            }
        }

        private void SiftDown()
        {
            var curr = 0;

            while (curr < Count)
            {
                var left = GetLeftIndex(curr);
                var right = GetRightIndex(curr);

                if (left >= Count)
                {
                    return;
                }

                var minChild = right >= Count || _arr[left].CompareTo(_arr[right]) <= 0 ? left : right;

                if (minChild >= Count || _arr[minChild].CompareTo(_arr[curr]) >= 0)
                {
                    return;
                }

                Swap(curr, minChild);
                curr = minChild;
            }
        }

        private void SiftUp()
        {
            var curr = Count - 1;

            while (curr > 0)
            {
                var parent = GetParentIndex(curr);
                if (parent >= 0 && _arr[curr].CompareTo(_arr[parent]) < 0)
                {
                    Swap(curr, parent);
                }

                curr = parent;
            }
        }

        private void Swap(int ind1, int ind2)
        {
            var temp = _arr[ind1];
            _arr[ind1] = _arr[ind2];
            _arr[ind2] = temp;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetRightIndex(int index)
        {
            return (index + 1) * 2;
        }

        private int GetLeftIndex(int index)
        {
            return index * 2 + 1;
        }
    }
}
