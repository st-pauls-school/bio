using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migration.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migration.Tests
{
    [TestClass]
    public class CoOrdinateTests
    {
        [TestMethod]
        public void TestCoordinate()
        {
            CoOrdinate co = new CoOrdinate(2, 2);
            Assert.AreEqual(12, co.Index);
            CoOrdinate co2 = new CoOrdinate(2, 2);
            Assert.IsTrue(co.Equals(co2));
            Assert.IsTrue(co.Equals(CoOrdinate.FromIndex(12)));
        }

        [TestMethod]
        public void TestExtremes()
        {
            CoOrdinate first = new CoOrdinate(0, 0);
            CoOrdinate last = new CoOrdinate(4, 4);
            Assert.IsTrue(first.Equals(CoOrdinate.FromIndex(0)));
            Assert.IsTrue(last.Equals(CoOrdinate.FromIndex(24)));
        }

        [TestMethod]
        public void TestOutside()
        {
            Assert.AreEqual(-1, new CoOrdinate(-1, -1).Index);
            Assert.AreEqual(-1, new CoOrdinate(3, -1).Index);
            Assert.AreEqual(-1, new CoOrdinate(6, -1).Index);

            Assert.AreEqual(-1, new CoOrdinate(-1, 1).Index);
            Assert.AreEqual(-1, new CoOrdinate(6, 3).Index);

            Assert.AreEqual(-1, new CoOrdinate(-1, 6).Index);
            Assert.AreEqual(-1, new CoOrdinate(3, 5).Index);
            Assert.AreEqual(-1, new CoOrdinate(6, 7).Index);
        }
    }
}
