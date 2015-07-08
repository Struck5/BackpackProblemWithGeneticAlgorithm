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
        private int[] newGenomes = new int[2];
        private Genome bestFitness;

        Random rnd = new Random();

        public MainAlgorithm(double crossoverProbability, double mutationProbability, int populationSize, int generationCount)
        {
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            PopulationSize = populationSize;
            GenerationCount = generationCount;
        }

        public void GenerateRandomItems()
        {
            for (int i = 0; i < 32; i++)
            {
                SortingAlgorithm.Auswahl.Add(new Item(rnd.Next(1, 51), rnd.Next(0, 101)));
            }
        }

        public void GenerateRandomSolutions()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Solutions.Add(new Genome(rnd.Next(1, Int32.MaxValue)));
            }
        }

        public Genome Evolve()
        {
            for (int i = 0; i < GenerationCount; i++)
            {
                for (int k = 0; k < PopulationSize; k++)
                {
                    SortingAlgorithm.Sort(Solutions[k]);
                    FitnessFunction.CalculateFitness(Solutions[k]);
                }

                Solutions.OrderByDescending(t => t.Fitness);

                //double minimalFitness = Solutions.Sum(t => t.Fitness) / PopulationSize;

                double minimalFitness = Solutions.Where(x => !x.Fitness.Equals(0)).Sum(t => t.Fitness) / PopulationSize - Solutions.Count(x => !x.Fitness.Equals(0));
                //Console.WriteLine("Minimale Fitness: " + minimalFitness);


                while (NextGeneration.Count < PopulationSize)
                {
                    for (int m = 0; m < Solutions.Count; m++)
                    {
                        if (NextGeneration.Count < PopulationSize) // NextGeneration schon voll?
                        {
                            if (Solutions[m].Fitness >= minimalFitness && rnd.NextDouble() <= CrossoverProbability) // Crossover
                            {
                                if (crossover_temp == null)
                                {
                                    crossover_temp = Solutions[m];
                                }
                                else
                                {
                                    newGenomes = Breeding.Crossover(crossover_temp, Solutions[m]);
                                    NextGeneration.Add(new Genome(newGenomes[0]));
                                    NextGeneration.Add(new Genome(newGenomes[1]));
                                    crossover_temp = null;
                                }
                            }

                            if (rnd.NextDouble() <= MutationProbability) // Mutation
                            {
                                NextGeneration.Add(new Genome(Breeding.Mutation(Solutions[m])));
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                while (NextGeneration.Count > PopulationSize)
                {
                    NextGeneration.RemoveAt(NextGeneration.Count - 1);
                }

                if (bestFitness != null)
                {
                    if (bestFitness.Fitness <= Solutions[0].Fitness)
                    {
                        bestFitness = Solutions[0];
                    }
                }
                else
                {
                    bestFitness = Solutions[0];
                }

                Solutions.RemoveAll(t => t.Parameter != null);
                //Solutions = NextGeneration;
                Solutions.AddRange(NextGeneration);
                NextGeneration.RemoveAll(t => t.Parameter != null);

            }

            return bestFitness;
        }
    }
}
