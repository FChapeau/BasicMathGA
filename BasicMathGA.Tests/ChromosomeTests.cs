using System;
using System.Collections;
using BasicMathGA.Genetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathGA.Tests
{
    [TestClass]
    public class ChromosomeTests
    {
        [TestMethod]
        public void CleanupTest1()
        {
            Chromosome chromosome = new Chromosome("1++2");
            Chromosome totest = chromosome.GetCleanGenome();
            Assert.AreEqual(totest.ToString(), "1+2");
        }
    }
}
