using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace q1.Tests
{
    [TestClass]
    public class Q1UnitTests
    {
        [TestMethod]
        public void TestIsValid()
        {
            Assert.IsTrue(isbn.IsValid("156881111X"));
        }

        [TestMethod]
        public void TestMissing()
        {
            Assert.AreEqual('1', new isbn("15688?111X").Missing);
        }

        [TestMethod]
        public void TestMissingSecret()
        {
            Assert.AreEqual('3', new isbn("812071988?").Missing);
            Assert.AreEqual('X', new isbn("020161586?").Missing);
            Assert.AreEqual('0', new isbn("?131103628").Missing);
            Assert.AreEqual('1', new isbn("?86046324X").Missing);
            Assert.AreEqual('5', new isbn("1?68811306").Missing);
            Assert.AreEqual('4', new isbn("951?451570").Missing);
            Assert.AreEqual('2', new isbn("0393020?31").Missing);
            Assert.AreEqual('9', new isbn("01367440?5").Missing);
        }


        [TestMethod]
        public void TestQ1bA()
        {
            Assert.IsTrue(isbn.IsValid("0972311900"));
        }

        [TestMethod]
        public void TestQ1bB()
        {
            Assert.IsTrue(isbn.IsValid("3540678654"));
        }

        [TestMethod]
        public void TestQ1bC()
        {
            Assert.IsTrue(isbn.IsValid("9514451570"));
        }

        [TestMethod]
        public void TestQ1bD()
        {
            Assert.IsTrue(isbn.IsValid("013674409X"));
        }


    }
}
