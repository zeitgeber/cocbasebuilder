using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cocbasebuilder
{
    class Population
    {
        Tile[] pop;
        double[] scores;
        int size;
        public Population(int size)
        {
            this.size = size;
            this.pop = new Tile[size];
            this.scores = new double[size];
            for (int i = 0; i < size; i++)
            {
                pop[i] = new Tile(GlobalVar.TileSize);
                scores[i] = 0;
            }
        }

        public void AddBuilding(Building[] buildings)
        {

            foreach (Tile t in pop)
            {
                foreach (Building b in buildings)
                {
                   foreach(int key in b.keys)
                    t.AddBuilding(b,key);
                }
            }
        }

        public void DrawPopulation()
        {
            int i = 0;
            foreach (Tile t in this.pop)
            {
                Console.WriteLine((++i).ToString());
                t.DrawTile();

            }
        }

        public bool ScorePopulation(Building[] b)
        {

            for (int i = 0; i < GlobalVar.PopulationSize; i++)
            {
                if (ScoreTile(i, b))
                {
                    return false;
                }
            }
            return true;
        }



        private bool ScoreTile(int index, Building[] b)
        {
            this.scores[index] = 0;
            foreach (Building t in b)
            {
                foreach (int key in t.keys)
                {
                    this.scores[index] += pop[index].ScoreBuilding(t, key);
                }
            }
            if (this.scores[index] > GlobalVar.ScoreCutoff)
            {
                return true;
            }
            return false;
        }

        public void Mutate(Building[] b)
        {
            Random random = new Random((int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber)));
            var topx = this.scores.ToList().OrderByDescending(i => i).Take(this.size/7);
            for (int i = 0; i < GlobalVar.PopulationSize; i++)
            {
                if (topx.ToList().IndexOf(this.scores[i]) < 0)
                {
                    int x = i;
                    while (x == i)
                    {
                        x = random.Next(0, GlobalVar.PopulationSize);
                    }
                    pop[i].Mutate(pop[x], b);
                }
            }
        }

        public void GetBest(Building[] b)
        {

            double maxValue = this.scores.Max();
            int maxIndex = this.scores.ToList().IndexOf(maxValue);
            Console.WriteLine("Max:" + maxValue.ToString() + "  Avg:" + this.scores.Average());
            pop[maxIndex].DrawTile();
            pop[maxIndex].AddWalls();
            pop[maxIndex].PrintScores();
            pop[maxIndex].DrawheatMap();
        }
        public void GetBest()
        {
            double maxValue = this.scores.Max();
            Console.WriteLine("Max:" + maxValue.ToString() + "  Avg:" + this.scores.Average());
        }
    }
}
