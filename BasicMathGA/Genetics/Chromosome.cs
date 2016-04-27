using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathGA.Genetics
{
    public class Chromosome
    {
        public List<Gene> Genome { get; set; }
        public float FitnessValue { get; set; }

        public Chromosome()
        {
            Genome = new List<Gene>();
        }

        public Chromosome(string input)
        {
            Genome = new List<Gene>();
            foreach (char c in input)
            {
                Genome.Add(new Gene(c));
            }
        }

        public Chromosome(List<Gene> genome)
        {
            Genome = genome;
        }

        public override string ToString()
        {
            String output = "";

            foreach (Gene g in Genome)
            {
                output += g.AsChar();
            }

            return output;
        }

        //TODO Write cleanup function
        public Chromosome GetCleanGenome()
        {
            List<Gene> cleanGenome = Genome;
            
            //Clean unsupported gene codes
            foreach (Gene g in cleanGenome.ToList())
            {
                if (g.IsSupported())
                {
                    cleanGenome.Remove(g);
                }
            }

            //Clean leading and trailing operands
            while (cleanGenome.First().IsOperand())
            {
                cleanGenome.Remove(cleanGenome.First());
            }

            while (cleanGenome.Last().IsOperand())
            {
                cleanGenome.Remove(cleanGenome.Last());
            }

            //Clean consecutive characters
            for (int i = 0; i < cleanGenome.Count - 1; i++)
            {
                if (!cleanGenome[i].IsOperand())
                {
                    while (!cleanGenome[i + 1].IsOperand())
                    {
                        cleanGenome.RemoveAt(i + 1);
                    }
                }

                if (cleanGenome[i].IsOperand())
                {
                    while (cleanGenome[i + 1].IsOperand())
                    {
                        cleanGenome.RemoveAt(i + 1);
                    }
                }
            }
            
            return new Chromosome(cleanGenome);
        }

        //TODO Write calculation function
        public float Calculate()
        {
            float output = 0.0f;
            int num1 = -1;
            char operand = ' ';
            int num2 = -1;

            for (int i = 0; i < Genome.Count; i++)
            {
                if (num1 != -1 && num2 != -1 && operand != ' ')
                {
                    switch (operand)
                    {
                        case '+':
                            output += (float) num1 + num2;
                            break;

                        case '-':
                            output += (float) num1 - num2;
                            break;
                    }
                }
            }

            return output;
        }
    }
}
