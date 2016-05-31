using System;
using BasicMathGA.Library;
using BasicMathGA.Library.Genetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathGA.Tests
{
    [TestClass]
    public class GeneTests
    {
        [TestMethod]
        public void SpliceSplicesCorrectly()
        {
            Gene left = new Gene(PossibleValues.Three);
            Gene right = new Gene(PossibleValues.Multiply);

            Gene spliced = left.Splice(right, 2);

            Assert.AreEqual(15, (int)spliced.getValue());
        }
    }
}
