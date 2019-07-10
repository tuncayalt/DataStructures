namespace DataStructuresLibrary.Stacks
{
    internal class Node<T>
    {
        internal T Data { get; set; }
        internal Node<T> Next { get; set; }

        internal Node(T data)
        {
            Data = data;
        }
    }
}
