using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMathGA.Library;
using BasicMathGA.Library.Genetics;
using BasicMathGA.Library.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathGA.Tests
{
    [TestClass]
    public class MathComponentsTests
    {
        [TestMethod]
        public void EqualsReturnsFalseGivenTwoDifferentObjects()
        {
            MathComponent mc1 = new MathComponent(PossibleValues.Add);

            Assert.AreEqual(false, mc1.Equals(new Chromosome()));
        }

        [TestMethod]
        public void EqualsReturnsTrueDivenTwoEqualEnumMathComponents()
        {
            MathComponent mc1 = new MathComponent(PossibleValues.Add);
            MathComponent mc2 = new MathComponent(PossibleValues.Add);

            Assert.AreEqual(true,mc1.Equals(mc2));
        }

        [TestMethod]
        public void EqualsReturnsTrueDivenTwoFloatEnumMathComponents()
        {
            MathComponent mc1 = new MathComponent(2f);
            MathComponent mc2 = new MathComponent(2f);

            Assert.AreEqual(true, mc1.Equals(mc2));
        }

        [TestMethod]
        public void EqualsReturnsFalseGivenTwoDifferentEnumMathComponents()
        {
            MathComponent mc1 = new MathComponent(PossibleValues.Add);
            MathComponent mc2 = new MathComponent(PossibleValues.Substract);

            Assert.AreEqual(false, mc1.Equals(mc2));
        }

        [TestMethod]
        public void EqualsReturnsTrueGivenEnumMathComponentAndEnumGene()
        {
            MathComponent mc1 = new MathComponent(PossibleValues.Add);
            Gene g1 = new Gene(PossibleValues.Add);

            Assert.AreEqual(true, mc1.Equals(g1));
        }
    }
}
