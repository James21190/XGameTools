using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.B3D
{
    public abstract class RenderObject : MemoryObject, IValidateable
    {
        public abstract bool IsValid { get; }
    }
}
