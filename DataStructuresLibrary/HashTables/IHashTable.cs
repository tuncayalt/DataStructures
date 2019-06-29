using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLibrary.HashTables
{
    public interface IHashTable<TKey, TValue>
    {
        TValue Get(TKey key);
        void Add(TKey key, TValue value);
        bool ContainsKey(TKey key);
    }
}
