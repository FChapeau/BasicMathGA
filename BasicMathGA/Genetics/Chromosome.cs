using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathGA.Genetics
{
    public class Chromosome
    {
        List<Gene> Genome;

        public Chromosome()
        {
            Genome = new List<Gene>();
        }
    }
}
