using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX
        {
            get
            {
                return GetVariableValue((int)AP_Sector_Variables.Sector_X);
            }
        }

        public int SectorY { get
            {
                return GetVariableValue((int)AP_Sector_Variables.Sector_Y);
            } 
        }

        public int OwningRaceDataEventObjectID { get { return GetVariableValue((int)AP_Sector_Variables.OwningRaceDataEventObjectID); } }
        public EventObject OwningRaceDataEventObject { get { return GameHook.storyBase.GetEventObject(OwningRaceDataEventObjectID); } }

        public int pShipEventObjectHashTableObject { get { return GetVariableValue((int)AP_Sector_Variables.ShipEventObjectIDHashTable); } }
        public ScriptingHashTableObject ShipEventObjectHashTableObject { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pShipEventObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pGateEventObjectHashTableObject { get { return GetVariableValue((int)AP_Sector_Variables.GateEventObjectIDHashTable); } }
        public ScriptingHashTableObject GateEventObjectHashTableObject { get { var table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pGateEventObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public ScriptMemoryObject_AP_Sector() : base(56)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((AP_Sector_Variables)index).ToString();
        }

    }
}
