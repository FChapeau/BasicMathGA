using System.Collections.Generic;

namespace BasicMathGA.Library.Genetics
{
    public class MathGuesser
    {
        public Generation Generation { get; set; }
        public List<Generation> GenerationHistory { get; set; }
        public float Answer { get; set; }
        public float MutationChance { get; set; }
        public float CrossoverRate { get; set; }

        public MathGuesser(float answer, float mutationChance, float crossoverRate)
        {
            Answer = answer;
            MutationChance = mutationChance;
            CrossoverRate = crossoverRate;
            Generation = new Generation();
            GenerationHistory = new List<Generation>();
        }

        public Chromosome Compute(float AnswerToGuess)
        {
            this.Answer = AnswerToGuess;
            Chromosome Output = new Chromosome();

            //Generate initial population
            //Check fitness
            //Crossover
            //Mutation
            //Check fitness

            return Output;
        }

        private float CheckFitness(Chromosome chromosome)
        {
            List<string> totest = new List<string>();
            float fitnessvalue = 0.0f;
            //Calculate answer
            //Check fitness

            return fitnessvalue;
        }
    }
}
