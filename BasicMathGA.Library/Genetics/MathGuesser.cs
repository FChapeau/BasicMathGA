using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using BasicMathGA.Library.Utility;

namespace BasicMathGA.Library.Genetics
{
    public class MathGuesser
    {
        public Generation Generation { get; set; }
        public List<Generation> GenerationHistory { get; set; }
        public float Answer { get; set; }
        public float MutationChance { get; set; }
        public float CrossoverRate { get; set; }
        public int PopulationSize { get; set; }
        public int ChromosomeLength { get; set; }

        public MathGuesser(float answer, float mutationChance, float crossoverRate, int populationSize, int chromosomeLength)
        {
            Answer = answer;
            MutationChance = mutationChance;
            CrossoverRate = crossoverRate;
            PopulationSize = populationSize;
            ChromosomeLength = chromosomeLength;
            Generation = new Generation();
            GenerationHistory = new List<Generation>();
        }

        public Chromosome Compute(float AnswerToGuess)
        {
            this.Answer = AnswerToGuess;
            GenerationHistory.Add(Evolve());
            Chromosome answer = null;

            while (answer == null)
            {
                try
                {
                    GenerationHistory.Add(Evolve(GenerationHistory.Last()));

                    float fitnessSum = 0.0f;
                    foreach (Chromosome chromosome in GenerationHistory.Last().Chromosomes)
                    {
                        fitnessSum += chromosome.Fitness;
                    }

                    Console.WriteLine(fitnessSum/PopulationSize);
                }
                catch (AnswerFoundException e)
                {
                    answer = e.Answer;
                }
            }

            return answer;
        }

        //TODO Fitness Function
        private float CheckFitness(Chromosome chromosome)
        {
            float fitnessvalue = 0.0f;
            //Calculate answer
            float chromosomeResult = chromosome.AsEquation().Cleanup(chromosome.AsEquation()).Calculate();
            //Check fitness
            if ((Answer - chromosomeResult).Equals(0))
            {
                throw new AnswerFoundException(chromosome);
            }
            else
            {
                fitnessvalue = 1/(Answer - chromosomeResult);
            }

            return fitnessvalue;
        }

        public Generation Evolve()
        {
            //Generate Population
            Generation output = new Generation();
            Random r = new Random();
            for (int i = 0; i < PopulationSize; i++)
            {
                Chromosome c = new Chromosome();

                for (int j = 0; j < ChromosomeLength; j++)
                {
                    c.Genes.Add(new Gene((PossibleValues)r.Next(15)));
                }

                output.Chromosomes.Add(c);
            }

            //Check fitness
            foreach (Chromosome c in output.Chromosomes)
            {
                c.Fitness = CheckFitness(c);
            }

            return output;
        }

        public Generation Evolve(Generation previous)
        {
            Generation next = new Generation();
            Random r = new Random();

            //Generate population
                //Splice
            for (int i = 0; i < PopulationSize; i++)
            {
                Chromosome c1 = RouletteSelect(previous);

                if (r.NextDouble() < CrossoverRate)
                {
                    Chromosome c2 = RouletteSelect(previous);
                    c1 = c1.Splice(c2, r.Next(ChromosomeLength * 4));
                }

                next.Chromosomes.Add(c1);
            } 

                //Mutate
            foreach (Chromosome c in next.Chromosomes)
            {
                foreach (Gene g in c.Genes)
                {
                    g.Mutate((int) (1/MutationChance));
                }
            }

            //Check fitness 
            foreach (Chromosome c in next.Chromosomes)
            {
                c.Fitness = CheckFitness(c);
            }

            return next;
        }

        private Chromosome RouletteSelect(Generation pool)
        {
            Random r = new Random();
            float fitnessSum = 0.0f;

            foreach (Chromosome c in pool.Chromosomes)
            {
                fitnessSum += System.Math.Abs(c.Fitness);
            }

            float value = (float)r.NextDouble()*fitnessSum;

            foreach (Chromosome c in pool.Chromosomes)
            {
                value -= c.Fitness;
                if (value <= 0)
                {
                    return c;
                }
            }

            return pool.Chromosomes.Last();
        }
    }
}
