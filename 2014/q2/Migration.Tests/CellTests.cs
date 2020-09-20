using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migration.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migration.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void TestCell()
        {
            Cell c = new Cell(new CoOrdinate(2,2));
            Assert.IsFalse(c.HaveNeighbours);
            List<CoOrdinate> neighbours = new List<CoOrdinate> { new CoOrdinate(2, 1), new CoOrdinate(2, 3), new CoOrdinate(1, 2), new CoOrdinate(3, 2) };
            List<CoOrdinate> res = c.IdentifyNeighbours().ToList();
            // this is failing, despite implementing Equals and GetHashCode 
            // CollectionAssert.AreEquivalent(neighbours, res);
            IList<Cell> cs = neighbours.Select(co => new Cell(co)).ToList();
            c.SetNeighbours(cs);
            Assert.IsTrue(c.HaveNeighbours);
            Assert.AreEqual(0, c.Population);
            c.Increment();
            Assert.AreEqual(1, c.Population);
            c.Increment();
            Assert.AreEqual(2, c.Population);
            c.Increment();
            Assert.AreEqual(3, c.Population);
            c.Increment();
            Assert.AreEqual(4, c.Population);
            c.Disperse();
            Assert.AreEqual(0, c.Population);
            foreach(Cell n in cs)
                Assert.AreEqual(1, n.Population);
        }
    }
}
