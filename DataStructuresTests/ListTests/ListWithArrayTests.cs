using System;
using DataStructuresLibrary.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.ListTests
{
    [TestClass]
    public class ListWithArrayTests
    {
        List<int> li;

        [TestInitialize]
        public void SetUp(){
            li = new List<int>();
        }

        [TestMethod]
        public void List_Constructor_should_throw_exception_when_capacity_is_zero()
        {
            try
            {
                List<int> li2 = new List<int>(0);
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
        public void List_IsEmpty_should_return_true_when_list_is_empty()
        {
            Assert.AreEqual(true, li.IsEmpty());
        }

        [TestMethod]
        public void List_IsEmpty_should_return_false_when_list_is_not_empty()
        {
            li.Add(1);

            Assert.AreEqual(false, li.IsEmpty());
        }

        [TestMethod]
        public void List_Remove_should_throw_exception_when_list_is_empty()
        {
            try
            {
                li.Remove(2);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The list is empty", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void List_Remove_should_decrease_size_by_1_when_element_exists()
        {
            li.Add(2);
            li.Add(3);
            li.Add(4);
            li.Add(5);
            Assert.AreEqual(4, li.Count());
            li.Remove(3);
            Assert.AreEqual(3, li.Count());
            li.Remove(2);
            Assert.AreEqual(2, li.Count());
            li.Remove(2);
            Assert.AreEqual(2, li.Count());
        }

        [TestMethod]
        public void List_RemoveAt_should_throw_exception_when_index_out_of_bounds()
        {
            li.Add(1);
            try
            {
                li.RemoveAt(-1);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            try
            {
                li.RemoveAt(1000);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void List_RemoveAt_should_throw_exception_when_list_is_empty()
        {
            try
            {
                li.RemoveAt(2);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The list is empty", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void List_RemoveAt_should_decrease_size_by_1_when_element_exists()
        {
            li.Add(2);
            li.Add(3);
            li.Add(4);
            li.Add(5);
            Assert.AreEqual(4, li.Count());
            li.RemoveAt(3);
            Assert.AreEqual(3, li.Count());
            li.RemoveAt(2);
            Assert.AreEqual(2, li.Count());
            li.RemoveAt(1);
            Assert.AreEqual(1, li.Count());
        }

        [TestMethod]
        public void List_add_should_increase_list_size_by_1()
        {
            li.Add(1);

            Assert.AreEqual(1, li.Count());
        }

        [TestMethod]
        public void List_many_adds_should_increase_list_size()
        {
            for (int i = 1; i < 150; i++)
            {
                li.Add(i);
            }

            Assert.AreEqual(149, li.Count());
            for (int i = 1; i < 150; i++)
            {
                Assert.AreEqual(i, li.Get(i - 1));
            }
        }

        [TestMethod]
        public void List_find_should_return_true_when_element_in_list()
        {
            li.Add(2);
            li.Add(3);
            li.Add(4);

            Assert.AreEqual(false, li.Find(1));
            Assert.AreEqual(true, li.Find(2));
            Assert.AreEqual(true, li.Find(3));
            Assert.AreEqual(true, li.Find(4));
            Assert.AreEqual(false, li.Find(5));
        }

        [TestMethod]
        public void List_Remove_should_not_remove_elements_out_of_size()
        {
            li.Add(1);
            li.Add(2);

            li.Remove(0);

            Assert.AreEqual(2, li.Count());
        }

        [TestMethod]
        public void List_Add_Remove_multiple_records_should_be_successful()
        {
            try
            {
                for (var i = 0; i < 150; i++)
                {
                    li.Add(i);
                }
                for (var i = 0; i < 150; i++)
                {
                    li.Remove(i);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
