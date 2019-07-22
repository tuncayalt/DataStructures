using System.Collections.Generic;
using DataStructuresLibrary.Common;

namespace DataStructuresLibrary.Graphs
{
    public class GraphWithAdjList<T, U> : IGraph<T, U>
    {
        public int Count { get; set; }
        private Lists.LinkedList<Vertex<T, U>> _vertices;
        private Dictionary<T, Vertex<T, U>> _verticesLookup;
        private readonly bool _directed;

        public GraphWithAdjList(bool directed = false)
        {
            _directed = directed;
            _vertices = new Lists.LinkedList<Vertex<T, U>>();
            _verticesLookup = new Dictionary<T, Vertex<T, U>>();
        }

        public Vertex<T, U> GetVertex(T key)
        {
            Guard.ArgumentNotNull(key, nameof(key));

            if (_verticesLookup.ContainsKey(key))
            {
                return _verticesLookup[key];
            }

            return null;
        }

        public void AddVertex(T value)
        {
            Guard.ArgumentNotNull(value, nameof(value));

            if (GetVertex(value) != null)
            {
                return;
            }

            var vertex = new Vertex<T, U>(value);
            _vertices.Add(vertex);
            _verticesLookup[value] = vertex;

            Count++;
        }

        public void AddEdge(T source, T destination)
        {
            AddEdge(source, destination, default);
        }

        public void AddEdge(T source, T destination, U edgeData)
        {
            Guard.ArgumentNotNull(source, nameof(source));
            Guard.ArgumentNotNull(destination, nameof(destination));

            var sourceVertex = GetVertex(source);
            Guard.NotNull(sourceVertex, nameof(sourceVertex));
            var destinationVertex = GetVertex(destination);
            Guard.NotNull(destinationVertex, nameof(destinationVertex));

            AddEdge(sourceVertex, destinationVertex, edgeData);
        }

        private void AddEdge(Vertex<T, U> sourceVertex, Vertex<T, U> destinationVertex, U edgeData)
        {
            Guard.ArgumentNotNull(sourceVertex, nameof(sourceVertex));
            Guard.ArgumentNotNull(destinationVertex, nameof(destinationVertex));

            var edge = new Edge<T, U>
            {
                Neighbor = destinationVertex.Data,
                EdgeData = edgeData
            };
            sourceVertex.adjList.Add(edge);

            if (!_directed)
            {
                var reverseEdge = new Edge<T, U>
                {
                    Neighbor = sourceVertex.Data,
                    EdgeData = edgeData
                };
                destinationVertex.adjList.Add(reverseEdge);
            }
        }
    }
}
