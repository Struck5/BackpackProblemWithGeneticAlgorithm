using System;
using System.Linq;
using GeneticAlgorithm;

namespace BackpackProblem
{
    internal class Program
    {
        private const double CrossoverProbability = 0.8;
        private const double MutationProbability = 0.1;
        private const int PopulationSize = 100;
        private const int GenerationCount = 500;

        private static readonly MainAlgorithm<int> Algorithm = new MainAlgorithm<int>(CrossoverProbability,
            MutationProbability, PopulationSize,
            GenerationCount, ExtractItemsFromInt32Value.Sort, FitnessFunction.CalculateFitness,
            Breeding.Crossover, Breeding.Mutation);

        private static void Main(string[] args)
        {
            Console.SetWindowSize(50, 30);
            RunApplication(Algorithm);
        }

        private static void RunApplication(MainAlgorithm<int> a)
        {
            BackpackDemo.GenerateRandomItems();
            Genome<int> Result = a.Evolve(BackpackDemo.GenerateRandomSolutions(PopulationSize));

            Console.WriteLine("Picked Items:");
            Console.WriteLine();

            foreach (Item t in Result.ItemsPicked)
            {
                Console.WriteLine(t.Name + "  " + "\t" + " (Worth:" + t.Worth + ") " +
                                  "\t" + "(Weight:" + t.Weight + ")");
            }

            Console.WriteLine();
            Console.WriteLine("MaxWeight: " + FitnessFunction.MaxValue);
            Console.WriteLine("Current Weight: " + Result.ItemsPicked.Sum(t => t.Weight));
            Console.WriteLine("Current Worth: " + Result.ItemsPicked.Sum(t => t.Worth));
            Console.WriteLine();
            Console.WriteLine("Weight of all Items: " + ExtractItemsFromInt32Value.Selection.Sum(t => t.Weight));
            Console.WriteLine("Worth of all Items: " + ExtractItemsFromInt32Value.Selection.Sum(t => t.Worth));
            Console.ReadKey();

            ClearLists(Result);
            Console.Clear();
            RunApplication(new MainAlgorithm<int>(CrossoverProbability, MutationProbability, PopulationSize,
                GenerationCount, ExtractItemsFromInt32Value.Sort, FitnessFunction.CalculateFitness,
                Breeding.Crossover, Breeding.Mutation));
        }

        private static void ClearLists(Genome<int> result)
        {
            result.ItemsPicked.Clear();
            ExtractItemsFromInt32Value.Selection.Clear();
            BackpackDemo.ListOfNames.Clear();
        }
    }
}