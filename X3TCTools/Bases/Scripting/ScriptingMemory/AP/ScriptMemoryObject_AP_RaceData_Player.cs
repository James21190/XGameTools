using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID { get { return GameHook.RaceID.Player; } }

        public int ASectorEventObjectID => throw new NotImplementedException();

        public EventObject ASectorEventObject => throw new NotImplementedException();

        public int pOwnedShipEventObjectIDHashTableObject { get { return GetVariableValue((int)AP_RaceData_Player_Variables.OwnedShipEventObjectIDHashTable); } }
        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public int pOwnedStationEventObjectIDHashTableObject { get { return GetVariableValue((int)AP_RaceData_Player_Variables.OwnedStationEventObjectIDHashTable); } }
        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pRaceDataWithSectorsEventObjectIDHashTable { get { return GetVariableValue((int)AP_RaceData_Player_Variables.RaceDataWithSectorEventObjectIDHashTable); } }

        public ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataWithSectorsEventObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public int pRaceDataEventObjectIDHashTable { get { return GetVariableValue((int)AP_RaceData_Player_Variables.RaceDataEventObjectIDHashTable); } }

        public ScriptingHashTableObject RaceDataEventObjectIDHashTable { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pRaceDataEventObjectIDHashTable); table.ReloadFromMemory(); return table; } }

        public override string GetVariableName(int index)
        {
            return ((AP_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
