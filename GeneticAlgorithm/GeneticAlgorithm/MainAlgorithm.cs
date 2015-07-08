using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackpackProblem;
using GeneticAlgorithm.BackpackProblem;

namespace GeneticAlgorithm
{
    class MainAlgorithm
    {
        List<Genome> Solutions = new List<Genome>();
        List<Genome> NextGeneration = new List<Genome>(); 

        public double CrossoverProbability;
        public double MutationProbability;
        public int PopulationSize;
        public int GenerationCount;

        private Genome crossover_temp = null;

        Random rnd = new Random();

        public MainAlgorithm(double crossoverProbability, double mutationProbability, int populationSize, int generationCount)
        {
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            PopulationSize = populationSize;
            GenerationCount = generationCount;
        }

        public void GenerateSolutions()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Solutions.Add(new Genome(rnd.Next(1, Int32.MaxValue)));
                SortingAlgorithm.Sort(Solutions[i]);
                FitnessFunction.CalculateFitness(Solutions[i]);
                Console.WriteLine("#" + i + ": " + Solutions[i].Fitness);
            }

            Solutions.OrderByDescending(t => t.Fitness);
            double minimalFitness = Solutions.Where(x => !x.Fitness.Equals(0)).Sum(t => t.Fitness) / PopulationSize - Solutions.Count(x => !x.Fitness.Equals(0));
            Console.WriteLine("Minimale Fitness: " + minimalFitness);

            for (int i = 0; i < Solutions.Count; i++)
            {
                if (Solutions[i].Fitness >= minimalFitness && rnd.NextDouble() <= CrossoverProbability)
                {
                    if (crossover_temp == null)
                    {
                        crossover_temp = Solutions[i];
                    }
                }
            }
        }

        public void GenerateRandomItems()
        {
            for (int i = 0; i < 32; i++)
            {
                SortingAlgorithm.Auswahl.Add(new Item(rnd.Next(1, 51), rnd.Next(0, 101)));
            }
        }
    }
}
