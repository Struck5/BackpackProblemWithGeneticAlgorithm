using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class FitnessFunction
    {
        public int MaximalGewicht = 100;

        //Bewertungskriterien:
        //Maximalgewicht überschritten => Fitness sehr klein/direkt auf 0
        //Gold = 0 => Fitness = 0;
        //Eventuell nicht nur Gold sondern auch Gold pro Gewicht Verhältnis beurteilen?
        //Maximalgewicht perfekt/sehr nahe getroffen = Bonuspunkte!
        // Je weiter vom MaximalGewicht entfernt, desto kleiner die Fitness!
        // Je näher an Gold = 0 desto kleiner Fitness!

        public void CalculateFitness(Genome genom)
        {
            genom.Fitness += genom.ImSack.Sum(t => t.Worth);

            genom.Fitness -= genom.ImSack.Sum(t => t.Weight) - MaximalGewicht;
        }
    }
}
