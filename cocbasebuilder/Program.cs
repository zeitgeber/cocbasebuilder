using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cocbasebuilder.Model;

namespace cocbasebuilder
{
    class Program
    {

        static void Main(string[] args)
        {
            ExtendedBuilding townhall = new ExtendedBuilding("townhall", 4, 4, 1000, 0, 0, 1,6,4);
            ExtendedBuilding cc = new ExtendedBuilding("cc", 3, 3, 1000, 8, 200, 1, 3, 4);
            ExtendedBuilding king = new ExtendedBuilding("king", 3, 3, 1000, 8, 100, 1, 3, 4);
            ExtendedBuilding air = new ExtendedBuilding("air", 3, 3, 1050, 10, 230, 3, 2, 4);
            ExtendedBuilding tesla1 = new ExtendedBuilding("tesla", 2, 2, 770, 7, 75, 3, 2, 2);
            ExtendedBuilding store = new ExtendedBuilding("store", 3, 3, 2100, 0, 0, 7, 1, 4);
            ExtendedBuilding cannon1 = new ExtendedBuilding("cannon", 3, 3, 960, 9, 65, 5, 1, 4);
            ExtendedBuilding archer1 = new ExtendedBuilding("archer", 3, 3, 810, 10, 65, 5, 1, 5);
            ExtendedBuilding wizard1 = new ExtendedBuilding("wizard", 3, 3, 850, 7, 32, 3, 1, 4);
            ExtendedBuilding mortar = new ExtendedBuilding("mortar", 3, 3, 650, 11, 9, 4, 1, 6);
            ExtendedBuilding bomb = new ExtendedBuilding("bomb", 1, 1, 0, 3, 34, 6, 1, 4);
            ExtendedBuilding giantbomb = new ExtendedBuilding("giantbomb", 2, 2, 0, 3, 225, 3, 1, 6);
            ExtendedBuilding wall = new ExtendedBuilding("wall", 1, 1, 100, 5, 50, 50, 3, 1);

            Population pop = new Population(GlobalVar.PopulationSize);
            ExtendedBuilding[] buildings = new ExtendedBuilding[GlobalVar.TotalBuildings] { townhall,archer1,
                cannon1,
            tesla1,
            wizard1,mortar,air,store,cc,king,bomb,giantbomb,wall
            };
            pop.AddBuilding(buildings);

            
            //pop.DrawPopulation();
            pop.ScorePopulation(buildings);
            pop.GetBest(buildings);
            for (int i = 0; i < GlobalVar.Generations && !Console.KeyAvailable && pop.ScorePopulation(buildings); i++)
            {
                pop.ScorePopulation(buildings);
                //pop.GetBest();
                Console.Clear();
                pop.GetBest(buildings);
                Console.WriteLine("Generation: " + Convert.ToString(i));
                pop.Mutate(buildings);                
            }
            
            pop.ScorePopulation(buildings);
            Console.Clear();
            pop.DrawWalls(buildings);
                        
            foreach (ExtendedBuilding b in buildings)
            {
                b.PrintDetails();
            }
            pop.GetBest(buildings);
            Console.ReadLine();
        }
    }
}
