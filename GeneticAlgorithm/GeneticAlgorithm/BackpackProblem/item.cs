using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.BackpackProblem
{
    class Item
    {
        public int Weight;
        public int Worth;

        public Item(int weigth, int worth)
        {
            Weight = weigth;
            Worth = worth;
        }
    }
}
