using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiblioJdr;

namespace TestUnit
{
    [TestClass]
    public class TestDice
    {
        [TestMethod]
        public void TestlancerDice()
        {
            Assert.AreEqual(1,Dice.lancerDe(1));
        }
    }
}
