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
        public void CleanupRemovesConsecutiveOperands()
        {
            Chromosome chromosome = new Chromosome("1++2");
            Chromosome totest = chromosome.GetCleanGenome();
            Assert.AreEqual(totest.ToString(), "1+2");
        }

        [TestMethod]
        public void CleanupRemovesConsecutiveNumbers()
        {
            Chromosome chromosome = new Chromosome("11+2");
            Chromosome totest = chromosome.GetCleanGenome();
            Assert.AreEqual(totest.ToString(), "1+2");
        }

        [TestMethod]
        public void CleanupRemovesLeadingOperands()
        {
            Chromosome chromosome = new Chromosome("+1+2");
            Chromosome totest = chromosome.GetCleanGenome();

            Assert.AreEqual(totest.ToString(), "1+2");
        }

        [TestMethod]
        public void CleanupRemvoesTrailingOperands()
        {
            Chromosome chromosome = new Chromosome("1+2+");
            Chromosome totest = chromosome.GetCleanGenome();

            Assert.AreEqual(totest.ToString(), "1+2");
        }
        [TestMethod]
        public void CleanupRemovesConsecutiveTrailingOperands()
        {
            Chromosome chromosome = new Chromosome("1+2+++");
            Chromosome totest = chromosome.GetCleanGenome();

            Assert.AreEqual(totest.ToString(), "1+2");
        }

        [TestMethod]
        public void CleanupRemovesConsecutiveLeadingOperands()
        {
            Chromosome chromosome = new Chromosome("+++1+2");
            Chromosome totest = chromosome.GetCleanGenome();

            Assert.AreEqual(totest.ToString(), "1+2");
        }

        [TestMethod]
        public void CleanupRemovesUnsupportedGenes()
        {
            Chromosome chromosome = new Chromosome("1+2");
            chromosome.Genome.Add(new Gene(15));
            Chromosome totest = chromosome.GetCleanGenome();

            Assert.AreEqual(totest.ToString(), "1+2");
        }
    }
}
