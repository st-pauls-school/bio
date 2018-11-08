using Microsoft.VisualStudio.TestTools.UnitTesting;
using q3.Logic;

namespace q3.Tests
{
    [TestClass]
    public class UpsideDownTests
    {
        [TestMethod]
        public void TestUpsideDownResultGiven()
        {
            Assert.AreEqual(159u, new UpsideDown(11).Value);
        }

        [TestMethod]
        public void TestUpsideDownResultHidden()
        {
            Assert.AreEqual(159u, new UpsideDown(11).Value);
            Assert.AreEqual(5u, new UpsideDown(1).Value);
            Assert.AreEqual(9911u, new UpsideDown(100).Value);
            Assert.AreEqual(76543u, new UpsideDown(160).Value);
            Assert.AreEqual(4995116u, new UpsideDown(1234).Value);
            Assert.AreEqual(141555969u, new UpsideDown(8448).Value);
            Assert.AreEqual(987654321u, new UpsideDown(14659).Value);
            Assert.AreEqual(1398485825262179u, new UpsideDown(12345678).Value);
            Assert.AreEqual(13732787982132387379, new UpsideDown(987654321).Value);
        }

        [TestMethod]
        public void TestConstruct()
        {
            Assert.AreEqual(1235789u, UpsideDown.Construct(123, true));
            Assert.AreEqual(19u, UpsideDown.Construct(1, false));
        }

        [TestMethod]
        public void TestOffset()
        {
            Assert.AreEqual(99u, UpsideDown.Offset(81, 2));
            Assert.AreEqual(76u, UpsideDown.Offset(60, 2));
            Assert.AreEqual(999u, UpsideDown.Offset(729, 3));
            Assert.AreEqual(9999u, UpsideDown.Offset(6561, 4));
            Assert.AreEqual(499u, UpsideDown.Offset(324, 3));
        }
    }
}
