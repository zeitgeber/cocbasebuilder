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
            //string name, int w, int h, int hp, int aoe, int dmg, int count
            Building archer1 = new Building("archer", 3, 3, 810, 10, 65, 5,1);
            //Building archer2 = new Building("archer", 3, 3, 810, 10, 65, 5,1);
            //Building archer3 = new Building("archer", 3, 3, 810, 10, 65, 5,1);
            //Building archer4 = new Building("archer", 3, 3, 810, 10, 65, 5,1);
            //Building archer5 = new Building("archer", 3, 3, 810, 10, 65, 5,1);
            Building cannon1 = new Building("cannon", 3, 3, 960, 9, 65, 5,1);

            //Building cannon2 = new Building("cannon", 3, 3, 960, 9, 65, 5,2);
            //Building cannon3 = new Building("cannon", 3, 3, 960, 9, 65, 5,2);
            //Building cannon4 = new Building("cannon", 3, 3, 960, 9, 65, 5,2);
            //Building cannon5 = new Building("cannon", 3, 3, 960, 9, 65, 5,2);
            Building tesla1 = new Building("tesla", 2, 2, 770, 7, 75, 3,2);
            //Building tesla2 = new Building("tesla", 2, 2, 770, 7, 75, 3,3);
            //Building tesla3 = new Building("tesla", 2, 2, 770, 7, 75, 3,3);
            Building wizard1 = new Building("wizard", 3, 3, 850, 7, 32, 3,1);
            Building mortar = new Building("mortar", 3, 3, 650, 11, 9, 4, 1);
            Building air = new Building("air", 3, 3, 1050, 10, 230, 3, 2);
            Building store = new Building("store", 3, 3, 2100, 0, 0, 7, 1);
            //Building wizard2 = new Building("wizard", 3, 3, 850, 7, 32, 3,4);
            //Building wizard3 = new Building("wizard", 3, 3, 850, 7, 32, 3,4);
            Building townhall = new Building("townhall", 4, 4, 1000, 0, 0, 1,6);
            Building cc = new Building("cckingseed", 3, 3, 1000, 8, 20, 2, 3);

            archer1.PrintDetails();
            cannon1.PrintDetails();
            townhall.PrintDetails();
            wizard1.PrintDetails();
            tesla1.PrintDetails();

            Population pop = new Population(GlobalVar.PopulationSize);
            Building[] buildings = new Building[GlobalVar.TotalBuildings] { townhall,archer1,
                cannon1,
            tesla1,
            wizard1,mortar,air,store,cc
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
            Console.ReadLine();
        }
    }
}
