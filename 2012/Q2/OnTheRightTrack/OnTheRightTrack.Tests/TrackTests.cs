using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnTheRightTrack.Lib;

namespace OnTheRightTrack.Tests
{
    [TestClass]
    public class TrackTests
    {
        [TestMethod]
        public void TestGivenRoute1()
        {
            Track t = new Track("GHIJKL");
            Assert.AreEqual("FA", t.Journey('A', 'E', 6));
        }

        [TestMethod]
        public void TestGivenRoute2()
        {
            Track t = new Track("GHIJKL");
            Assert.AreEqual("VP", t.Journey('A', 'E', 100));
        }

        [TestMethod]
        [DataRow("ABCDEF", 'H', 'P', 1, "PV")]
        [DataRow("ABCDEF", 'P', 'H', 1, "HB")]
        [DataRow("AEFMNO", 'D', 'K',13, "SK")]
        [DataRow("AEFMNS", 'D', 'K',13, "SJ")]
        [DataRow("ABCDEF", 'G', 'O',100, "QI")]
        [DataRow("FJLMQU", 'G', 'O',100, "RJ")]
        [DataRow("FDEGNQ", 'A', 'E',9876, "WQ")]
        public void TestMarkScheme(string flipflops, char f, char t, int s, string e)
        {
            Track tr = new Track(flipflops);
            Assert.AreEqual(e, tr.Journey(f, t, s));
        }
    }
}
