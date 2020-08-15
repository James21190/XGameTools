using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Gate : ScriptMemoryObject, IScriptMemoryObject_Gate
    {
        public int DestSectorX
        {
            get { return GetVariableValue((int)AP_Gate_Variables.Dest_Sector_X); }
        }

        public int DestSectorY
        {
            get { return GetVariableValue((int)AP_Gate_Variables.Dest_Sector_Y); }
        }

        public int DestSectorDataEventObjectID { get { return GetVariableValue((int)AP_Gate_Variables.DestSectorDataEventObjectID); } }
        public EventObject DestSectorDataEventObject { get { return GameHook.storyBase.GetEventObject(DestSectorDataEventObjectID); } }

        public override string GetVariableName(int index)
        {
            return ((AP_Gate_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Gate() : base(20)
        {

        }
    }
}
