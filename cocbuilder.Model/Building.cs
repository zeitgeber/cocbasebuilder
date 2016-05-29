using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocbasebuilder.Model
{
    public class Building//: Object
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Health { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public int Damage { get; set; }

        public override bool Equals(Object obj2)
        {
            var y = (Building)obj2;
            if (object.ReferenceEquals(this, y)) return true;

            if (object.ReferenceEquals(this, null) || object.ReferenceEquals(y, null)) return false;


            return this.Name == y.Name
                && this.Left == y.Left
                && this.Top == y.Top
                && this.Width == y.Width
                && this.Height == y.Height
                && this.Health == y.Health
                && this.MinRange == y.MinRange
                && this.MaxRange == y.MaxRange
                && this.Damage == y.Damage;
        }

        public override int GetHashCode()
        {
            if (object.ReferenceEquals(this, null)) return 0;
            return string.Format("{0}{1}", this.Name, this.Level).GetHashCode();
        }

    }

    //public class BuildingEqualityComparer : IEqualityComparer<Building>
    //{
    //    public bool Equals(Building x, Building y)
    //    {
    //        if (object.ReferenceEquals(x, y)) return true;

    //        if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

    //        return x.Name == y.Name 
    //            && x.Left == y.Left
    //            && x.Top == y.Top
    //            && x.Width == y.Width
    //            && x.Height == y.Height
    //            && x.Health == y.Health
    //            && x.MinRange == y.MinRange
    //            && x.MaxRange == y.MaxRange
    //            && x.Damage == y.Damage;
    //    }

    //    public int GetHashCode(Building obj)
    //    {
    //        if (object.ReferenceEquals(obj, null)) return 0;
    //        return string.Format("{0}{1}", obj.Name, obj.Level).GetHashCode();
    //    }
        
    //}
}
