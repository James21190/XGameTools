using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Ship : ScriptingMemoryObject, IScriptMemoryObject_Ship
    {
        public int SubType { get { return GetVariableValue((int)TC_Ship_Variables.SubType); } }
        public CargoEntry[] CargoEntries
        {
            get
            {
                var cargoItems = GetVariable((int)TC_Ship_Variables.Cargo).GetAsHashTableObject();
                CargoEntry[] entries = new CargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (var id in cargoItems.hashTable.ScanContents())
                {
                    entries[i++] = new CargoEntry()
                    {
                        Type = SectorObject.Full_Type.FromInt(id.Value),
                        Count = cargoItems.hashTable.GetObject(id).Value
                    };
                }
                return entries;
            }
        }
        public int PreviousSectorEventObjectID { get { return GetVariableValue((int)TC_Ship_Variables.PreviousSectorEventObjectID); } }
        public EventObject PreviousSectorEventObject { get { return GameHook.storyBase.GetEventObject(PreviousSectorEventObjectID); } }

        public int CurrentSectorEventObjectID { get { return GetVariableValue((int)TC_Ship_Variables.CurrentSectorEventObjectID); } }
        public EventObject CurrentSectorEventObject { get { return GameHook.storyBase.GetEventObject(CurrentSectorEventObjectID); } }

        public override string GetVariableName(int index)
        {
            return ((TC_Ship_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Ship() : base(95)
        {

        }
    }
}
