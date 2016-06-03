using System;
using System.Linq;
using BasicMathGA.Library;
using BasicMathGA.Library.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathGA.Tests
{
    [TestClass]
    public class EquationTests
    {
        [TestMethod]
        public void CalculateAddTwoValuesGivenCleanValues()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));
            equation.MathComponents.Add(new MathComponent(2));

            float answer = equation.Calculate();

            Assert.AreEqual(4f, answer);
        }

        [TestMethod]
        public void CalculateSubstractsTwoValuesGivenCleanValues()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(4));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Substract));
            equation.MathComponents.Add(new MathComponent(2));

            float answer = equation.Calculate();

            Assert.AreEqual(2f, answer);
        }

        [TestMethod]
        public void CalculateMultipliesTwoValuesGivenCleanValues()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(2));

            float answer = equation.Calculate();

            Assert.AreEqual(4f, answer);
        }

        [TestMethod]
        public void CalculateDividesTwoValuesGivenCleanValues()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(4));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Divide));
            equation.MathComponents.Add(new MathComponent(2));

            float answer = equation.Calculate();

            Assert.AreEqual(2f, answer);
        }

        [TestMethod]
        public void CalculateHandlesMultipleAdditionsInARow()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));
            equation.MathComponents.Add(new MathComponent(2));

            float answer = equation.Calculate();

            Assert.AreEqual(6f, answer);
        }

        [TestMethod]
        public void CalculateHandlesMixedOperations()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(4));

            float answer = equation.Calculate();

            Assert.AreEqual(10f, answer);
        }

        [TestMethod]
        public void CleanupClearsLeadingOperands()
        {
            Equation equation = new Equation();

            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(4));

            equation = equation.Cleanup(equation);

            Assert.AreEqual(false, equation.MathComponents.First().isOperand());
        }

        [TestMethod]
        public void CleanupClearsTrailingOperands()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(4));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));

            equation = equation.Cleanup(equation);

            Assert.AreEqual(false, equation.MathComponents.Last().isOperand());
        }

        [TestMethod]
        public void CleanupClearsConsecutiveOperands()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(4));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Add));

            equation = equation.Cleanup(equation);

            Assert.AreEqual(false, equation.MathComponents[2].isOperand());
        }

        [TestMethod]
        public void CleanupClearsInvalidCharacters()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Invalid1));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Invalid2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Eight));

            equation = equation.Cleanup(equation);

            Assert.AreEqual(3, equation.MathComponents.Count);
        }

        [TestMethod]
        public void CleanupClearsInvalidCharactersSurroundingConsecutiveOperands()
        {
            Equation equation = new Equation();
            equation.MathComponents.Add(new MathComponent(2));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Invalid1));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Multiply));
            equation.MathComponents.Add(new MathComponent(PossibleValues.Invalid2));
            equation.MathComponents.Add(new MathComponent(2));

            equation = equation.Cleanup(equation);

            Assert.AreEqual(3, equation.MathComponents.Count);
        }
    }
}
