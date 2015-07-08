using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class FitnessFunction
    {
        public static int MaxValue = 250;

        //Bewertungskriterien:
        //Eventuell nicht nur Gold sondern auch Gold pro Gewicht Verhältnis beurteilen?
        
        public static void CalculateFitness(Genome genom)
        {
            // Mögliche FitnessFunktionen, nicht final, nicht alle zusammen verwenden!!!

            if (genom.ImSack.Sum(t => t.Weight) >= MaxValue*1.2f)
            {
                genom.Fitness = 0;
                return;
            }

            genom.Fitness += genom.ImSack.Sum(t => t.Worth); //Mehr Gold => höhere Fitness!
            Console.WriteLine(genom.ImSack.Sum(t => t.Worth));
            Console.WriteLine(genom.Fitness);

            genom.Fitness += (-((genom.ImSack.Sum(t => t.Weight) - MaxValue) * (genom.ImSack.Sum(t => t.Weight) - MaxValue))); //Maximalgewicht überschritten => Fitness sehr klein/direkt auf 0
            Console.WriteLine((genom.ImSack.Sum(t => t.Weight) - MaxValue));
            Console.WriteLine((-((genom.ImSack.Sum(t => t.Weight) - MaxValue) * (genom.ImSack.Sum(t => t.Weight) - MaxValue))));
            Console.WriteLine(genom.Fitness);
            Console.ReadKey();
            /*genom.Fitness *= (genom.ImSack.Sum(t => t.Weight) - MaxValue); //Maximalgewicht perfekt/sehr nahe getroffen = Bonuspunkte! Je weiter vom MaximalGewicht entfernt, desto kleiner die Fitness!
            genom.Fitness *= (genom.ImSack.Sum(t => t.Worth) / 50f); //Gold = 0 => Fitness = 0; Je näher an Gold = 0 desto kleiner Fitness!*/
        }
    }
}
