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
                        float left = MathComponents[i - 1].getDigitalValue();
                        float right = MathComponents[i + 1].getDigitalValue();
                        PossibleValues operand = MathComponents[i].getValue();
                        MathComponent newValue;

                        if (operand == PossibleValues.Multiply)
                        {
                            newValue = new MathComponent(left*right);
                        }
                        else
                        {
                            newValue = new MathComponent(left/right);
                        }

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
                        float left = MathComponents[i - 1].getDigitalValue();
                        float right = MathComponents[i + 1].getDigitalValue();
                        PossibleValues operand = MathComponents[i].getValue();
                        MathComponent newValue;

                        if (operand == PossibleValues.Add)
                        {
                            newValue = new MathComponent(left + right);
                        }
                        else
                        {
                            newValue = new MathComponent(left - right);
                        }

                        MathComponents[i] = newValue;

                        MathComponents.RemoveAt(i + 1);
                        MathComponents.RemoveAt(i - 1);
                        i--;
                    }
                }
            }
            return MathComponents[0].getDigitalValue();
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