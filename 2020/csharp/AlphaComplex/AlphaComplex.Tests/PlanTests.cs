using System.Collections.Generic;
using AlphaComplex.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlphaComplex.Tests
{
    [TestClass]
    public class PlanTests
    {
        [TestMethod]
        public void TestGiven()
        {
            Plan p = new Plan("A");
            CollectionAssert.AreEqual(new List<string> { "BC", "A", "A" }, p.Connections);
            Assert.AreEqual("B", p.Moves(1));
            Assert.AreEqual("B", p.Moves(2));
        }

        [TestMethod]
        public void TestMarkScheme2()
        {
            Plan plan = new Plan("C");
            CollectionAssert.AreEqual(new List<string> { "C", "C", "AB" }, plan.Connections);
            Assert.AreEqual("B", plan.Moves(4));
            Assert.AreEqual("B", plan.Moves(8));
        }

        [TestMethod]
        public void TestMarkScheme3()
        {
            Plan plan = new Plan("BC");
            CollectionAssert.AreEqual(new List<string> { "B", "AC", "BD", "C" }, plan.Connections);
            Assert.AreEqual("C", plan.Moves(4));
            Assert.AreEqual("D", plan.Moves(9));
        }

        [TestMethod]
        public void TestMarkScheme4()
        {
            Plan plan = new Plan("BBACC");
            CollectionAssert.AreEqual(new List<string> { "BC", "ADE", "AFG", "B", "B", "C", "C" }, plan.Connections);
            Assert.AreEqual("F", plan.Moves(10));
            Assert.AreEqual("G", plan.Moves(1010));
        }

        [TestMethod]
        public void TestMarkScheme5()
        {
            Plan plan = new Plan("ABCD");
            CollectionAssert.AreEqual(new List<string> { "BE", "AC", "BD", "CF", "A", "D" }, plan.Connections);
            Assert.AreEqual("C", plan.Moves(50));
            Assert.AreEqual("D", plan.Moves(51));
        }

        [TestMethod]
        public void TestMarkScheme6()
        {
            Plan plan = new Plan("FEDC");
            CollectionAssert.AreEqual(new List<string> { "F", "E", "DF", "CE", "BD", "AC" }, plan.Connections);
            Assert.AreEqual("C", plan.Moves(2020));
            Assert.AreEqual("B", plan.Moves(876543));
        }

        [TestMethod]
        public void TestMarkScheme7()
        {
            Plan plan = new Plan("AABGB");
            CollectionAssert.AreEqual(new List<string> { "BCD", "AFG", "A", "A", "G", "B", "BE" }, plan.Connections);
            Assert.AreEqual("A", plan.Moves(5000));
            Assert.AreEqual("B", plan.Moves(9999));
        }
        [TestMethod]
        public void TestMarkScheme8()
        {
            Plan plan = new Plan("CDCDCD");
            CollectionAssert.AreEqual(new List<string> { "C", "D", "ADEG", "BCFH", "C", "D", "C", "D" }, plan.Connections);
            Assert.AreEqual("D", plan.Moves(2020));
            Assert.AreEqual("H", plan.Moves(876543));
        }
        [TestMethod]
        public void TestMarkScheme9()
        {
            Plan plan = new Plan("FFFFFFFF");
            CollectionAssert.AreEqual(new List<string> { "F", "F", "F", "F", "F", "ABCDEGHIJ", "F", "F", "F", "F" }, plan.Connections);
            Assert.AreEqual("J", plan.Moves(512));
            Assert.AreEqual("A", plan.Moves(1022));
        }
    }
}
