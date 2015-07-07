using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class SortingAlgorithm
    {
        List<string> Auswahl = new List<string>();  //32 Elemente
        List<string> ImSack = new List<string>(); // Maximal 32 Elemente

        public void Sort(Genome genom)
        {
            int temp = genom.Parameter;

            for (int i = 0; i < Auswahl.Count; i++)
            {
                int check = temp & 1 << i;
                if (check == (1<<i))
                {
                    ImSack.Add(Auswahl[i]);
                }
            }
        }
    }
}
