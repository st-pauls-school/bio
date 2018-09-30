using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q2.Logic;

namespace Q2.Tests
{
    [TestClass]
    public class DecoderRingTests
    {
        [TestMethod]
        public void TestFirstSix()
        {
            Assert.AreEqual("DHLPTX", new DecoderRing(4).FirstSix);
            Assert.AreEqual("EJOTYD", new DecoderRing(5).FirstSix);
            Assert.AreEqual("FLRXDK", new DecoderRing(6).FirstSix);
        }

        [TestMethod]
        public void TestEncode()
        {
            var dr = new DecoderRing(5);
            Assert.AreEqual('E', dr.Encode('A'));
            Assert.AreEqual('O', dr.Encode('B'));
            Assert.AreEqual('Y', dr.Encode('C'));
            Assert.AreEqual('K', dr.Encode('D'));

            dr.Reset();
            Assert.AreEqual("EOYK", dr.Encode("ABCD"));
        }

        [TestMethod]
        public void Test1()
        {
            var dr = new DecoderRing(5);
            Assert.AreEqual("EJOTYD", dr.FirstSix);
            Assert.AreEqual("EOYK", dr.Encode("ABCD"));
        }
        [TestMethod]
        public void Test2()
        {
            var dr = new DecoderRing(1);
            Assert.AreEqual("ABCDEF", dr.FirstSix);
            Assert.AreEqual("A", dr.Encode("A"));
        }
        [TestMethod]
        public void Test3()
        {
            var dr = new DecoderRing(2);
            Assert.AreEqual("BDFHJL", dr.FirstSix);
            Assert.AreEqual("U", dr.Encode("Z"));
        }
        [TestMethod]
        public void Test4()
        {
            var dr = new DecoderRing(3);
            Assert.AreEqual("CFILOR", dr.FirstSix);
            Assert.AreEqual("CC", dr.Encode("AZ"));
        }
        [TestMethod]
        public void Test5()
        {
            var dr = new DecoderRing(4);
            Assert.AreEqual("DHLPTX", dr.FirstSix);
            Assert.AreEqual("HRO", dr.Encode("BIO"));
        }
        [TestMethod]
        public void Test6()
        {
            var dr = new DecoderRing(10);
            Assert.AreEqual("JTDOZL", dr.FirstSix);
            Assert.AreEqual("IJUVDT", dr.Encode("MZNOYW"));
        }
        [TestMethod]
        public void Test7()
        {
            var dr = new DecoderRing(27);
            Assert.AreEqual("ACFJOU", dr.FirstSix);
            Assert.AreEqual("AFODYG", dr.Encode("ABCDEF"));
        }
        [TestMethod]
        public void Test8()
        {
            var dr = new DecoderRing(31);
            Assert.AreEqual("EKRZJV", dr.FirstSix);
            Assert.AreEqual("JPIOLVWE", dr.Encode("ELEPHANT"));
        }
        [TestMethod]
        public void Test9()
        {
            var dr = new DecoderRing(999999);
            Assert.AreEqual("MKAFSR", dr.FirstSix);
            Assert.AreEqual("YDVV", dr.Encode("MOON"));
        }

        [TestMethod]
        public void TestPartD()
        {
            Assert.AreEqual(1260, DecoderRing.Cycler("ABCD"));
        }
    }
}