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
        public void LinkedList_Add_AddedToEmptyLinkedList_Count1()
        {
            _ll.Add(1);
            Assert.AreEqual(1, _ll.Count());
        }

        [TestMethod]
        public void LinkedList_Add_AddedToLinkedList_CountIncreases()
        {
            _ll.Add(1);
            _ll.Add(1);
            _ll.Add(1);
            Assert.AreEqual(3, _ll.Count());
        }

        [TestMethod]
        public void LinkedList_Get_Empty_ThrowsException()
        {
            try
            {
                _ll.Get(0);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch (Exception ex)
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
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch (Exception ex)
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
    }
}
