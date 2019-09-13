using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q1.Library;

namespace Q1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAnagramCheckerGiven()
        {
            Assert.AreEqual("Not Anagrams", Anagrams.Checker("SUMMER", "RESUME"));
            Assert.AreEqual("Anagrams", Anagrams.Checker("GADGET", "TAGGED"));
        }

        [TestMethod]
        public void TestAnagramCheckerMine()
        {
            Assert.AreEqual("Anagrams", Anagrams.Checker("PRESBYTERIANS", "BRITNEYSPEARS"));
            Assert.AreEqual("Anagrams", Anagrams.Checker("ORCHESTRA", "CARTHORSE"));
        }

        [TestMethod]
        public void TestMarkSchemeYes()
        {
            Assert.AreEqual("Anagrams", Anagrams.Checker("OLYMPIAD", "OLYMPIAD"));
            Assert.AreEqual("Anagrams", Anagrams.Checker("LEMON", "MELON"));
            Assert.AreEqual("Anagrams", Anagrams.Checker("COVERSLIP", "SLIPCOVER"));
            Assert.AreEqual("Anagrams", Anagrams.Checker("TEARDROP", "PREDATOR"));
            Assert.AreEqual("Anagrams", Anagrams.Checker("ABBCCCDDD", "DDDCCCBBA"));
        }

        [TestMethod]
        public void TestMarkSchemeNo()
        {
            Assert.AreEqual("Not Anagrams", Anagrams.Checker("I", "A"));
            Assert.AreEqual("Not Anagrams", Anagrams.Checker("FORTY", "FORT"));
            Assert.AreEqual("Not Anagrams", Anagrams.Checker("ONE", "SIX"));
            Assert.AreEqual("Not Anagrams", Anagrams.Checker("GREEN", "RANGE"));
            Assert.AreEqual("Not Anagrams", Anagrams.Checker("ABBCCCDDD", "AAABBBCCD"));
        }
    }
}
