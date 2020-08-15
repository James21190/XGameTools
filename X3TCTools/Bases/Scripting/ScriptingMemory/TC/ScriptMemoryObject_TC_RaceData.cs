using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData : ScriptMemoryObject, IScriptMemoryObject_RaceData
    {
        public const int VariableCount = 9;

        public int ASectorEventObjectID { get { return GetVariableValue((int)TC_RaceData_Variables.ASectorEventObjectID); } }
        public EventObject ASectorEventObject { get { return GameHook.storyBase.GetEventObject(ASectorEventObjectID); } }

        public int pOwnedShipEventObjectIDHashTableObject { get { return GetVariableValue((int)TC_RaceData_Variables.OwnedShipEventObjectIDHashTable); } }
        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public int RaceID { get { return GetVariableValue((int)TC_RaceData_Variables.RaceID); } }

        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData() : base(VariableCount)
        {

        }
    }
}
