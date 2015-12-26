using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cocbasebuilder
{
    class Building
    {
        public string name;
        public int width { get; set; }
        public int height { get; set; }
        private int hp;
        public int aoe { get; set; }
        public int dmg { get; set; }
        public List<int> keys { get; set; }
        public int count { get; set; }
        public double weight{ get; set; }
        public int buffer { get; set; }
        private static int counter = 0;

        public Building(string name, int w, int h, int hp, int aoe, int dmg, int count, double weight, int buffer)
        {
            this.name = name;
            this.width = w;
            this.height = h;
            this.hp = hp;
            this.aoe = aoe;
            this.dmg = dmg;
            this.count = count;
            this.weight = weight;
            this.buffer = buffer;
            ++counter;
            keys = new List<int>();
            for (int i = 0; i < count; i++)
            {
                keys.Add((i + 1) * 100 + counter);
            }            
        }

        public void PrintDetails()
        {
            Console.WriteLine("name:" + this.name + ";" + (this.width.ToString()) + "x" + (this.height.ToString()) + ";hp:" + this.hp.ToString() + ";aoe:" + this.aoe.ToString() + ";dmg=" + this.dmg.ToString()+";  key="+this.keys[0].ToString());
        }
    }
}
