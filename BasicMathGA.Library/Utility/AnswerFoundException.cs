using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMathGA.Library.Genetics;

namespace BasicMathGA.Library.Utility
{
    public class AnswerFoundException : Exception
    {
        public Chromosome Answer { get; set; }

        public AnswerFoundException(Chromosome Answer)
        {
            this.Answer = Answer;
        }
    }
}
