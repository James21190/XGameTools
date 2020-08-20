using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData_Player : IScriptMemoryObject_RaceData
    {
        int pRaceDataWithSectorsEventObjectIDHashTable { get; }
        ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable { get; }
        int pRaceDataEventObjectIDHashTable { get; }
        ScriptingHashTableObject RaceDataEventObjectIDHashTable { get; }
    }
}
