using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathGA.Genetics
{
    public class Gene
    {
        private BitArray data;
        private int length = 4;
        private char[] possiblevalues = new char[14] { '1','2','3','4','5','6','7','8','9','0','+','-','/','*' };

        public Gene()
        {
            data = new BitArray(4);
        }

        public Gene(BitArray data)
        {
            if (data.Length != length)
            {
                throw new ArgumentException();
            }

            this.data = data;
        }

        public Gene(bool[] data)
        {
            if (data.Length != length)
            {
                throw new ArgumentException();
            }

            this.data = new BitArray(data);
        }

        public Gene(char input)
        {
            for (int i = 0; i < possiblevalues.Length; i++)
            {
                if (input == possiblevalues[i])
                {
                    data = new BitArray(BitConverter.GetBytes(i));
                    break;
                }
            }
        }

        public BitArray GetData()
        {
            return data;
        }

        public char GetValue()
        {
            int numvalue = ConvertBitArrayToInt(data);

            return possiblevalues[numvalue];
        }

        public int GetIntValue()
        {
            return ConvertBitArrayToInt(data);
        }

        private int ConvertBitArrayToInt(BitArray input)
        {
            int numvalue = 0;

            for (int i = 1; i == length; i++)
            {
                if (input[i - 1] == true)
                {
                    numvalue += (int)Math.Pow(2, i);
                }
            }

            return numvalue;
        }

        public bool IsOperand()
        {
            var result = new int();

            //Try to convert the string to an int. If it fails, it's an operand
            if (int.TryParse(GetValue().ToString(), out result))
            {
                return false;
            }
            return true;
        }
    }
}
