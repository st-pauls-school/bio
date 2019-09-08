using Microsoft.VisualStudio.TestTools.UnitTesting;
using q2.Lib;

namespace q2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAccepted()
        {
            Assert.AreEqual("Accepted", PasswordChecker.Check("A"));
            Assert.AreEqual("Accepted", PasswordChecker.Check("LONDON"));
            Assert.AreEqual("Accepted", PasswordChecker.Check("BIOGRAPHY"));
            Assert.AreEqual("Accepted", PasswordChecker.Check("APRICOT"));
        }

        [TestMethod]
        public void TestMethodRejected()
        {
            Assert.AreEqual("Rejected", PasswordChecker.Check("AA"));
            Assert.AreEqual("Rejected", PasswordChecker.Check("QUININE"));
            Assert.AreEqual("Rejected", PasswordChecker.Check("RINGRING"));
            Assert.AreEqual("Rejected", PasswordChecker.Check("COMMITTEE"));
        }
    }
}
