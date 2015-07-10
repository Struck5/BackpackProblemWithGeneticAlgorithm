using System;
using System.Collections.Generic;
using GeneticAlgorithm;

namespace BackpackProblem
{
    static class BackpackDemo
    {
        public static List<string> ListOfNames = new List<string>();
        public static int NumberOfNames = 1000;

        static Random rnd = new Random();
        public static List<Genome<int>> temp = new List<Genome<int>>();  

        public static List<Genome<int>> GenerateRandomSolutions(int populationSize)
        {
            for (int i = 0; i < populationSize; i++)
            {
                temp.Add(new Genome<int>(rnd.Next(1, Int32.MaxValue))); //TODO
            }
            return temp;
        }

        public static void GenerateRandomItems()
        {
            for (int i = 0; i < NumberOfNames; i++)
            {
                ListOfNames.Add("Item_" + rnd.Next(1, NumberOfNames));
            }

            for (int i = 0; i < 32; i++)
            {
                SortingAlgorithm.Auswahl.Add(new Item(rnd.Next(1, 51), rnd.Next(0, 101), ListOfNames[rnd.Next(0, NumberOfNames - 1)]));
            }
        }
    }

}
