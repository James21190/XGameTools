using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_RaceData : ScriptMemoryObject, IScriptMemoryObject_RaceData
    {
        public const int VariableCount = 9;

        public int ASectorEventObjectID { get { return GetVariableValue((int)AP_RaceData_Variables.ASectorEventObjectID); } }
        public EventObject ASectorEventObject { get { return GameHook.storyBase.GetEventObject(ASectorEventObjectID); } }

        public int pOwnedShipEventObjectIDHashTableObject { get { return GetVariableValue((int)AP_RaceData_Variables.OwnedShipEventObjectIDHashTable); } }
        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public GameHook.RaceID RaceID { get { return (GameHook.RaceID)GetVariableValue((int)AP_RaceData_Variables.RaceID); } }

        public int pOwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((AP_RaceData_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_RaceData() : base(VariableCount)
        {

        }
    }
}
