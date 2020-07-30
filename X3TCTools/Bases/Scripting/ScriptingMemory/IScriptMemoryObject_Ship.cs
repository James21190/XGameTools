using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Ship
    {
        int SubType { get; }
        CargoEntry[] CargoEntries { get; }
        int ParentSectorEventObjectID { get; }
        EventObject ParentSectorEventObject { get; }
    }
}
