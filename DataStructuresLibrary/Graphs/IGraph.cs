namespace DataStructuresLibrary.Graphs
{
    public interface IGraph<T, U>
    {
        int Count { get; set; }
        Vertex<T, U> GetVertex(T key);
        void AddVertex(T value);
        void AddEdge(T source, T destination);
        void AddEdge(T source, T destination, U edgeData);
    }
}
