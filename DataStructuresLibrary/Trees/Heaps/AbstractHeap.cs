using System;
using System.Runtime.CompilerServices;
using DataStructuresLibrary.Common;

namespace DataStructuresLibrary.Trees.Heaps
{
    public abstract class AbstractHeap<T> : IHeap<T> where T : IComparable
    {
        private const int DefaultSize = 2;
        private T[] _arr;

        public int Count { get; private set; }

        public AbstractHeap()
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
            if (Count != _arr.Length)
            {
                return;
            }

            var newArr = new T[Convert.ToInt32(Math.Min((long)_arr.Length * 2, int.MaxValue))];
            Array.Copy(_arr, newArr, Count);
            _arr = newArr;
        }

        private void ShrinkArray()
        {
            if (Count > _arr.Length / 3 || _arr.Length < DefaultSize * 2)
            {
                return;
            }

            var newArr = new T[Math.Max(_arr.Length / 2, DefaultSize)];
            Array.Copy(_arr, newArr, Count);
            _arr = newArr;
        }

        private void SiftDown() => SiftDown(SiftDownComparator);

        protected abstract bool SiftDownComparator(T value1, T value2);

        private void SiftDown(Func<T, T, bool> comparator)
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

                var child = right >= Count || comparator(_arr[left], _arr[right]) ? left : right;

                if (child >= Count || comparator(_arr[curr], _arr[child]))
                {
                    return;
                }

                _arr.Swap(curr, child);
                curr = child;
            }
        }

        private void SiftUp() => SiftUp(SiftUpComparator);

        protected abstract bool SiftUpComparator(T value1, T value2);

        private void SiftUp(Func<T, T, bool> comparator)
        {
            var curr = Count - 1;

            while (curr > 0)
            {
                var parent = GetParentIndex(curr);
                if (parent >= 0 && comparator(_arr[curr], _arr[parent]))
                {
                    _arr.Swap(curr, parent);
                }

                curr = parent;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetRightIndex(int index)
        {
            return (index + 1) * 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetLeftIndex(int index)
        {
            return index * 2 + 1;
        }
    }
}
