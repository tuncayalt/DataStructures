﻿using System;
namespace DataStructuresLibrary.Queues
{
    public class QueueWithArray<T> : IQueue<T>
    {
        private int _capacity;
        private int _size;
        private T[] _arr;
        private readonly bool _bounded;

        /// <summary>
        /// Non bounded queue
        /// </summary>
        public QueueWithArray()
        {
            _capacity = 16;
            _size = 0;
            _arr = new T[_capacity];
            _bounded = false;
        }

        /// <summary>
        /// Bounded queue
        /// </summary>
        /// <param name="capacity">Capacity.</param>
        public QueueWithArray(int capacity)
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

        public int GetMaxCapacity()
        {
            return _bounded ? _capacity : int.MaxValue;
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
            return _size == GetMaxCapacity();
        }

        public T Peek()
        {
            if (IsEmpty()){
                throw new InvalidOperationException("The queue is empty");
            }
            return _arr[0];
        }
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }
            T result = _arr[0];
            
            for (int i = 1; i < _arr.Length; i++){
                _arr[i - 1] = _arr[i];
            }
            _size--;
            return result;
        }

        public void Enqueue(T newValue)
        {
            if (IsFull()){
                throw new InvalidOperationException("The queue is full");
            }
            if (_size == _capacity){
                long tempCap = _capacity * 2;
                _capacity = Convert.ToInt32(Math.Min(tempCap, int.MaxValue));
                Array.Resize(ref _arr, _capacity);
            }
            _arr[_size] = newValue;
            _size++;
        }
    }
}
