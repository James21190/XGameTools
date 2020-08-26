using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Station : ScriptMemoryObject, IScriptMemoryObject_Station
    {
        public new const int VariableCount = 53;

        public int MainType { get { return GetVariableValue((int)AP_Station_Variables.MainType); } }
        public int SubType { get { return GetVariableValue((int)AP_Station_Variables.SubType); } }

        public CargoEntry[] Cargo
        {
            get
            {
                var cargoItems = CargoHashTable;
                CargoEntry[] entries = new CargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (var id in cargoItems.hashTable.ScanContents())
                {
                    var entryType = SectorObject.Full_Type.FromInt(id.Value);
                    var entryCapacity = TypeData.GetDockWareCapacity(entryType.MainType, entryType.SubType);
                    entries[i++] = new CargoEntry()
                    {
                        Type = entryType,
                        Count = cargoItems.hashTable.GetObject(id).Value
                    };
                }
                return entries;
            }
        }

        public int CurrentSectorEventObjectID { get { return GetVariableValue((int)AP_Station_Variables.CurrentSectorEventObjectID); } }
        public EventObject CurrentSectorEventObject { get { return GameHook.storyBase.GetEventObject(CurrentSectorEventObjectID); } }

        public int pCargoHashTable
        {
            get { return GetVariable((int)AP_Station_Variables.CargoHashTable).Value; } 
        }

        public ScriptingHashTableObject CargoHashTable
        {
            get { return GetVariable((int)AP_Station_Variables.CargoHashTable).GetAsHashTableObject(); }
        }

        public override string GetVariableName(int index)
        {
            return ((AP_Station_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Station() : base(VariableCount)
        {

        }
    }
}
