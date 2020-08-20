using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Factory : IMemoryObject
    {
        int SubType { get; }
        StationCargoEntry[] Cargo { get; }
    }
}
