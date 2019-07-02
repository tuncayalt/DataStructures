using System;
using System.Collections.Generic;

namespace DataStructuresLibrary.HashTables
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private Lists.IList<(TKey key, TValue value)>[] _table;
        private const int DefaultSize = 16;
        private readonly int _tableSize;

        public HashTable(int tableSize)
        {
            _table = new Lists.LinkedList<(TKey key, TValue value)>[tableSize];
            _tableSize = tableSize;
        }

        public HashTable() : this(DefaultSize)
        {
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var linkedList = GetLinkedListByKey(key);

            var indexKey = linkedList.FindFirstIndex(tuple => tuple.key.Equals(key));

            if (indexKey >= 0)
            {
                linkedList.RemoveAt(indexKey);
            }

            linkedList.AddFirst((key, value));
        }

        private Lists.IList<(TKey key, TValue value)> GetLinkedListByKey(TKey key)
        {
            var index = GetHashCode(key) % _tableSize;
            var linkedList = _table[index];
            if (linkedList == null)
            {
                linkedList = new Lists.LinkedList<(TKey key, TValue value)>();
                _table[index] = linkedList;
            }
            return linkedList;
        }

        private int GetHashCode(TKey key)
        {
            return key.GetHashCode();
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var linkedList = GetLinkedListByKey(key);
            var index = linkedList.FindFirstIndex(tuple => tuple.key.Equals(key));
            if (index >= 0)
            {
                return true;
            }
            return false;
        }

        public TValue Get(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var linkedList = GetLinkedListByKey(key);

            var index = linkedList.FindFirstIndex(tuple => tuple.key.Equals(key));
            if (index >= 0)
            {
                return linkedList.Get(index).value;
            }

            throw new KeyNotFoundException();
        }
    }
}
