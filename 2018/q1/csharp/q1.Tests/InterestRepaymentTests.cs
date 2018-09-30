using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using q1logic;

namespace q1.Tests
{
    [TestClass]
    public class InterestRepaymentTests
    {
        [TestMethod]
        public void TestCalculate1()
        {
            var ir = new InterestRepayment(10, 10);
            var calculation = ir.Calculate(10000);
            Assert.AreEqual(6000, calculation.Item1);
            Assert.AreEqual(5000, calculation.Item2);
            calculation = ir.Calculate(6000);
            Assert.AreEqual(1600, calculation.Item1);
            Assert.AreEqual(5000, calculation.Item2);
            calculation = ir.Calculate(1600);
            Assert.AreEqual(0, calculation.Item1);
            Assert.AreEqual(1760, calculation.Item2);

            Assert.AreEqual(117.6m, ir.TotalRepayment);
        }
        [TestMethod]
        public void TestCalculate2()
        {
            var ir = new InterestRepayment(21, 46);
            var calculation = ir.Calculate(10000);
            Assert.AreEqual(6534, calculation.Item1);
            Assert.AreEqual(5566, calculation.Item2);
            calculation = ir.Calculate(6534);
            Assert.AreEqual(2907, calculation.Item1);
            Assert.AreEqual(5000, calculation.Item2);
            calculation = ir.Calculate(2907);
            Assert.AreEqual(0, calculation.Item1);
            Assert.AreEqual(3518, calculation.Item2);

            Assert.AreEqual(140.84m, ir.TotalRepayment);
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(116.55m, new InterestRepayment(10, 50).TotalRepayment);
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(100m, new InterestRepayment(0, 0).TotalRepayment);
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(100m, new InterestRepayment(0, 70).TotalRepayment);
        }
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(492.17m, new InterestRepayment(49, 0).TotalRepayment);
        }
        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(170m, new InterestRepayment(70, 100).TotalRepayment);
        }
        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual(143.46m, new InterestRepayment(21, 21).TotalRepayment);
        }
        [TestMethod]
        public void Test7()
        {
            Assert.AreEqual(180.8m, new InterestRepayment(31, 31).TotalRepayment);
        }
        [TestMethod]
        public void Test8()
        {
            Assert.AreEqual(152.22m, new InterestRepayment(24, 30).TotalRepayment);
        }
        [TestMethod]
        public void Test9()
        {
            Assert.AreEqual(214.48m, new InterestRepayment(76, 79).TotalRepayment);
        }
        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual(317.74m, new InterestRepayment(98, 69).TotalRepayment);
        }
        [TestMethod]
        public void Test11()
        {
            Assert.AreEqual(287.57m, new InterestRepayment(61, 52).TotalRepayment);
        }
        [TestMethod]
        public void Test12()
        {
            Assert.AreEqual(207.22m, new InterestRepayment(36, 37).TotalRepayment);
        }
        [TestMethod]
        public void Test13()
        {
            Assert.AreEqual(6755.51m, new InterestRepayment(61, 38).TotalRepayment);
        }
        [TestMethod]
        public void Test14()
        {
            Assert.AreEqual(34606.34m, new InterestRepayment(85, 46).TotalRepayment);
        }

        [TestMethod]
        public void TestQ2()
        {
            Assert.AreEqual(5, new InterestRepayment(43, 46).Steps);
        }
    }
}
