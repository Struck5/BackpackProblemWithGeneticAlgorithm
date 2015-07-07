using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Genome
    {
        public int Parameter1;
        public int Parameter2;

        public float Fitness;

        public Genome(int parameter1, int parameter2)
        {
            Parameter1 = parameter1;
            Parameter2 = parameter2;
        }
    }
}
