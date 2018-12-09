using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using q1.Logic;

namespace q1.Tests
{
    [TestClass]
    public class ColouredTriangleTests
    {
        [TestMethod]
        public void TestQ1()
        {
            Assert.AreEqual('B', ColouredTriangles.Q1("RG"));
            Assert.AreEqual('B', ColouredTriangles.Q1("GR"));
            Assert.AreEqual('R', ColouredTriangles.Q1("R"));
            Assert.AreEqual('G', ColouredTriangles.Q1("GG"));
            Assert.AreEqual('R', ColouredTriangles.Q1("RRR"));
            Assert.AreEqual('G', ColouredTriangles.Q1("RGB"));
            Assert.AreEqual('B', ColouredTriangles.Q1("BGGRB"));
            Assert.AreEqual('G', ColouredTriangles.Q1("BRGRBG"));
            Assert.AreEqual('G', ColouredTriangles.Q1("GGGGGG"));
            Assert.AreEqual('B', ColouredTriangles.Q1("GRBRBRBRBR"));
            Assert.AreEqual('R', ColouredTriangles.Q1("RBGBGBGBGR"));
        }
    }
}
