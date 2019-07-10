namespace DataStructuresLibrary.Queues
{
    internal class Node<T>
    {
        internal T Data { get; set; }
        internal Node<T> Next { get; set; }

        internal Node(T newValue)
        {
            Data = newValue;
        }
    }
}
