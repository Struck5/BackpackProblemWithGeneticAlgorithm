using System;
using System.Linq;
using BackpackProblem;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            MainAlgorithm<int> Algorithm = new MainAlgorithm<int>(0.8, 0.1, 100, 500, BackpackDemo.GenerateRandomItems, BackpackDemo.GenerateRandomSolutions, SortingAlgorithm.Sort, FitnessFunction.CalculateFitness, Breeding.Crossover, Breeding.Mutation);

            Genome<int> Result;

            Algorithm.CreateItems();
            Algorithm.CreateSolutions();
            Result = Algorithm.Evolve();

            for (int i = 0; i < Result.ImSack.Count; i++)
            {
                Console.Write(Result.ImSack[i].Name + " (Worth:" + Result.ImSack[i].Worth + " (Weight:" + Result.ImSack[i].Worth + ")");
            }

            Console.WriteLine();
            Console.WriteLine("MaxWeight: 300");
            Console.WriteLine(Result.ImSack.Sum(t => t.Weight));
            Console.WriteLine(Result.ImSack.Sum(t => t.Worth));
            Console.WriteLine("Gewicht aller Items: " + SortingAlgorithm.Auswahl.Sum(t => t.Weight));
            Console.WriteLine("Wert aller Items: " + SortingAlgorithm.Auswahl.Sum(t => t.Worth));
            Console.ReadKey();

            //for(int i = 0; i < 100, i++)
            //SortingAlgorithm.Sort (Genome[i]);
            //CalculateFitness (Genome[i]);


            //Sort Genomes by Fitness, start CrossoverCheck:


            //if Fitness[i] > minimalFitness && ProbabilityCheck[i] == true
            //      Create tempCopy[i]
            //if tempCopy != null, Crossover (old_tempCopy, new_tempCopy)
            //      List Next_Generation.Add Crossover return.
            // on Finish start Mutation Check:
            //if MutationProbability[i] == true
            //      Mutate[i], Next_Generation.Add Mutate return.


            //if Next_Generation.Count < 100 => rinse&repeat!
            //      else start new with Next_Generation as List
            // Stop if OptimalFitness != null && Fitness[i] > OptimalFitness || Generations >= 500;


            //return Best Solution
        }
    }
}
