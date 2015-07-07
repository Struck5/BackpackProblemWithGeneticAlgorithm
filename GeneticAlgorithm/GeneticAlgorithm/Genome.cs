using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Genome
    {
        public int Parameter;

        public float Fitness;

        public Genome(int parameter)
        {
            Parameter = parameter;
        }
    }
}
