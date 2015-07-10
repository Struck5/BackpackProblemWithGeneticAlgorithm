using System.Collections.Generic;
using GeneticAlgorithm;

namespace BackpackProblem
{
    static class SortingAlgorithm
    {
        public static List<Item> Auswahl = new List<Item>();  //32 Elemente; Wann/Wie/Wo wird diese liste gefüllt?

        public static void Sort(Genome<int> genom)
        {
            int temp = genom.Parameter;

            for (int i = 0; i < 31; i++)
            {
                int check = temp & 1 << i;
                if (check == (1<<i))
                {
                    genom.ImSack.Add(Auswahl[i]);
                }
            }
        }
    }
}
