using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using q3logic;
using System.Collections.Generic;
using System.Collections;

namespace q3Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBreak()
        {
            CollectionAssert.AreEquivalent((ICollection)new List<int> { 1, 2, 3 }, (ICollection)SerialNumbers.Break(3, 123));
            CollectionAssert.AreEquivalent((ICollection)new List<int> { 0, 2, 3, 5 }, (ICollection)SerialNumbers.Break(4, 235));
            CollectionAssert.AreEquivalent((ICollection)new List<int> { 4, 6, 1, 2, 3, 5 }, (ICollection)SerialNumbers.Break(6, 461235));
        }
        [TestMethod]
        public void TestRecombine()
        {
            Assert.AreEqual(123, SerialNumbers.Recombine(new List<int> { 1, 2, 3 }));
            Assert.AreEqual(461235, SerialNumbers.Recombine(new List<int> { 4, 6, 1, 2, 3, 5 }));
        }

        [TestMethod]
        public void TestGenerate()
        {
            SerialNumbers sn = new SerialNumbers(6);
            IList<int> ev = new List<int> { 416235 };
            CollectionAssert.AreEquivalent((ICollection)ev, (ICollection)sn.GenerateNeighbours(461235));
            ev = new List<int> { 142635, 412365, 416235 };
            CollectionAssert.AreEquivalent((ICollection)ev, (ICollection)sn.GenerateNeighbours(412635));
        }
        [TestMethod]
        public void Test1()
        {
            SerialNumbers sn = new SerialNumbers(6);
            Assert.AreEqual(6, sn.Go(461235));
        }
        [TestMethod]
        public void Test2()
        {
            SerialNumbers sn = new SerialNumbers(6);
            Assert.AreEqual(3, sn.Go(412365));
        }
        [TestMethod]
        public void Test3()
        {
            SerialNumbers sn = new SerialNumbers(9);
            Assert.AreEqual(0, sn.Go(123456789));
        }
        [TestMethod]
        public void Test4()
        {
            SerialNumbers sn = new SerialNumbers(1);
            Assert.AreEqual(0, sn.Go(1));
        }
        [TestMethod]
        public void Test5()
        {
            SerialNumbers sn = new SerialNumbers(3);
            Assert.AreEqual(1, sn.Go(132));
        }
        [TestMethod]
        public void Test6()
        {
            SerialNumbers sn = new SerialNumbers(5);
            Assert.AreEqual(3, sn.Go(41235));
        }
        [TestMethod]
        public void Test7()
        {
            SerialNumbers sn = new SerialNumbers(6);
            Assert.AreEqual(5, sn.Go(254631));
        }
        [TestMethod]
        public void Test12()
        {
            SerialNumbers sn = new SerialNumbers(9);
            Assert.AreEqual(19, sn.Go(547389126));
        }
    }
}
