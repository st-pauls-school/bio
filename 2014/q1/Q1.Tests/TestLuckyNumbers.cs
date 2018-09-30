using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Q1.Tests
{
    [TestClass]
    public class TestLuckyNumbers
    {
        [TestMethod]
        public void TestMethod1()
        {
            var luckyNumbers = new BIO2014_Q1.LuckyNumbers(10100);

            IList<Func<int>> calls = = new List<Func<int>> { () => luckyNumbers.Lower(5) };
            foreach(var call in calls)
            {

            }

            Assert.AreEqual(3, luckyNumbers.Lower(5));
            Assert.AreEqual(7, luckyNumbers.Higher(5));

            Assert.AreEqual(31, luckyNumbers.Lower(33));
            Assert.AreEqual(37, luckyNumbers.Higher(33));

            Assert.AreEqual(33, luckyNumbers.Lower(34));
            Assert.AreEqual(37, luckyNumbers.Higher(34));

            Assert.AreEqual(393, luckyNumbers.Lower(399));
            Assert.AreEqual(409, luckyNumbers.Higher(399));

            Assert.AreEqual(451, luckyNumbers.Lower(456));
            Assert.AreEqual(463, luckyNumbers.Higher(456));

            Assert.AreEqual(3297, luckyNumbers.Lower(3301));
            Assert.AreEqual(3307, luckyNumbers.Higher(3301));

            Assert.AreEqual(3301, luckyNumbers.Lower(3304));
            Assert.AreEqual(3307, luckyNumbers.Higher(3304));

            Assert.AreEqual(9691, luckyNumbers.Lower(9703));
            Assert.AreEqual(9727, luckyNumbers.Higher(9703));

            Assert.AreEqual(9999, luckyNumbers.Lower(10000));
            Assert.AreEqual(10003, luckyNumbers.Higher(10000));

            Assert.AreEqual(23, luckyNumbers.Below(100));

            
        }
    }
}
