using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Galaxy
{
    public abstract class GateData : MemoryObject
    {
        public abstract int DestinationSectorX { get; set; }
        public abstract int DestinationSectorY { get; set; }
        public abstract int DestinationSectorIndex { get; set; }
    }
}
