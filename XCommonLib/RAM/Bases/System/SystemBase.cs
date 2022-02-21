using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.System
{
    public abstract class SystemBase : MemoryObject
    {
        public abstract string[] LaunchParams { get; }
    }
}
