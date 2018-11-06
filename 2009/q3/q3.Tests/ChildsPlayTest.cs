using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using q3.Logic;

namespace q3.Tests
{
    [TestClass]
    public class ChildsPlayTest
    {
        Arrangements _arrangements;
        [TestInitialize]
        public void Setup()
        {
            _arrangements = new Arrangements(32);
        }

        [TestMethod]
        public void MarkScheme()
        {
            ChildsPlay cp = new ChildsPlay(_arrangements);
            CollectionAssert.AreEqual(new List<int> { 2, 1, 1 }, (ICollection)cp.Result(4, 5));
            CollectionAssert.AreEqual(new List<int> { 1 }, (ICollection)cp.Result(1, 1));
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1, 1, 1 }, (ICollection)cp.Result(5, 1));
            CollectionAssert.AreEqual(new List<int> { 6 }, (ICollection)cp.Result(6, 32));
            CollectionAssert.AreEqual(new List<int> { 6, 1 }, (ICollection)cp.Result(7, 63));
            CollectionAssert.AreEqual(new List<int> { 2, 1, 2, 1, 2 }, (ICollection)cp.Result(8, 74));

            CollectionAssert.AreEqual(new List<int> {3, 3, 3, 3 }, (ICollection)cp.Result(12, 1752));
            CollectionAssert.AreEqual(new List<int> { 2, 1, 4, 1, 4, 1, 1 }, (ICollection)cp.Result(14, 5000));
            CollectionAssert.AreEqual(new List<int> { 5, 3, 3, 2, 1, 2, 2, 1, 2}, (ICollection)cp.Result(21, 1000000));
            CollectionAssert.AreEqual(new List<int> { 3, 1, 1, 2, 2, 1, 1, 4, 4, 1, 7}, (ICollection)cp.Result(27, 50789789));
            CollectionAssert.AreEqual(new List<int> { 2, 1, 2, 3, 1, 4, 2, 1, 5, 3, 3, 3, 2}, (ICollection)cp.Result(32, 1234567890));
        }
    }
}
