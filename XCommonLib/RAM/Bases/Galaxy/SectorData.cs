using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Galaxy
{
    public abstract class SectorData : MemoryObject
    {
        public abstract GateData[] Gates { get; set; }
    }
}
