using System;
using System.Collections.Generic;
using BasicMathGA.Library.Math;

namespace BasicMathGA.Library.Genetics
{
    public class Chromosome
    {
        public List<Gene> Genes { get; set; }
        public float Fitness { get; set; }
        
        public Chromosome()
        {
            Genes = new List<Gene>();
        }

        public Equation AsEquation()
        {
            return new Equation(new List<MathComponent>(Genes.ToArray()));
        }

        public Chromosome Splice(Chromosome other, int position)
        {
            Chromosome output = new Chromosome();
            if (position % 4 == 0)
            {
                int i = position/4;

                for (int j = 0; j < i; j++)
                {
                    output.Genes.Add(this.Genes[j]);
                }
                for (int j = i; j < other.Genes.Count; j++)
                {
                    output.Genes.Add(other.Genes[j]);
                }
            }
            else
            {
                int i = position/4;

                for (int j = 0; j < i; j++)
                {
                    output.Genes.Add(Genes[j]);
                }

                output.Genes.Add(Genes[i].Splice(other.Genes[i], position - i*4));

                for (int j = i + 1; j < other.Genes.Count; j++)
                {
                    output.Genes.Add(other.Genes[j]);
                }
            }

            return output;
        }

        public override bool Equals(object obj)
        {
            if (obj is Chromosome)
            {
                Chromosome other = (Chromosome) obj;
                if (this.Genes.Count != other.Genes.Count)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < this.Genes.Count; i++)
                    {
                        Gene g1 = Genes[i];
                        Gene g2 = other.Genes[i];

                        if (!g1.Equals(g2))
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}