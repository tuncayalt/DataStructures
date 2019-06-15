using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLibrary.Lists
{
    internal class Node<T>
    {
        internal T data;
        internal Node<T> next;
        internal Node<T> prev;

        public Node(T newItem)
        {
            data = newItem;
        }
    }
}
