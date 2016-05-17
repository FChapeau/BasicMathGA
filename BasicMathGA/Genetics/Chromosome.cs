using System.Collections.Generic;
using BasicMathGA.Math;

namespace BasicMathGA.Genetics
{
    public class Chromosome
    {
        public List<Gene> Genes { get; set; }

        public Chromosome()
        {
            Genes = new List<Gene>();
        }

        public Equation AsEquation()
        {
            return new Equation(new List<MathComponent>(Genes.ToArray()));
        }
    }
}