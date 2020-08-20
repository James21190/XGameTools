using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Dock : ScriptMemoryObject, IScriptMemoryObject_Dock
    {
        public const int VariableCount = 53;

        public int SubType { get { return GetVariableValue((int)AP_Dock_Variables.SubType); } }

        public StationCargoEntry[] Cargo
        {
            get
            {
                var cargoItems = GetVariable((int)AP_Dock_Variables.CargoHashTable).GetAsHashTableObject();
                var priceItems = GetVariable((int)AP_Dock_Variables.CargoPriceHashTable).GetAsHashTableObject();
                StationCargoEntry[] entries = new StationCargoEntry[priceItems.hashTable.Count];
                int i = 0;
                foreach (var id in priceItems.hashTable.ScanContents())
                {
                    var entryType = SectorObject.Full_Type.FromInt(id.Value);
                    var entryCapacity = TypeData.GetDockWareCapacity(entryType.MainType, entryType.SubType);
                    if (cargoItems.hashTable.ContainsObject(id))
                        entries[i++] = new StationCargoEntry()
                        {
                            Type = entryType,
                            Count = cargoItems.hashTable.GetObject(id).Value,
                            Capacity = entryCapacity,
                            Price = priceItems.hashTable.GetObject(id).Value
                        };
                    else
                        entries[i++] = new StationCargoEntry()
                        {
                            Type = entryType,
                            Count = 0,
                            Capacity = entryCapacity,
                            Price = priceItems.hashTable.GetObject(id).Value
                        };
                }
                return entries;
            }
        }

        public override string GetVariableName(int index)
        {
            return ((AP_Dock_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Dock() : base(VariableCount)
        {

        }
    }
}
