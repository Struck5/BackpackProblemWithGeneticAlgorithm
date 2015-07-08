using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.BackpackProblem
{
    static class Breeding
    {
        static Random rnd = new Random();

        public static int CrossPoint;
        public static int MutatePoint;
        public static int NewParam1 = 0;
        public static int NewParam2 = 0;

        static public int[] Crossover(Genome parent1, Genome parent2)
        {
            CrossPoint = rnd.Next(1, 32);

            int temp = (1 << CrossPoint) -1;
            NewParam1 = parent1.Parameter & temp;
            NewParam2 = parent2.Parameter & temp;

            temp = Int32.MaxValue - temp;
            NewParam1 = NewParam1 | (parent2.Parameter & temp);
            NewParam2 = NewParam2 | (parent1.Parameter & temp);

            int[] NewGenomes = new int[2];
            NewGenomes[0] = NewParam1;
            NewGenomes[1] = NewParam2;
            return NewGenomes;
        }

        static public int Mutation(Genome genom)
        {
            MutatePoint = rnd.Next(0, 31);
            int temp = (1 << MutatePoint);
            NewParam1 = genom.Parameter ^ temp;
            return NewParam1;
        }
    }
}
