using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptArrayObject : MemoryObject
    {
        public abstract int ID { get; set; }
        public abstract int Length { get; set; }
        public abstract int Count { get; set; }
        public abstract MemoryObjectPointer<DynamicValue> pArr { get; set; }
    }
}
