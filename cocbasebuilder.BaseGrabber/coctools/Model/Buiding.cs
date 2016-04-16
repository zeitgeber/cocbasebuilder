using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocbasebuilder.BaseGrabber.coctools.Model
{
    public class Building
    {
        public string Name { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Health { get; set; }
        public float MinRange { get; set; }
        public float MaxRange { get; set; }
        public int Damage { get; set; }

    }
}
