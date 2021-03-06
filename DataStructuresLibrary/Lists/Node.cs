﻿namespace DataStructuresLibrary.Lists
{
    internal class Node<T>
    {
        internal T Data { get; set; }
        internal Node<T> Next { get; set; }
        internal Node<T> Prev { get; set; }

        internal Node(T newItem)
        {
            Data = newItem;
        }
    }
}
