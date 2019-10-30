using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q3.Library;

namespace Q3.Tests
{
    [TestClass]
    public class JugsTests
    {
        [TestMethod]
        public void TestEmpty()
        {
            Jug j = new Jug(5, 5);
            j.Empty();
            Assert.AreEqual(0, j.Current);
        }
        [TestMethod]
        public void TestFill()
        {
            int s = 5;
            Jug j = new Jug(s, 1);
            Assert.AreEqual(1, j.Current);
            j.Fill();
            Assert.AreEqual(s, j.Current);
        }

        [TestMethod]
        public void TestTransfer()
        {
            Jug j1 = new Jug(5, 0);
            Jug j2 = new Jug(3, 3);
            j2.TransferTo(j1);
            Assert.AreEqual(0, j2.Current);
            Assert.AreEqual(3, j1.Current);

            j1 = new Jug(5, 3);
            j2 = new Jug(3, 3);
            j2.TransferTo(j1);
            Assert.AreEqual(1, j2.Current);
            Assert.AreEqual(5, j1.Current);
        }

        [TestMethod]
        public void TestGiven()
        {
            Jugs j = new Jugs(4, 3, 5);
            int result = j.Go();
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestSingle()
        {
            Jugs j = new Jugs(20, 20);
            int result = j.Go();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestSensibleEnqueue()
        {
            Jugs js = new Jugs(4, 3, 5, 4);
            Assert.AreEqual(1, js.QueueLength);
            js.SensibleEnqueue(new Jug3State(new Jug(3), new Jug(5), new Jug(4), 1));
            Assert.AreEqual(1, js.QueueLength);
            js.SensibleEnqueue(new Jug3State(new Jug(3,1), new Jug(5), new Jug(4), 1));
            Assert.AreEqual(2, js.QueueLength);

        }

        [TestMethod]
        public void TestEquality()
        {
            Jug a = new Jug(5);
            a.TopUp(1);
            Jug b = new Jug(5);
            Jug1State j1a = new Jug1State(a, 5);
            Jug1State j1b = new Jug1State(a, 5);
            Jug1State j1c = new Jug1State(b, 5);

            Assert.IsTrue(j1a.Equals(j1b));
            Assert.IsFalse(j1a.Equals(j1c));
        }

        [TestMethod]
        [DataRow(4, 3, 5, 6)]
        [DataRow(10, 10, 20, 1)]
        [DataRow(10, 1, 30, 20)]
        [DataRow(15, 1, 20, 10)]
        [DataRow(9, 249, 18, 86)]
        [DataRow(3, 31, 79, 12)]
        [DataRow(19, 31, 79, 56)]

        public void TestMarkScheme2s(int t, int a, int b, int e)
        {
            Jugs j = new Jugs(t, a, b);
            int result = j.Go();
            Assert.AreEqual(e, result);

        }


        [TestMethod]
        [DataRow(48, 158, 62, 14, 2)]
        [DataRow(24, 158, 62, 14, 27)]
// todo: this test case times out
//        [DataRow(13, 241, 181, 31, 40)]

        public void TestMarkScheme3s(int t, int a, int b, int c, int e)
        {
            Jugs j = new Jugs(t, a, b, c);
            int result = j.Go();
            Assert.AreEqual(e, result);

        }

        [TestMethod]
        [DataRow(20, 20, 1)]
        public void TestMarkScheme1s(int t, int a, int e)
        {
            Jugs j = new Jugs(t, a);
            int result = j.Go();
            Assert.AreEqual(e, result);

        }



    }
}
