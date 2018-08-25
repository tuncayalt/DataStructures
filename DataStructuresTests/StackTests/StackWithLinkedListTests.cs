using System;
using DataStructuresLibrary.Stacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.StackTests
{
    [TestClass]
    public class StackWithLinkedListTests
    {
        StackWithLinkedList<int> st;

        [TestInitialize]
        public void setUp()
        {
            st = new StackWithLinkedList<int>();
        }


        [TestMethod]
        public void StackWithLinkedList_IsEmpty_should_return_true_when_stack_is_empty()
        {
            Assert.AreEqual(true, st.IsEmpty());
        }

        [TestMethod]
        public void StackWithLinkedList_IsEmpty_should_return_false_when_stack_is_not_empty()
        {
            st.Push(1);

            Assert.AreEqual(false, st.IsEmpty());
        }

        [TestMethod]
        public void StackWithLinkedList_IsFull_should_return_false_when_stack_is_empty()
        {
            Assert.AreEqual(false, st.IsFull());
        }

        [TestMethod]
        public void StackWithLinkedList_IsFull_should_return_false_when_stack_has_less_elements()
        {
            StackWithLinkedList<int> st2 = new StackWithLinkedList<int>(2);
            st2.Push(1);

            Assert.AreEqual(false, st2.IsFull());
        }

        [TestMethod]
        public void StackWithLinkedList_IsFull_should_return_true_when_stack_has_capacity_number_of_elements()
        {
            StackWithLinkedList<int> st2 = new StackWithLinkedList<int>(2);
            st2.Push(1);
            st2.Push(3);

            Assert.AreEqual(true, st2.IsFull());
        }

        [TestMethod]
        public void StackWithLinkedList_Peek_should_throw_exception_when_stack_is_empty()
        {
            try
            {
                st.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StackWithLinkedList_Peek_should_return_1_when_last_element_is_1()
        {
            st.Push(1);

            Assert.AreEqual(1, st.Peek());
            Assert.AreEqual(1, st.GetCurrentSize());
        }

        [TestMethod]
        public void StackWithLinkedList_Pop_should_throw_exception_when_stack_is_empty()
        {
            try
            {
                st.Pop();
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StackWithLinkedList_Pop_should_return_1_when_last_element_is_1()
        {
            st.Push(1);

            Assert.AreEqual(1, st.Pop());
            Assert.AreEqual(0, st.GetCurrentSize());
        }

        [TestMethod]
        public void StackWithLinkedList_Push_should_throw_exception_when_stack_is_full()
        {
            StackWithLinkedList<int> st2 = new StackWithLinkedList<int>(2);
            st2.Push(1);
            st2.Push(3);
            try
            {
                st2.Push(4);
                Assert.Fail();
            }
            catch (StackOverflowException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
