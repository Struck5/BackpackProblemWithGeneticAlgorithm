using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackpackProblem;
using GeneticAlgorithm.BackpackProblem;

namespace GeneticAlgorithm
{
    class SortingAlgorithm
    {
        List<Item> Auswahl = new List<Item>();  //32 Elemente; Wann/Wie/Wo wird diese liste gefüllt?

        public void Sort(Genome genom)
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
