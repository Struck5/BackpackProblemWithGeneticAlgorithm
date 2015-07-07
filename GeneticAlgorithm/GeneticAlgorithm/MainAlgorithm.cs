using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class MainAlgorithm
    {
        List<Genome> Solutions = new List<Genome>();

        public double CrossoverProbability;
        public double MutationProbability;
        public int PopulationSize;
        public int GenerationCount;

        Random rnd = new Random();

        public MainAlgorithm(double crossoverProbability, double mutationProbability, int firstGeneration, int generationCount)
        {
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            PopulationSize = firstGeneration;
            GenerationCount = generationCount;
        }

        public void GenerateSolutions()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Solutions.Add(new Genome(rnd.Next(0, 100), rnd.Next(0, 100)));
            }
        }
    }
}
