using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migration.Lib;
using System.Collections.Generic;

namespace Migration.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestGridGiven()
        {
            Grid g = new Grid(8, new List<int> { 0 }, 6);
            g.Go(false);
            Assert.AreEqual("00100//01210//00100//00000//00000//", g.State());

        }

        [TestMethod]
        public void TestGrid1()
        {
            Grid g = new Grid(8, new List<int> { 0 }, 4);
            g.Go(false);
            Assert.AreEqual("00100//01010//00100//00000//00000//", g.State());
        }

        [TestMethod]
        public void TestGrid2()
        {
            Grid g = new Grid(6, new List<int> { 3,5,11 }, 18);
            g.Go(false);
            Assert.AreEqual("11110//11121//00111//10010//11001//", g.State());
        }

        [TestMethod]
        public void TestGrid3()
        {
            Grid g = new Grid(12, new List<int> { 1, 24 }, 7);
            g.Go(false);
            Assert.AreEqual("00000//01100//11010//01100//00000//", g.State());
        }

        [TestMethod]
        public void TestGrid4()
        {
            Grid g = new Grid(7, new List<int> { 2, 9, 14 }, 23);
            g.Go(false);
            Assert.AreEqual("02120//21012//02220//01310//00100//", g.State());
        }

        [TestMethod]
        public void TestGrid5()
        {
            Grid g = new Grid(1, new List<int> { 4, 16, 4, 1 }, 61);
            g.Go(false);
            Assert.AreEqual("01133//12003//10000//30003//33033//", g.State());
        }

        [TestMethod]
        public void TestGrid6()
        {
            Grid g = new Grid(18, new List<int> { 2,2,24,23,4 }, 76);
            g.Go(false);
            Assert.AreEqual("13331//31213//32323//31313//13331//", g.State());
        }

        [TestMethod]
        public void TestGrid7()
        {
            Grid g = new Grid(3, new List<int> { 2, 3, 5, 7, 11, 13 }, 150);
            g.Go(false);
            Assert.AreEqual("23232//32223//22222//32223//23232//", g.State());
        }

        [TestMethod]
        public void TestGrid8()
        {
            Grid g = new Grid(3, new List<int> { 2, 3, 5, 7, 11, 13 }, 999);
            g.Go(false);
            Assert.AreEqual("23230//22322//32321//31122//03313//", g.State());
        }
    }
}
