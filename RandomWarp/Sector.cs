using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWarp
{
    internal class Sector
    {
        public int SectorX;
        public int SectorY;
        public List<GateData> Gates = new List<GateData>();

        public override string ToString()
        {
            return "Sector " + SectorX + ", " + SectorY;
        }
    }
}
