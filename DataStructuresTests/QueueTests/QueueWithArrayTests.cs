﻿using System;
using DataStructuresLibrary.Queues;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.QueueTests
{
    [TestClass]
    public class QueueWithArrayTests
    {
        QueueWithArray<int> qu;

        [TestInitialize]
        public void SetUp(){
            qu = new QueueWithArray<int>();
        }

        [TestMethod]
        public void QueueWithArray_Constructor_should_throw_exception_when_capacity_is_zero()
        {
            try
            {
                QueueWithArray<int> qu2 = new QueueWithArray<int>(0);
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
        public void QueueWithArray_IsEmpty_should_return_true_when_queue_is_empty()
        {
            Assert.AreEqual(true, qu.IsEmpty());
        }

        [TestMethod]
        public void QueueWithArray_IsEmpty_should_return_false_when_queue_is_not_empty()
        {
            qu.Enqueue(1);

            Assert.AreEqual(false, qu.IsEmpty());
        }

        [TestMethod]
        public void QueueWithArray_IsFull_should_return_false_when_queue_is_empty()
        {
            Assert.AreEqual(false, qu.IsFull());
        }

        [TestMethod]
        public void QueueWithArray_IsFull_should_return_false_when_stack_has_less_elements()
        {
            QueueWithArray<int> qu2 = new QueueWithArray<int>(2);
            qu2.Enqueue(1);

            Assert.AreEqual(false, qu2.IsFull());
        }

        [TestMethod]
        public void QueueWithArray_IsFull_should_return_true_when_queue_has_capacity_number_of_elements()
        {
            QueueWithArray<int> qu2 = new QueueWithArray<int>(2);
            qu2.Enqueue(1);
            qu2.Enqueue(3);

            Assert.AreEqual(true, qu2.IsFull());
        }

        [TestMethod]
        public void QueueWithArray_Peek_should_throw_exception_when_queue_is_empty()
        {
            try
            {
                qu.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The queue is empty", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void QueueWithArray_Peek_should_return_1_when_last_element_is_1()
        {
            qu.Enqueue(1);

            Assert.AreEqual(1, qu.Peek());
            Assert.AreEqual(1, qu.GetCurrentSize());
        }

        [TestMethod]
        public void QueueWithArray_Dequeue_should_throw_exception_when_queue_is_empty()
        {
            try
            {
                qu.Dequeue();
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The queue is empty", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void QueueWithArray_Dequeue_should_return_1_when_first_element_is_1()
        {
            qu.Enqueue(1);
            qu.Enqueue(3);

            Assert.AreEqual(1, qu.Dequeue());
            Assert.AreEqual(1, qu.GetCurrentSize());
            Assert.AreEqual(3, qu.Dequeue());
            Assert.AreEqual(0, qu.GetCurrentSize());
        }

        [TestMethod]
        public void QueueWithArray_Enqueue_should_throw_exception_when_queue_is_full()
        {
            QueueWithArray<int> qu2 = new QueueWithArray<int>(2);
            qu2.Enqueue(2);
            qu2.Enqueue(4);
            try
            {
                qu2.Enqueue(3);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The queue is full", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void QueueWithArray_Enqueue_should_increase_queue_size_by_1(){
            qu.Enqueue(1);

            Assert.AreEqual(1, qu.Peek());
            Assert.AreEqual(1, qu.GetCurrentSize());
        }

        [TestMethod]
        public void QueueWithArray_many_Enqueue_should_increase_queue_size()
        {
            for (int i = 0; i < 150; i++)
            {
                qu.Enqueue(i);
            }

            Assert.AreEqual(0, qu.Peek());
            Assert.AreEqual(150, qu.GetCurrentSize());
        }
    }
}
