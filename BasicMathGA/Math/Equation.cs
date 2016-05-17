using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;

namespace BasicMathGA.Math
{
    public class Equation
    {
        public List<MathComponent> MathComponents { get; set; }

        public Equation()
        {
            MathComponents = new List<MathComponent>();
        }

        public float Calculate ()
        {
            while (this.containsOperand(new MathComponent(PossibleValues.Multiply)) ||
                   this.containsOperand(new MathComponent(PossibleValues.Divide)))
            {
                for (int i = 0; i < MathComponents.Count; i++)
                {
                    if (MathComponents[i].isMultiplyorDivide())
                    {
                        MathComponent newValue = DoSimpleCalculation(MathComponents[i - 1], MathComponents[i],
                            MathComponents[i + 1]);

                        MathComponents[i] = newValue;

                        MathComponents.RemoveAt(i+1);
                        MathComponents.RemoveAt(i-1);
                        i--;
                    }
                }
            }

            while (this.containsOperand(new MathComponent(PossibleValues.Add)) ||
                   this.containsOperand(new MathComponent(PossibleValues.Substract)))
            {
                for (int i = 0; i < MathComponents.Count; i++)
                {
                    if (MathComponents[i].isOperand())
                    {
                        MathComponent newValue = DoSimpleCalculation(MathComponents[i - 1], MathComponents[i],
                            MathComponents[i + 1]);

                        MathComponents[i] = newValue;

                        MathComponents.RemoveAt(i + 1);
                        MathComponents.RemoveAt(i - 1);
                        i--;
                    }
                }
            }
            return MathComponents[0].getDigitalValue();
        }

        private MathComponent DoSimpleCalculation(MathComponent left, MathComponent operand, MathComponent right)
        {
            float leftDigit = left.getDigitalValue();
            float rightDigit = right.getDigitalValue();
            MathComponent newValue;

            if (left.isOperand() || right.isOperand() || operand.isDigit())
            {
                throw new InvalidEnumArgumentException("Expected digit or operand, got the opposite. Check function parameters");
            }

            if (operand.getValue() == PossibleValues.Add)
            {
                newValue = new MathComponent(leftDigit + rightDigit);
            }
            else if (operand.getValue() == PossibleValues.Substract)
            {
                newValue = new MathComponent(leftDigit - rightDigit);
            }
            else if (operand.getValue() == PossibleValues.Multiply)
            {
                newValue = new MathComponent(leftDigit * rightDigit);
            }
            else //if (operand.getValue() == PossibleValues.Divide)
            {
                newValue = new MathComponent(leftDigit/rightDigit);
            }

            return newValue;
        }

        /// <summary>
        /// Function that checks whether or not the Equation contains specified operand
        /// </summary>
        /// <param name="operand">MathObject expected to be an operand</param>
        /// <exception cref="InvalidEnumArgumentException">If parameter operand is not an operand</exception>
        /// <returns></returns>
        public bool containsOperand(MathComponent operand)
        {
            if (!operand.isOperand())
            {
                throw new InvalidEnumArgumentException("Expected operator, got digit");
            }
            else
            {
                foreach (MathComponent m in MathComponents)
                {
                    if (m.getValue() == operand.getValue())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool containsAnyOperand()
        {
            foreach (MathComponent m in MathComponents)
            {
                if (m.isOperand())
                {
                    return true;
                }
            }
            return false;
        }
    }
}