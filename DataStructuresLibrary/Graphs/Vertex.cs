using DataStructuresLibrary.Lists;

namespace DataStructuresLibrary.Graphs
{
    public class Vertex<T, U>
    {
        public T Data { get; set; }
        public LinkedList<Edge<T, U>> adjList { get; set; }

        public Vertex(T data)
        {
            Data = data;
            adjList = new LinkedList<Edge<T, U>>();
        }
    }
}
