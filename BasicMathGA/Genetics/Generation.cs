using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathGA.Genetics
{
    public class Generation
    {
        public List<Chromosome> Chromosomes { get; set; }

        public Generation()
        {
            Chromosomes = new List<Chromosome>();
        }
    }
}
