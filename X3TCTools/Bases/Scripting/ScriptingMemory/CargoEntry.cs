using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public struct CargoEntry : IComparable
    {
        public SectorObject.Full_Type Type;
        public int Count;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (!(obj is CargoEntry)) throw new Exception("Type missmatch");
            return ((CargoEntry)obj).Type.CompareTo(this.Type);

        }

        public override string ToString()
        {
            return Type.ToString() + " X " + Count;
        }
    }

    public struct StationCargoEntry : IComparable
    {
        public SectorObject.Full_Type Type;
        public int Count;
        public int Capacity;
        public int Price;
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (!(obj is StationCargoEntry)) throw new Exception("Type missmatch");
            return ((StationCargoEntry)obj).Type.CompareTo(this.Type);

        }

        public override string ToString()
        {
            return string.Format("{0} X {1}/{2} at {3}Cr",Type.ToString(),Count,Capacity, Price);
        }
    }
}
