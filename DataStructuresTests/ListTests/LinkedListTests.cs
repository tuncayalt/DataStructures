using System;
using DataStructuresLibrary.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.ListTests
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int> _ll;

        [TestInitialize]
        public void Setup()
        {
            _ll = new LinkedList<int>();
        }

        [TestMethod]
        public void LinkedList_IsEmpty_ListEmpty_ReturnsTrue()
        {
            Assert.IsTrue(_ll.IsEmpty());
        }

        [TestMethod]
        public void LinkedList_IsEmpty_ListNotEmpty_ReturnsFalse()
        {
            _ll.Add(1);
            Assert.IsFalse(_ll.IsEmpty());
        }

        [TestMethod]
        public void LinkedList_Count_Returns0WhenEmpty()
        {
            Assert.AreEqual(0, _ll.Count());
        }

        [TestMethod]
        public void LinkedList_Count_ReturnsCountWhenNotEmpty()
        {
            for (var i = 0; i < 5; i++)
            {
                _ll.Add(i);
            }

            Assert.AreEqual(5, _ll.Count());
        }

        [TestMethod]
        public void LinkedList_Add_AddedToLinkedList_CountIncreases()
        {
            _ll.Add(1);
            _ll.Add(2);
            _ll.Add(3);
            Assert.AreEqual(3, _ll.Count());
            Assert.AreEqual(1, _ll.Get(0));
            Assert.AreEqual(2, _ll.Get(1));
            Assert.AreEqual(3, _ll.Get(2));
        }

        [TestMethod]
        public void LinkedList_AddFirst_AddedToLinkedList_CountIncreases()
        {
            _ll.AddFirst(1);
            _ll.AddFirst(2);
            _ll.AddFirst(3);
            Assert.AreEqual(3, _ll.Count());
            Assert.AreEqual(3, _ll.Get(0));
            Assert.AreEqual(2, _ll.Get(1));
            Assert.AreEqual(1, _ll.Get(2));
        }

        [TestMethod]
        public void LinkedList_Get_Empty_ThrowsException()
        {
            try
            {
                _ll.Get(0);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LinkedList_Get_OutOfRange_ThrowsException()
        {
            _ll.Add(1);

            try
            {
                
                _ll.Get(2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LinkedList_Get_InRange_ReturnsElement()
        {
            _ll.Add(1);
            _ll.Add(2);
            _ll.Add(3);
            Assert.AreEqual(1, _ll.Get(0));
            Assert.AreEqual(2, _ll.Get(1));
            Assert.AreEqual(3, _ll.Get(2));
        }

        [TestMethod]
        public void LinkedList_Find_ListEmpty_ReturnsFalse()
        {
            var exists = _ll.Find(1);

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void LinkedList_Find_ElementNotExists_ReturnsFalse()
        {
            _ll.Add(2);
            var exists = _ll.Find(1);

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void LinkedList_Find_ElementExists_ReturnsTrue()
        {
            _ll.Add(1);
            _ll.Add(2);

            Assert.IsTrue(_ll.Find(1));
            Assert.IsTrue(_ll.Find(2));
        }

        [TestMethod]
        public void LinkedList_Remove_ListEmpty_NoChange()
        {
            _ll.Remove(1);

            Assert.IsTrue(_ll.IsEmpty());
        }

        [TestMethod]
        public void LinkedList_Remove_ElementNotExist_CountStaysSame()
        {
            _ll.Add(1);

            _ll.Remove(2);
            Assert.AreEqual(1, _ll.Count());

            _ll.Remove(3);
            Assert.AreEqual(1, _ll.Count());
        }

        [TestMethod]
        public void LinkedList_Remove_ElementExists_CountDecreasesBy1()
        {
            _ll.Add(1);
            _ll.Add(2);
            _ll.Add(3);

            _ll.Remove(2);
            Assert.AreEqual(2, _ll.Count());
            _ll.Remove(1);
            Assert.AreEqual(1, _ll.Count());
            _ll.Remove(3);
            Assert.AreEqual(0, _ll.Count());
        }

        [TestMethod]
        public void LinkedList_RemoveAt_ListEmpty_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                _ll.RemoveAt(0);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LinkedList_RemoveAt_IndexTooSmall_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                _ll.Add(1);
                _ll.RemoveAt(-1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LinkedList_RemoveAt_IndexEqualToSize_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                _ll.Add(1);
                _ll.RemoveAt(1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LinkedList_RemoveAt_IndexGreaterThanSize_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                _ll.Add(1);
                _ll.RemoveAt(2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LinkedList_RemoveAt_IndexInList_CountDecreasesByOne()
        {
            _ll.Add(1);
            _ll.Add(2);
            _ll.Add(3);
            _ll.RemoveAt(2);
            Assert.AreEqual(2, _ll.Count());
            Assert.IsFalse(_ll.Find(3));

            _ll.Add(4);
            _ll.RemoveAt(0);
            Assert.AreEqual(2, _ll.Count());
            Assert.IsFalse(_ll.Find(1));

            _ll.Add(5);
            _ll.RemoveAt(1);
            Assert.AreEqual(2, _ll.Count());
            Assert.IsFalse(_ll.Find(4));
        }

        [TestMethod]
        public void LinkedList_FindIndex_ListEmpty_ReturnsMinusOne()
        {
            var index = _ll.FindFirstIndex(1);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void LinkedList_FindIndex_ElementNotExists_ReturnsMinusOne()
        {
            _ll.Add(2);
            var index = _ll.FindFirstIndex(1);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void LinkedList_FindIndex_ElementExists_ReturnsIndex()
        {
            _ll.Add(1);
            _ll.Add(2);

            Assert.AreEqual(0, _ll.FindFirstIndex(1));
            Assert.AreEqual(1, _ll.FindFirstIndex(2));
        }
    }
}
