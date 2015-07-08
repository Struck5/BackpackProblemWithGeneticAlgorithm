using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class FitnessFunction
    {
        public static int MaximalGewicht = 100;

        //Bewertungskriterien:
        //Eventuell nicht nur Gold sondern auch Gold pro Gewicht Verhältnis beurteilen?
        
        public static void CalculateFitness(Genome genom)
        {
            // Mögliche FitnessFunktionen, nicht final, nicht alle zusammen verwenden!!!

            genom.Fitness += genom.ImSack.Sum(t => t.Worth)/100f; //Mehr Gold => höhere Fitness!

            genom.Fitness *= (genom.ImSack.Sum(t => t.Worth) / 50f); //Gold = 0 => Fitness = 0; Je näher an Gold = 0 desto kleiner Fitness!

            genom.Fitness -= genom.ImSack.Sum(t => t.Weight) - MaximalGewicht; //Maximalgewicht überschritten => Fitness sehr klein/direkt auf 0

            genom.Fitness *= Math.Abs(10 / (genom.ImSack.Sum(t => t.Weight) - MaximalGewicht)); //Maximalgewicht perfekt/sehr nahe getroffen = Bonuspunkte! Je weiter vom MaximalGewicht entfernt, desto kleiner die Fitness!
        }
    }
}
