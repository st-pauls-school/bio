using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q3Class;

namespace Q3Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSample()
        {
            IQuestion3 q3 = new Question3();
            Assert.AreEqual(3, q3.Run(2, 3, 4, 3));
        }
        [TestMethod]
        public void TestMethodExample()
        {
            Assert.AreEqual(4, new Question3().Run(2, 3, 4, 4));
            Assert.AreEqual(1, new Question3().Run(2, 3, 4, 2));
            Assert.AreEqual(1, new Question3().Run(2, 3, 4, 5));
            Assert.AreEqual(1, new Question3().Run(2, 3, 4, 6));
        }
    }
}
