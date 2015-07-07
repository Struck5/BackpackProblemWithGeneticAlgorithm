using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Genome
    {
        public double[] _genes;
        public int Parameter;
        public double Fitness;

        private int _length;
        private static double _mutationRate;
        private static Random _random = new Random();

        // #constructor 1
        public Genome(int parameter, int length)
        {
            Parameter = parameter;
            _length = length;
        }

        // #constructor 2
        public Genome(int length, bool needNewGenes)
        {
            _length = length;

            if (needNewGenes)
                CreateGenes();
        }

        public Genome()
        {

        }

        // brauchen wir weitere constructors?
        
        private void CreateGenes()
        {
            for (int i = 0; i < _length; i++)
                _genes[i] = _random.NextDouble();
        }
    }
}

