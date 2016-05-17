namespace BasicMathGA.Math
{
    public class MathComponent
    {
        private PossibleValues Value;
        private float DigitalValue = 0.0f;

        public MathComponent(PossibleValues value)
        {
            this.Value = value;
        }

        public MathComponent(float digitalValue)
        {
            DigitalValue = digitalValue;
            Value = PossibleValues.Zero;
        }

        public bool isOperand()
        {
            return (int)Value > 9;
        }

        public bool isMultiplyorDivide()
        {
            return (int)Value > 11;
        }

        public bool isDigit()
        {
            return (int) Value < 10;
        }

        public PossibleValues getValue()
        {
            return Value;
        }

        public float getDigitalValue()
        {
            return DigitalValue;
        }
    }
}