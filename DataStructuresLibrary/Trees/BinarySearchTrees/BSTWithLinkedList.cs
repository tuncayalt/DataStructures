using System;
using DataStructuresLibrary.Common;

namespace DataStructuresLibrary.Trees.BinarySearchTrees
{
    public class BstWithLinkedList<T> : IBinarySearchTree<T> where T : IComparable
    {
        private Node<T> _root;
        public int Count { get; private set; }

        public void Add(T value)
        {
            Guard.ArgumentNotNull(value, nameof(value));

            if (_root == null)
            {
                _root = new Node<T>(value);
                Count++;
                return;
            }

            var current = _root;

            while (true)
            {
                if (value.CompareTo(current.Data) == 0)
                {
                    return;
                }

                if (value.CompareTo(current.Data) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node<T>(value);
                        Count++;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node<T>(value);
                        Count++;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }
        }

        public bool Search(T value)
        {
            Guard.ArgumentNotNull(value, nameof(value));

            var curr = _root;

            while (true)
            {
                if (curr == null)
                {
                    return false;
                }

                if (curr.Data.CompareTo(value) == 0)
                {
                    return true;
                }

                if (curr.Data.CompareTo(value) > 0)
                {
                    curr = curr.Left;
                }
                else
                {
                    curr = curr.Right;
                }
            }
        }
    }
}
