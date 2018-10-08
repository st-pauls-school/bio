using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace q3.Tests
{
    [TestClass]
    public class MovieMagicTests
    {
        [TestMethod]
        public void TestValidateDecreasing()
        {
            Assert.IsTrue(MovieMagic.ValidateDecreasing<int>(new List<IList<int>> { new List<int> { 2, 4 }, new List<int> { 1 } }));
            Assert.IsFalse(MovieMagic.ValidateDecreasing<int>(new List<IList<int>> { new List<int> { 1 }, new List<int> { 2, 4 } }));
        }

        [TestMethod]
        public void TestValidateWithinRange()
        {
            Assert.IsTrue(MovieMagic.ValidateWithinRange<int>(new List<IList<int>> { new List<int> { 2, 4 }, new List<int> { 1 } }, new List<int> { 3, 2 }));
            Assert.IsFalse(MovieMagic.ValidateWithinRange<int>(new List<IList<int>> { new List<int> { 1, 2, 3 }, new List<int> { 2, 4 } }, new List<int> { 2, 1 }));
        }

        [TestMethod]
        public void GivenTests()
        {
            Assert.AreEqual(5, new MovieMagic(2, new List<int> { 3, 2 }).Options);
            Assert.AreEqual(1, new MovieMagic(1, new List<int> { 8 }).Options);
            Assert.AreEqual(1, new MovieMagic(8, new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 }).Options);
            Assert.AreEqual(42, new MovieMagic(3, new List<int> { 3, 3, 3 }).Options);
            Assert.AreEqual(990, new MovieMagic(5, new List<int> { 3, 3, 2, 2, 1 }).Options);
            Assert.AreEqual(2640, new MovieMagic(4, new List<int> { 4, 4, 2, 2 }).Options);
            Assert.AreEqual(3432, new MovieMagic(8, new List<int> { 8, 1, 1, 1, 1, 1, 1, 1 }).Options);
            Assert.AreEqual(292864, new MovieMagic(5, new List<int> { 5, 4, 3, 2, 1 }).Options);
            Assert.AreEqual(630630, new MovieMagic(6, new List<int> { 5, 4, 2, 2, 2, 1 }).Options);

        }
    }
}
