using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathGA.Genetics
{
    public class Gene
    {
        public int Data{ get; set; }
        private char[] possiblevalues = new char[14]
        {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '/', '*'};

        public Gene()
        {
            Data = 0;
        }

        public Gene(int data)
        {

            Data = data;
        }

        public Gene(char data)
        {
            Data = -1;

            for (int i = 0; i < possiblevalues.Length; i++)
            {
                if (possiblevalues[i] == data)
                {
                    Data = i;
                    break;
                }
            }

            if (Data == -1)
            {
                throw new ArgumentException();
            }
        }

        public int AsInt()
        {
            return Data;
        }

        public int GetDigit()
        {
            if (IsDigit())
            {
                return Data + 1;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public char AsChar()
        {
            if (Data > 13)
            {
                throw new IndexOutOfRangeException();
            }
            return possiblevalues[Data];
        }

        public BitArray AsBitArray()
        {
            BitArray output = new BitArray(BitConverter.GetBytes(Data)) {Length = 4};

            return output;
        }

        public bool IsOperand()
        {
            if (9 < Data && Data < 14)
            {
                return true;
            }

            return false;
        }

        public bool IsDigit()
        {
            if (Data < 9) return true;
            return false;
        }

        private int GetIntFromBitArray(BitArray bitArray)
        {

            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];

        }

        public bool IsSupported()
        {
            if (Data < 13) return false;
            return true;
        }
    }

}
