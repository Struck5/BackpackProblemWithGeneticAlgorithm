﻿using System.Linq;
using GeneticAlgorithm;


namespace BackpackProblem
{
    static class FitnessFunction
    {
        public static int MaxValue = 300;

        public static void CalculateFitness(Genome<int> genom)
        {
            if (genom.ImSack.Sum(t => t.Weight) >= MaxValue*1.25f)
            {
                genom.Fitness = 0;
                return;
            }

            genom.Fitness += genom.ImSack.Sum(t => t.Worth);

            float x = genom.ImSack.Sum(t => t.Weight) - MaxValue;
            genom.Fitness += (-((0.5f * x * x) + (5 * x)));

            if (genom.Fitness < 1)
            {
                genom.Fitness = 1;
            }
        }
    }
}
