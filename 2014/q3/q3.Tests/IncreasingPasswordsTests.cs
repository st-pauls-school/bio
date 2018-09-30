using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace q3.Tests
{
    [TestClass]
    public class IncreasingPasswordsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var IP = new IncreasingPasswords(1);
            Assert.AreEqual(45, IP.NChooseK(10, 2));
            Assert.AreEqual(55, IP.NChooseK(11, 2));
            Assert.AreEqual(10, IP.NChooseK(5, 3));
            Assert.AreEqual(1, IP.NChooseK(10, 0));
            Assert.AreEqual(10, IP.NChooseK(10, 9));
        }

        [TestMethod]
        public void TestLimits()
        {
            var IP = new IncreasingPasswords(3);
            IList<int> three = new List<int> { 3, 6, 7 };
            CollectionAssert.AreEqual((ICollection)three, (ICollection)IP.Limits);
        }
    }
}
