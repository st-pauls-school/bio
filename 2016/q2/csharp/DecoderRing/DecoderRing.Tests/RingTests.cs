using DecoderRing.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoderRing.Tests
{
    [TestClass]
    public class RingTests
    {
        [TestMethod]
        public void TestGiven()
        {
            Ring r = new Ring(5);
            Assert.AreEqual("EJOTYD", r.FirstSix);
            Assert.AreEqual("EOYK", r.Encode("ABCD"));
        }

        [TestMethod]
        [DataRow(1, "A", "ABCDEF", "A")]
        [DataRow(2, "Z", "BDFHJL", "U")]
        [DataRow(3, "AZ", "CFILOR", "CC")]
        [DataRow(4, "BIO", "DHLPTX", "HRO")]
        [DataRow(10, "MZNOYW", "JTDOZL", "IJUVDT")]
        [DataRow(27, "ABCDEF", "ACFJOU", "AFODYG")]
        [DataRow(31, "ELEPHANT", "EKRZJV", "JPIOLVWE")]
        [DataRow(999999, "MOON", "MKAFSR", "YDVV")]
        public void TestMarkScheme(int n, string encode, string six, string expected)
        {
            Ring r = new Ring(n);
            Assert.AreEqual(six, r.FirstSix);
            Assert.AreEqual(expected, r.Encode(encode));

        }

        [TestMethod]
        public void TestQ2b()
        {
            Ring r = new Ring(1000000000);
            Assert.AreEqual("LKBXIY", r.FirstSix);

        }
    }
}
