using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q1.Lib;

namespace Q1.Tests
{
    [TestClass]
    public class AnagramNumbersTests
    {
        [TestMethod]
        public void TestCompareTrue()
        {
            Assert.IsTrue(AnagramNumbers.Compare(54321, 12345));
            Assert.IsTrue(AnagramNumbers.Compare(54321, 54312));
            Assert.IsTrue(AnagramNumbers.Compare(543212, 123245));
            Assert.IsTrue(AnagramNumbers.Compare(54321233, 12324335));

        }

        [TestMethod]
        public void TestCompareFalse()
        {
            Assert.IsFalse(AnagramNumbers.Compare(12345, 32144));
            Assert.IsFalse(AnagramNumbers.Compare(123456, 32145));
        }

        [TestMethod]
        public void TestGenerateGiven()
        {
            CollectionAssert.AreEqual(new List<int> { 2, 4, 5, 7, 8 }, AnagramNumbers.Generate(123456789));
        }

        [TestMethod]
        public void TestGenerateMarkScheme()
        {
            CollectionAssert.AreEqual(new List<int> { 2,4,5,7,8}, AnagramNumbers.Generate(123456789));
            CollectionAssert.AreEqual(new List<int> { }, AnagramNumbers.Generate(100));
            CollectionAssert.AreEqual(new List<int> { }, AnagramNumbers.Generate(1));
            CollectionAssert.AreEqual(new List<int> { }, AnagramNumbers.Generate(148258));
            CollectionAssert.AreEqual(new List<int> { }, AnagramNumbers.Generate(555));
            CollectionAssert.AreEqual(new List<int> { 3}, AnagramNumbers.Generate(1035));
            CollectionAssert.AreEqual(new List<int> { 3,7}, AnagramNumbers.Generate(123876));
            CollectionAssert.AreEqual(new List<int> { 2,3,4,5,6}, AnagramNumbers.Generate(142857));
            CollectionAssert.AreEqual(new List<int> { 2}, AnagramNumbers.Generate(49271085));
            CollectionAssert.AreEqual(new List<int> { 7}, AnagramNumbers.Generate(123450186));
        }
    }
}
