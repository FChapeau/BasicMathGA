using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathGA.Genetics
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

        public Chromosome Compute(float Answer)
        {
            this.Answer = Answer;
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
            List<String> totest = new List<string>();
            float fitnessvalue = 0.0f;
            //Calculate answer
            //Check fitness

            return fitnessvalue;
        }
    }
}
