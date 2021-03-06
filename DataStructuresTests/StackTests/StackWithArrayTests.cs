﻿using System;
using DataStructuresLibrary.Stacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.StackTests
{
    [TestClass]
    public class StackWithArrayTests
    {
        StackWithArray<int> st;

        [TestInitialize]
        public void SetUp(){
            st = new StackWithArray<int>();
        }

        [TestMethod]
        public void StackWithArray_Constructor_should_throw_exception_when_capacity_is_zero()
        {
            try
            {
                StackWithArray<int> st2 = new StackWithArray<int>(0);
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
        public void StackWithArray_IsEmpty_should_return_true_when_stack_is_empty(){
            Assert.AreEqual(true, st.IsEmpty());
        }

        [TestMethod]
        public void StackWithArray_IsEmpty_should_return_false_when_stack_is_not_empty()
        {
            st.Push(1);

            Assert.AreEqual(false, st.IsEmpty());
        }

        [TestMethod]
        public void StackWithArray_IsFull_should_return_false_when_stack_is_empty()
        {
            Assert.AreEqual(false, st.IsFull());
        }

        [TestMethod]
        public void StackWithArray_IsFull_should_return_false_when_stack_has_less_elements()
        {
            StackWithArray<int> st2 = new StackWithArray<int>(2);
            st2.Push(1);

            Assert.AreEqual(false, st2.IsFull());
        }

        [TestMethod]
        public void StackWithArray_IsFull_should_return_true_when_stack_has_capacity_number_of_elements()
        {
            StackWithArray<int> st2 = new StackWithArray<int>(2);
            st2.Push(1);
            st2.Push(3);

            Assert.AreEqual(true, st2.IsFull());
        }

        [TestMethod]
        public void StackWithArray_Peek_should_throw_exception_when_stack_is_empty()
        {
            try
            {
                st.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The stack is empty", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StackWithArray_Peek_should_return_1_when_last_element_is_1()
        {
            st.Push(1);

            Assert.AreEqual(1, st.Peek());
            Assert.AreEqual(1, st.GetCurrentSize());
        }

        [TestMethod]
        public void StackWithArray_Pop_should_throw_exception_when_stack_is_empty()
        {
            try
            {
                st.Pop();
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The stack is empty", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StackWithArray_Pop_should_return_1_when_last_element_is_1()
        {
            st.Push(1);

            Assert.AreEqual(1, st.Pop());
            Assert.AreEqual(0, st.GetCurrentSize());
        }

        [TestMethod]
        public void StackWithArray_Push_should_throw_exception_when_stack_is_full()
        {
            StackWithArray<int> st2 = new StackWithArray<int>(2);
            st2.Push(1);
            st2.Push(3);
            try
            {
                st2.Push(4);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The stack is full", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void StackWithArray_Push_should_increase_size_when_stack_is_available()
        {
            st.Push(1);
            st.Push(3);
            Assert.AreEqual(2, st.GetCurrentSize());
        }

        [TestMethod]
        public void StackWithArray_many_Push_should_increase_size_when_stack_is_available()
        {
            for (int i = 0; i < 150; i++)
            {
                st.Push(2);
            }
            Assert.AreEqual(150, st.GetCurrentSize());
        }
    }
}
