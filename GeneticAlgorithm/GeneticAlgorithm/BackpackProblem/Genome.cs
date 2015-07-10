using System.Collections.Generic;


namespace BackpackProblem
{
    class Genome<T>
    {
        public List<Item> ImSack = new List<Item>(); // Maximal 32 Elemente

        public T Parameter;
        public float Fitness;

        public Genome(T parameter)
        {
            Parameter = parameter;
            Fitness = 0;
        }
    }
}

