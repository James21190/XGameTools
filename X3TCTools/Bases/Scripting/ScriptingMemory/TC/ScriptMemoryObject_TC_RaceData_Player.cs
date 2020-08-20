using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID { get { return GameHook.RaceID.Player; } }

        public int ASectorEventObjectID => throw new NotImplementedException();

        public EventObject ASectorEventObject => throw new NotImplementedException();

        public int pOwnedShipEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pRaceDataWithSectorsEventObjectIDHashTable => throw new NotImplementedException();

        public ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable => throw new NotImplementedException();

        public int pRaceDataEventObjectIDHashTable => throw new NotImplementedException();

        public ScriptingHashTableObject RaceDataEventObjectIDHashTable => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
