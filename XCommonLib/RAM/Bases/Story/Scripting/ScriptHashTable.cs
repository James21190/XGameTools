using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptHashTable : MemoryObject
    {
        public abstract int Count { get; set; }
        public abstract DynamicValue GetObject(DynamicValue id);
        public abstract DynamicValue[] ScanContents();
        public abstract int GetIndex(DynamicValue id);
    }
}
