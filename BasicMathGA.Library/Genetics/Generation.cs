using System.Collections.Generic;

namespace BasicMathGA.Library.Genetics
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
