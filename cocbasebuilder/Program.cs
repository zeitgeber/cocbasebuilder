using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocbasebuilder
{
    class Program
    {

        static void Main(string[] args)
        {
            Building townhall = new Building("townhall", 4, 4, 1000, 0, 0, 1,6,4);
            Building cc = new Building("cc", 3, 3, 1000, 8, 200, 1, 3, 4);
            Building king = new Building("king", 3, 3, 1000, 8, 100, 1, 3, 4);
            Building air = new Building("air", 3, 3, 1050, 10, 230, 3, 2, 4);
            Building tesla1 = new Building("tesla", 2, 2, 770, 7, 75, 3, 2, 4);
            Building store = new Building("store", 3, 3, 2100, 0, 0, 7, 1, 4);
            Building cannon1 = new Building("cannon", 3, 3, 960, 9, 65, 5, 1, 4);
            Building archer1 = new Building("archer", 3, 3, 810, 10, 65, 5, 1, 4);
            Building wizard1 = new Building("wizard", 3, 3, 850, 7, 32, 3, 1, 4);
            Building mortar = new Building("mortar", 3, 3, 650, 11, 9, 4, 1, 4);
            Building bomb = new Building("bomb", 1, 1, 0, 3, 34, 6, 1, 4);
            Building giantbomb = new Building("giantbomb", 2, 2, 0, 3, 225, 3, 1, 4);
            Building wall = new Building("wall", 1, 1, 100, 7, 400, 50, 6, 2);

            Population pop = new Population(GlobalVar.PopulationSize);
            Building[] buildings = new Building[GlobalVar.TotalBuildings] { townhall,archer1,
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
                Console.WriteLine("Generation: " + Convert.ToString(i));
                pop.ScorePopulation(buildings);
                pop.GetBest();
                pop.Mutate(buildings);                
            }
            
            pop.ScorePopulation(buildings);
            pop.GetBest(buildings);
            pop.DrawWalls(buildings);
            foreach (Building b in buildings)
            {
                b.PrintDetails();
            }
            Console.ReadLine();
        }
    }
}
