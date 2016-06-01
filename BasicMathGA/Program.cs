using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMathGA.Library.Genetics;

namespace BasicMathGA
{
    class Program
    {
        static void Main(string[] args)
        {

            MathGuesser mg = new MathGuesser(42, 0.001f, 0.7f, 10, 8);
            mg.Compute(42);
        }
    }
}
