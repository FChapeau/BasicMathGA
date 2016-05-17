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

        [TestMethod]
        public void CalculateAddsTwoNumbers()
        {
            Chromosome chromosome = new Chromosome("1+2");
            float answer = chromosome.Calculate();
            Assert.AreEqual(3f, answer);
        }

        [TestMethod]
        public void CalculateSubstractsTwoNumbers()
        {
            Chromosome chromosome = new Chromosome("2-1");
            float answer = chromosome.Calculate();
            Assert.AreEqual(1f, answer);
        }

        [TestMethod]
        public void CalculateMultipliesTwoNumbers()
        {
            Chromosome chromosome = new Chromosome("2*2");
            float answer = chromosome.Calculate();
            Assert.AreEqual(4f, answer);
        }

        [TestMethod]
        public void CalculateDividesTwoNumbers()
        {
            Chromosome chromosome = new Chromosome("4/2");
            float answer = chromosome.Calculate();
            Assert.AreEqual(2f, answer);
        }

        [TestMethod]
        public void CalculateCanHandleNonIntegerDivision()
        {
            Chromosome chromosome = new Chromosome("1/2");
            float answer = chromosome.Calculate();
            Assert.AreEqual(0.5f, answer);
        }

        [TestMethod]
        public void CalculateCanHandleMultipleAditionsInARow()
        {
            Chromosome chromosome = new Chromosome("1+2+1");
            float answer = chromosome.Calculate();
            Assert.AreEqual(4f, answer);
        }
    }
}
