using DataStructuresLibrary.Heaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.HeapTests
{
    [TestClass]
    public class MaxHeapTest
    {
        private IHeap<int> _heap;

        [TestInitialize]
        public void Setup()
        {
            _heap = new MaxHeap<int>();
        }

        [TestMethod]
        public void MaxHeap_GetFirst_EmptyHeap_ThrowsException()
        {
            // Arrange
            var pass = false;

            // Act
            try
            {
                var actual = _heap.GetFirst();
            }
            catch (EmptyHeapException)
            {
                pass = true;
            }

            // Assert
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void MaxHeap_GetFirst_SingleElement_ReturnsElement()
        {
            // Arrange
            _heap.Add(1);

            // Act
            var actual = _heap.GetFirst();

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void MaxHeap_GetFirst_2ElementsIncreasing_ReturnsMaxElement()
        {
            // Arrange
            _heap.Add(1);
            _heap.Add(2);

            // Act
            var actual = _heap.GetFirst();

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void MinHeap_GetFirst_2ElementsDecreasing_ReturnsMaxElement()
        {
            // Arrange
            _heap.Add(2);
            _heap.Add(1);

            // Act
            var actual = _heap.GetFirst();

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void MaxHeap_GetFirst_ManyElementsRandom_ReturnsMaxElement()
        {
            // Arrange
            _heap.Add(-3);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(-3);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(5);
            _heap.Add(2);
            _heap.Add(-1);
            _heap.Add(3);
            _heap.Add(20);
            _heap.Add(12);
            _heap.Add(30);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(-1);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(-13);
            _heap.Add(7);
            _heap.Add(-1);
            _heap.Add(8);
            _heap.Add(2);
            _heap.Add(-3);

            // Act, Assert
            Assert.AreEqual(30, _heap.GetFirst());
            Assert.AreEqual(30, _heap.GetFirst());
            Assert.AreEqual(30, _heap.GetFirst());
        }

        [TestMethod]
        public void MaxHeap_ExtractFirst_EmptyHeap_ThrowsException()
        {
            // Arrange
            var pass = false;

            // Act
            try
            {
                var actual = _heap.ExtractFirst();
            }
            catch (EmptyHeapException)
            {
                pass = true;
            }

            // Assert
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void MaxHeap_ExtractFirst_SingleElement_ReturnsElement()
        {
            // Arrange
            _heap.Add(1);

            // Act, Assert
            Assert.AreEqual(1, _heap.Count);
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(0, _heap.Count);
        }

        [TestMethod]
        public void MaxHeap_ExtractFirst_2ElementsIncreasing_ReturnsMaxElement()
        {
            // Arrange
            _heap.Add(1);
            _heap.Add(2);

            // Act, Assert
            Assert.AreEqual(2, _heap.Count);
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(1, _heap.Count);
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(0, _heap.Count);
        }

        [TestMethod]
        public void MaxHeap_ExtractFirst_2ElementsDecreasing_ReturnsMaxElement()
        {
            // Arrange
            _heap.Add(2);
            _heap.Add(1);

            // Act, Assert
            Assert.AreEqual(2, _heap.Count);
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(1, _heap.Count);
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(0, _heap.Count);
        }

        [TestMethod]
        public void MinHeap_ExtractFirst_ManyElementsRandom_ReturnsMinElement()
        {
            // Arrange
            _heap.Add(-3);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(-3);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(0);
            _heap.Add(2);
            _heap.Add(-1);
            _heap.Add(3);
            _heap.Add(20);
            _heap.Add(12);
            _heap.Add(30);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(-1);
            _heap.Add(2);
            _heap.Add(1);
            _heap.Add(-13);
            _heap.Add(7);
            _heap.Add(-1);
            _heap.Add(8);
            _heap.Add(2);
            _heap.Add(-3);

            // Act, Assert
            Assert.AreEqual(30, _heap.ExtractFirst());
            Assert.AreEqual(20, _heap.ExtractFirst());
            Assert.AreEqual(12, _heap.ExtractFirst());
            Assert.AreEqual(8, _heap.ExtractFirst());
            Assert.AreEqual(7, _heap.ExtractFirst());
            Assert.AreEqual(3, _heap.ExtractFirst());
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(2, _heap.ExtractFirst());
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(1, _heap.ExtractFirst());
            Assert.AreEqual(0, _heap.ExtractFirst());
            Assert.AreEqual(-1, _heap.ExtractFirst());
            Assert.AreEqual(-1, _heap.ExtractFirst());
            Assert.AreEqual(-1, _heap.ExtractFirst());
            Assert.AreEqual(-3, _heap.ExtractFirst());
            Assert.AreEqual(-3, _heap.ExtractFirst());
            Assert.AreEqual(-3, _heap.ExtractFirst());
            Assert.AreEqual(-13, _heap.ExtractFirst());
        }
    }
}
