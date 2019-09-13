using Microsoft.VisualStudio.TestTools.UnitTesting;
using q3;

namespace q3.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGiven()
        {
            Assert.AreEqual(6, q3.Program.Calculator(7, 3));
        }

        [TestMethod]
        public void TestMethodMarkScheme()
        {
            Assert.AreEqual(0, q3.Program.Calculator(33, 1));
            Assert.AreEqual(0, q3.Program.Calculator(101, 4));
            Assert.AreEqual(1, q3.Program.Calculator(8, 7));
            Assert.AreEqual(1, q3.Program.Calculator(28, 1));
            Assert.AreEqual(8, q3.Program.Calculator(18, 2));
            Assert.AreEqual(22, q3.Program.Calculator(9, 4));
            Assert.AreEqual(191, q3.Program.Calculator(36, 3));
            Assert.AreEqual(2075, q3.Program.Calculator(33, 4));
            Assert.AreEqual(40000, q3.Program.Calculator(83, 5));
            Assert.AreEqual(1402584, q3.Program.Calculator(73, 6));
            Assert.AreEqual(515725220, q3.Program.Calculator(95, 8));

        }
    }
}
