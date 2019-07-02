using DataStructuresLibrary.HashTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataStructuresTests.HashTableTests
{
    [TestClass]
    public class HashTableWithLinkedListsTests
    {
        private IHashTable<int?, string> _ht;

        [TestInitialize]
        public void Setup()
        {
            _ht = new HashTable<int?, string>();
        }

        [TestMethod]
        public void HashTable_Add_AddNullKey_ThrowsArgumentNullException()
        {
            try
            {
                _ht.Add(null, "one");
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void HashTable_Add_AddToEmptyHashTable_Successful()
        {
            _ht.Add(1, "one");

            Assert.AreEqual("one", _ht.Get(1));
        }

        [TestMethod]
        public void HashTable_Add_AddToNonEmptyHashTable_Successful()
        {
            _ht.Add(1, "one");
            _ht.Add(2, "two");

            Assert.AreEqual("one", _ht.Get(1));
            Assert.AreEqual("two", _ht.Get(2));
        }

        [TestMethod]
        public void HashTable_Add_UpdateValue_Successful()
        {
            _ht.Add(1, "notone");
            _ht.Add(1, "one");

            Assert.AreEqual("one", _ht.Get(1));
        }

        [TestMethod]
        public void HashTable_Get_EmptyHashTable_KeyNotFoundException()
        {
            try
            {
                _ht.Get(1);
                Assert.Fail();
            }
            catch (KeyNotFoundException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void HashTable_Get_ThereIsNoKey_KeyNotFoundException()
        {
            try
            {
                _ht.Get(1);
                Assert.Fail();
            }
            catch (KeyNotFoundException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void HashTable_ContainsKey_NullKey_ThrowsArgumentNullException()
        {
            try
            {
                _ht.ContainsKey(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void HashTable_ContainsKey_KeyExists_ReturnsTrue()
        {
            _ht.Add(1, "one");

            Assert.IsTrue(_ht.ContainsKey(1));
        }

        [TestMethod]
        public void HashTable_ContainsKey_KeyNotExists_ReturnsFalse()
        {
            _ht.Add(1, "one");

            Assert.IsFalse(_ht.ContainsKey(2));
        }
    }
}
