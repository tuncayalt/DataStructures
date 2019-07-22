namespace DataStructuresLibrary.Trees.BinarySearchTrees
{
    internal class Node<T>
    {
        internal T Data { get; set; }
        internal Node<T> Left { get; set; }
        internal Node<T> Right { get; set; }

        public Node(T value)
        {
            Data = value;
        }
    }
}
