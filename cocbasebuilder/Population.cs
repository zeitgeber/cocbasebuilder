using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocbasebuilder.Model;

namespace cocbasebuilder
{
    class Population
    {
        Tile[] pop;
        double[] scores;
        int size;
        HashSet<string> candidates = new HashSet<string>();

           
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

        static Random random = new Random();

        // Note, max is exclusive here!
        public static List<int> GenerateRandom(int count, int min, int max)
        {

            //  initialize set S to empty
            //  for J := N-M + 1 to N do
            //    T := RandInt(1, J)
            //    if T is not in S then
            //      insert T in S
            //    else
            //      insert J in S
            //
            // adapted for C# which does not have an inclusive Next(..)
            // and to make it from configurable range not just 1.

            if (max <= min || count < 0 ||
                // max - min > 0 required to avoid overflow
                    (count > max - min && max - min > 0))
            {
                // need to use 64-bit to support big ranges (negative min, positive max)
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                        " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }

            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();

            // start count values before max, and end at max
            for (int top = max - count; top < max; top++)
            {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }

            // load them in to a list, to sort
            List<int> result = candidates.ToList();

            // shuffle the results because HashSet has messed
            // with the order, and the algorithm does not produce
            // random-ordered results (e.g. max-1 will never be the first value)
            for (int i = result.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }

        public void AddBuilding(ExtendedBuilding[] buildings)
        {

            foreach (Tile t in pop)
            {
                foreach (int i in GenerateRandom(GlobalVar.TotalBuildings, 0, GlobalVar.TotalBuildings))
                {
                    foreach (int key in buildings[i].keys)
                        t.AddBuilding(buildings[i], key);
                }
            }
        }

        public void AddBuilding(List<ExtendedBuilding> buildings)
        {

            foreach (Tile t in pop)
            {
                foreach (ExtendedBuilding b in buildings)
                {
                    //t.AddBuilding(buildings[i], key);
                    t.AddBuilding(b);
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

        public bool ScorePopulation(List<ExtendedBuilding> b)
        {
            //this.candidates.Clear();
            

            for (int i = 0; i < GlobalVar.PopulationSize; i++)
            {
                if (ScoreTile(i, b))
                {
                    return false;
                }
            }
            return true;
        }



        private bool ScoreTile(int index, List<ExtendedBuilding> b)
        {
            this.scores[index] = 0;
            string id = "";
            foreach (ExtendedBuilding t in b)
            {
                foreach (int key in t.keys)
                {
                    var score = pop[index].ScoreBuilding(t, key);
                    this.scores[index] += score;
                    id = id + score.ToString();
                }
            }
            this.candidates.Add(id);
            if (this.scores[index] > GlobalVar.ScoreCutoff)
            {
                return true;
            }
            return false;
        }

        public void Mutate(List<ExtendedBuilding> b)
        {
            Random random = new Random((int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber)));
            var topx = this.scores.ToList().OrderByDescending(i => i).Take(Convert.ToInt32(this.size * GlobalVar.elitepop));
            for (int i = 0; i < GlobalVar.PopulationSize; i++)
            {
                if (topx.ToList().IndexOf(this.scores[i]) < 0)
                {
                    int x = i;
                    while (x == i)
                    {
                        x = random.Next(0, GlobalVar.PopulationSize);
                    }
                    for (int k = 0; k < GlobalVar.mergeCount; k++)
                    {
                        pop[i].Mutate(pop[x], b);
                        ScoreTile(i, b);
                    }
                }
                else
                {
                    for (int k = 0; k < GlobalVar.mergeCount; k++)
                    {
                        pop[i].Mutate(pop[i], b);
                        ScoreTile(i, b);
                    }
                }
            }
        }

        public void GetBest(List<ExtendedBuilding> b)
        {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            double maxValue = this.scores.Max();
            int maxIndex = this.scores.ToList().IndexOf(maxValue);
            Console.WriteLine("");
            Console.WriteLine("Max:" + maxValue.ToString() + "  Avg:" + this.scores.Average()+" Unique:"+candidates.Count.ToString());
            pop[maxIndex].DrawTile();
            pop[maxIndex].DrawheatMap();
            //pop[maxIndex].PrintScores();
            Console.SetCursorPosition(origCol, origRow);
        }

        public void DrawWalls(ExtendedBuilding[] b)
        {
            double maxValue = this.scores.Max();
            int maxIndex = this.scores.ToList().IndexOf(maxValue);
            pop[maxIndex].AddWalls(b);
        }
        public void GetBest()
        {
            double maxValue = this.scores.Max();
            Console.WriteLine("Max:" + maxValue.ToString() + "  Avg:" + this.scores.Average() + " Unique:" + candidates.Count.ToString());
        }
    }
}
