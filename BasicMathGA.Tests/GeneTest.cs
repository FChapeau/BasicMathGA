using System;
using System.Collections;
using BasicMathGA.Genetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathGA.Tests
{
    [TestClass]
    public class GeneTest
    {
        [TestMethod]
        public void AsCharReturnsCorrectCharacter()
        {
            Gene totest = new Gene(3);

            Assert.AreEqual('4', totest.AsChar());
        }

        [TestMethod]
        public void AsCharThrowsExceptionGivenOutOfBoundsValue()
        {
            Gene totest = new Gene(14);

            try
            {
                totest.AsChar();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                Assert.AreEqual(1,1);
            }
        }

        [TestMethod]
        public void AsIntReturnsCorrectValueAsInt()
        {
            Gene totest = new Gene(4);
            Assert.AreEqual(4,totest.AsInt());
        }



        [TestMethod]
        public void IsOperandReturnsCorrectStatusGivenOperandGene()
        {
            Gene totest = new Gene('+');

            Assert.AreEqual(true, totest.IsOperand());
        }

        [TestMethod]
        public void IsDigitReturnsCorrectStatusGivenDigitGene()
        {
            Gene totest = new Gene('4');
            Assert.AreEqual(true,totest.IsDigit());
        }

        [TestMethod]
        public void IsDigitReturnsCorrectStatusGivenNonDigitGene()
        {
            Gene totest = new Gene('+');
            Assert.AreEqual(false,totest.IsDigit());
        }
    }
}
