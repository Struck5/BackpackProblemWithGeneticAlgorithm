using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.BackpackProblem;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            MainAlgorithm Algorithm = new MainAlgorithm(0.8, 0.1, 100, 500);

            Genome Result;

            Algorithm.GenerateRandomItems();
            Algorithm.GenerateRandomSolutions();
            Result = Algorithm.Evolve();
            Console.WriteLine(Result.Fitness);
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
