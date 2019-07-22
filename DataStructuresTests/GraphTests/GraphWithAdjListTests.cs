using System;
using System.Linq;
using DataStructuresLibrary.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.GraphTests
{
    [TestClass]
    public class GraphWithAdjListTests
    {
        private IGraph<int, int> _graph;

        [TestInitialize]
        public void Setup()
        {
            _graph = new GraphWithAdjList<int, int>();
        }

        [TestMethod]
        public void GraphWithAdjList_AddVertex_ToEmptyGraph_Count1()
        {
            // Arrange, Act
            _graph.AddVertex(1);

            // Assert
            Assert.AreEqual(1, _graph.Count);
        }

        [TestMethod]
        public void GraphWithAdjList_AddVertex_To1ElementGraph_Count2()
        {
            // Arrange, Act
            _graph.AddVertex(1);
            _graph.AddVertex(2);

            // Assert
            Assert.AreEqual(2, _graph.Count);
        }

        [TestMethod]
        public void GraphWithAdjList_AddVertex_AddNullElement_ThrowsException()
        {
            // Arrange
            var graph = new GraphWithAdjList<string, int>();
            var exceptionThrown = false;

            // Act
            try
            {
                graph.AddVertex(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GraphWithAdjList_AddVertex_SameElement_Count1()
        {
            // Arrange, Act
            _graph.AddVertex(1);
            _graph.AddVertex(1);

            // Assert
            Assert.AreEqual(1, _graph.Count);
        }

        [TestMethod]
        public void GraphWithAdjList_GetVertex_EmptyGraph_ReturnsNull()
        {
            // Arrange, Act
            var actual = _graph.GetVertex(1);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GraphWithAdjList_GetVertex_NullArgument_ThrowsException()
        {
            // Arrange
            IGraph<string, int> graph = new GraphWithAdjList<string, int>();
            var exceptionThrown = false;

            // Act
            try
            {
                graph.GetVertex(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GraphWithAdjList_GetVertex_ElementExist_ReturnsVertex()
        {
            // Arrange
            _graph.AddVertex(1);
            _graph.AddVertex(2);

            // Act
            var actual = _graph.GetVertex(1);

            // Assert
            Assert.AreEqual(1, actual.Data);
        }

        [TestMethod]
        public void GraphWithAdjList_GetVertex_ElementNotExist_ReturnsNull()
        {
            // Arrange
            _graph.AddVertex(1);
            _graph.AddVertex(2);

            // Act
            var actual = _graph.GetVertex(3);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GraphWithAdjList_AddEdge_EmptyGraph_ThrowsException()
        {
            // Arrange
            var exceptionThrown = false;

            // Act
            try
            {
                _graph.AddEdge(1, 2);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GraphWithAdjList_AddEdge_NullSource_ThrowsException()
        {
            // Arrange
            var exceptionThrown = false;
            var graph = new GraphWithAdjList<string, int>();

            // Act
            try
            {
                graph.AddEdge(null, "");
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GraphWithAdjList_AddEdge_SourceNotExist_ThrowsException()
        {
            // Arrange
            var exceptionThrown = false;
            _graph.AddVertex(1);

            // Act
            try
            {
                _graph.AddEdge(2, 1);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GraphWithAdjList_AddEdge_DestinationNotExist_ThrowsException()
        {
            // Arrange
            var exceptionThrown = false;
            _graph.AddVertex(1);

            // Act
            try
            {
                _graph.AddEdge(1, 2);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GraphWithAdjList_AddEdge_NormalFlow_EdgeAdded()
        {
            // Arrange
            _graph.AddVertex(1);
            _graph.AddVertex(2);
            var source = _graph.GetVertex(1);
            var dest = _graph.GetVertex(2);

            // Act
            _graph.AddEdge(1, 2);

            // Assert
            var sourceEdge = source.adjList.FirstOrDefault(e => e.Neighbor.Equals(dest.Data));
            var destEdge = dest.adjList.FirstOrDefault(e => e.Neighbor.Equals(source.Data));
            Assert.IsNotNull(sourceEdge);
            Assert.IsNotNull(destEdge);
        }

        [TestMethod]
        public void GraphWithAdjList_AddEdge_DirectedNormalFlow_EdgeAdded()
        {
            // Arrange
            var graph = new GraphWithAdjList<int, int>(true);
            graph.AddVertex(1);
            graph.AddVertex(2);
            var source = graph.GetVertex(1);
            var dest = graph.GetVertex(2);

            // Act
            graph.AddEdge(1, 2);

            // Assert
            var sourceEdge = source.adjList.FirstOrDefault(e => e.Neighbor.Equals(dest.Data));
            var destEdge = dest.adjList.FirstOrDefault(e => e.Neighbor.Equals(source.Data));
            Assert.IsNotNull(sourceEdge);
            Assert.IsNull(destEdge);
        }
    }
}
