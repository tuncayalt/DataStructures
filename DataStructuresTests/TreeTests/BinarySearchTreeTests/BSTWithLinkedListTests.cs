using System;
using DataStructuresLibrary.Trees.BinarySearchTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.TreeTests.BinarySearchTreeTests
{
    [TestClass]
    public class BstWithLinkedListTests
    {
        private IBinarySearchTree<int> _bst;

        [TestInitialize]
        public void Setup()
        {
            _bst = new BstWithLinkedList<int>();
        }

        [TestMethod]
        public void BSTWithLinkedList_Add_EmptyTree_AddToRoot()
        {
            // Arrange, Act
            _bst.Add(1);

            // Assert
            Assert.AreEqual(1, _bst.Count);
        }

        [TestMethod]
        public void BSTWithLinkedList_Add_NullValue_ThrowsException()
        {
            // Arrange
            var bstNullable = new BstWithLinkedList<string>();
            var argumentNullExceptionThrown = false;

            // Act
            try
            {
                bstNullable.Add(null);
            }
            catch (ArgumentNullException)
            {
                argumentNullExceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(argumentNullExceptionThrown);
        }

        [TestMethod]
        public void BSTWithLinkedList_Add_AddSameToEmptyTree_AddToRoot()
        {
            // Arrange, Act
            _bst.Add(1);
            _bst.Add(1);

            // Assert
            Assert.AreEqual(1, _bst.Count);
        }

        [TestMethod]
        public void BSTWithLinkedList_Add_AddMoreToEmptyTree_AddToRoot()
        {
            // Arrange, Act
            _bst.Add(1);
            _bst.Add(2);
            _bst.Add(0);
            _bst.Add(-2);
            _bst.Add(0);
            _bst.Add(3);
            _bst.Add(9);

            // Assert
            Assert.AreEqual(6, _bst.Count);
        }

        [TestMethod]
        public void BSTWithLinkedList_Search_EmptyTree_ReturnsFalse()
        {
            // Arrange, Act, Assert
            Assert.IsFalse(_bst.Search(1));
        }

        [TestMethod]
        public void BSTWithLinkedList_Search_NullTarget_ThrowsException()
        {
            // Arrange
            var bstNullable = new BstWithLinkedList<string>();
            var argumentNullExceptionThrown = false;

            // Act
            try
            {
                bstNullable.Search(null);
            }
            catch (ArgumentNullException)
            {
                argumentNullExceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(argumentNullExceptionThrown);
        }

        [TestMethod]
        public void BSTWithLinkedList_Search_1ElementWrongTarget_ReturnsFalse()
        {
            // Arrange
            _bst.Add(1);

            // Act
            var actual = _bst.Search(2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void BSTWithLinkedList_Search_1ElementRightTarget_ReturnsFalse()
        {
            // Arrange
            _bst.Add(1);

            // Act
            var actual = _bst.Search(1);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void BSTWithLinkedList_Search_ManyElementsWrongTarget_ReturnsFalse()
        {
            // Arrange
            _bst.Add(1);
            _bst.Add(2);
            _bst.Add(0);
            _bst.Add(-2);
            _bst.Add(0);
            _bst.Add(3);
            _bst.Add(9);

            // Act
            var actual = _bst.Search(4);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void BSTWithLinkedList_Search_ManyElementsRightTarget_ReturnsTrue()
        {
            // Arrange
            _bst.Add(1);
            _bst.Add(2);
            _bst.Add(0);
            _bst.Add(-2);
            _bst.Add(0);
            _bst.Add(3);
            _bst.Add(9);

            // Act
            var actual = _bst.Search(3);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
