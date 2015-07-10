using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    class MainAlgorithm<T>
    {
        public delegate List<Genome<T>> GenerateRandomSolutions(int populationSize);
        public delegate void GenerateRandomItems();

        public delegate void AddValueToList(Genome<T> genom);
        public delegate void ReturnFitnessValue(Genome<T> genom);
        public delegate T[] Crossover(Genome<T> parent1, Genome<T> parent2);
        public delegate T Mutation(Genome<T> genom);

        GenerateRandomItems randomItems;
        GenerateRandomSolutions randomSolutions;
        AddValueToList sort;
        ReturnFitnessValue fitnessValue;
        Crossover cross;
        Mutation mutate;

        List<Genome<T>> Solutions = new List<Genome<T>>();
        List<Genome<T>> NextGeneration = new List<Genome<T>>(); 

        public double CrossoverProbability;
        public double MutationProbability;
        public int PopulationSize;
        public int GenerationCount;

        private Genome<T> crossover_temp = null;
        private T[] newGenomes = new T[2];
        private Genome<T> bestFitness;

        Random rnd = new Random();

        public MainAlgorithm(double crossoverProbability, double mutationProbability, int populationSize, int generationCount, GenerateRandomItems gri, GenerateRandomSolutions grs, AddValueToList avl, ReturnFitnessValue rfv, Crossover co, Mutation mu)
        {
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            PopulationSize = populationSize;
            GenerationCount = generationCount;

            this.randomItems = gri;
            this.randomSolutions = grs;
            this.sort = avl;
            this.fitnessValue = rfv;
            this.cross = co;
            this.mutate = mu;
        }

        public void CreateItems()
        {
            randomItems.Invoke();
        }

        public void CreateSolutions()
        {
            Solutions.AddRange(randomSolutions.Invoke(PopulationSize));
        }


        public Genome<T> Evolve()
        {
            for (int i = 0; i < GenerationCount; i++)
            {
                for (int k = 0; k < PopulationSize; k++)
                {
                    //SortingAlgorithm.Sort(Solutions[k]);
                    //AddValueToList sort = new AddValueToList(SortingAlgorithm.Sort);
                    sort.Invoke(Solutions[k]);

                    //FitnessFunction.CalculateFitness(Solutions[k]);
                    //ReturnFitnessValue rfv = new ReturnFitnessValue(FitnessFunction.CalculateFitness);
                    fitnessValue.Invoke(Solutions[k]);
                }

                Solutions.OrderByDescending(t => t.Fitness);

                double minimalFitness = Solutions.Where(x => !x.Fitness.Equals(0)).Sum(t => t.Fitness) / PopulationSize - Solutions.Count(x => !x.Fitness.Equals(0));

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
                                    //newGenomes = Breeding.Crossover(crossover_temp, Solutions[m]);
                                    newGenomes = cross.Invoke(crossover_temp, Solutions[m]);
                                    //Crossover cross = new Crossover(Breeding.Crossover);
                                    //newGenomes = cross(crossover_temp, Solutions[m]);

                                    NextGeneration.Add(new Genome<T>(newGenomes[0]));
                                    NextGeneration.Add(new Genome<T>(newGenomes[1]));
                                    crossover_temp = null;
                                }
                            }

                            if (rnd.NextDouble() <= MutationProbability) // Mutation
                            {
                                //mutate.Invoke(Solutions[m]);
                                NextGeneration.Add(new Genome<T>(mutate.Invoke(Solutions[m])));
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
                Solutions.AddRange(NextGeneration);
                NextGeneration.RemoveAll(t => t.Parameter != null);

            }

            return bestFitness;
        }
    }
}
