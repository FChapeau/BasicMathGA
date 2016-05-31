using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BasicMathGA.Library;
using BasicMathGA.Library.Genetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathGA.Tests
{
    [TestClass]
    public class ChromosomeTests
    {

        [TestMethod]
        public void SpliceReturnsCorrectlySplicedChromosomeGivenMultipleOfFourPosition()
        {
            Chromosome c1 = new Chromosome();
            c1.Genes.Add(new Gene(PossibleValues.Multiply));
            c1.Genes.Add(new Gene(PossibleValues.Add));
            c1.Genes.Add(new Gene(PossibleValues.One));

            Chromosome c2 = new Chromosome();
            c2.Genes.Add(new Gene(PossibleValues.Multiply));
            c2.Genes.Add(new Gene(PossibleValues.Add));
            c2.Genes.Add(new Gene(PossibleValues.Five));

            Chromosome c3 = c1.Splice(c2, 8);

            Assert.AreEqual(c2, c3);
        }
    }
}
