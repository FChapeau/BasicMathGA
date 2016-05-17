using System;
using System.Collections;
using BasicMathGA.Math;
using BasicMathGA.Utility;

namespace BasicMathGA.Genetics
{
    public class Gene : MathComponent
    {
        public Gene(PossibleValues value) : base(value)
        {
        }

        public Gene(float digitalValue) : base(digitalValue)
        {
        }

        /// <summary>
        /// Returns new gene after applying random bitwise mutation
        /// </summary>
        /// <param name="mutationChance">Odds of performing the mutation, represented as the denominator of a percentile number (eg. 1/mutationChance)</param>
        /// <returns>Mutated gene</returns>
        public Gene Mutate(int mutationChance)
        {
            if (mutationChance < 0)
            {
                throw new ArgumentOutOfRangeException("MutationChance must be a positive integer number");
            }

            //Convert int to bit array
            int value = (int) this.getValue();
            BitArray bitarray = BitArrayExtensions.ToBinary(value);


            //Randomly flip bits
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (random.Next(1, mutationChance) == 1)
                {
                    bitarray[i] = !bitarray[i];
                }
            }

            //Convert bit array back into int
            int newValue = bitarray.ToNumeral();

            //Return resulting gene
            return new Gene((PossibleValues)newValue);
        }

        /// <summary>
        /// Method to mix two genes together at determined position
        /// </summary>
        /// <param name="geneToSpliceWith"></param>
        /// <param name="position"></param>
        /// <returns>Spliced gene</returns>
        public Gene Splice(Gene geneToSpliceWith, int position)
        {
            BitArray left = BitArrayExtensions.ToBinary((int) this.getValue());
            BitArray right = BitArrayExtensions.ToBinary((int) geneToSpliceWith.getValue());

            for (int i = position; i < 4; i++)
            {
                left[i] = right[i];
            }

            return new Gene((PossibleValues)left.ToNumeral());
        }


    }
}