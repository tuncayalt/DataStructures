using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary.Trees.BinarySearchTrees
{
    public interface IBinarySearchTree<in T> where T : IComparable
    {
        int Count { get; }
        void Add(T value);
        bool Search(T value);
    }
}
