using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cocbasebuilder.Model
{
    public class ExtendedBuilding
    {
        public string name;
        public int width { get; set; }
        public int height { get; set; }
        private int hp;
        public int aoe { get; set; }
        public int dmg { get; set; }
        public List<int> keys { get; set; }
        public double weight { get; set; }
        public int buffer { get; set; }
        private static int counter = 0;
        public Tuple<int,int> pos;

        public ExtendedBuilding(string name, int w, int h, int hp, int aoe, int dmg, double weight, int buffer, int top, int left)
        {
            this.name = name;
            this.width = w;
            this.height = h;
            this.hp = hp;
            this.aoe = aoe;
            this.dmg = dmg;
            this.weight = weight;
            this.buffer = buffer;
            this.pos = new Tuple<int, int>(top, left);
            ++counter;
            keys = new List<int>();
            keys.Add(100 + counter);
        }

        public void PrintDetails()
        {
            Console.WriteLine("name:" + this.name + ";" + (this.width.ToString()) + "x" + (this.height.ToString()) + ";hp:" + this.hp.ToString() + ";aoe:" + this.aoe.ToString() + ";dmg=" + this.dmg.ToString() + ";  key=" + this.keys[0].ToString());
        }
    }

}
