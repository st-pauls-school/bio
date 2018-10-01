using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using q3;

namespace q3Tests
{
    [TestClass]
    public class NewOrderTests
    {
        [TestMethod]
        public void TestNChooseR()
        {
            Assert.AreEqual(21, NewOrder.NChooseR(7, 2));
            Assert.AreEqual(10, NewOrder.NChooseR(5, 3));
            Assert.AreEqual(1, NewOrder.NChooseR(5, 5));
            Assert.AreEqual(210, NewOrder.NChooseR(10, 4));
            Assert.AreEqual(11440, NewOrder.NChooseR(16, 9));
        }

        [TestMethod]
        public void TestHowManyOnes()
        {
            Assert.AreEqual(2, NewOrder.HowManyOnes(3));
            Assert.AreEqual(1, NewOrder.HowManyOnes(64));
            Assert.AreEqual(2, NewOrder.HowManyOnes(65));
        }

        [TestMethod]
        public void TestNthWithMOnes()
        {
            Assert.AreEqual("1000", NewOrder.NthWithMOnes(4, 1));
            Assert.AreEqual("11011", NewOrder.NthWithMOnes(3, 4));
        }

        [TestMethod]
        public void TestMarkScheme()
        {
            Assert.AreEqual("11011", NewOrder.NthWithMOnes(3, 4));
            Assert.AreEqual("0", NewOrder.NthWithMOnes(1, 0));
            Assert.AreEqual("100000 000000 000000 00", NewOrder.NthWithMOnes(20, 1));
            Assert.AreEqual("111111 111111 111111 111111", NewOrder.NthWithMOnes(1, 24));
            Assert.AreEqual("11001", NewOrder.NthWithMOnes( 8, 3));
            Assert.AreEqual("100111 001000 0", NewOrder.NthWithMOnes(1000, 5));
            Assert.AreEqual("110010 101011 010010 00010", NewOrder.NthWithMOnes(1000000, 10));
            Assert.AreEqual("100100 000101 100010 100000 100000", NewOrder.NthWithMOnes(5000000, 8));
            Assert.AreEqual("111111 111111 111000 000000 00000", NewOrder.NthWithMOnes(77558760, 15));
        }


        [TestMethod]
        public void TestEncode()
        {
            Assert.AreEqual("111111 00", NewOrder.Encode(252));
            Assert.AreEqual("111111", NewOrder.Encode(63));
            Assert.AreEqual("100000 000000 0", NewOrder.Encode(4096));
        }
    }
}
