using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BackpackProblem;
using GeneticAlgorithm.BackpackProblem;

namespace GeneticAlgorithm
{
    class Genome
    {
        public List<Item> ImSack = new List<Item>(); // Maximal 32 Elemente

        public int Parameter;
        public float Fitness;

        public Genome(int parameter)
        {
            Parameter = parameter;
            Fitness = 0;
        }
    }
}

