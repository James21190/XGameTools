using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Factory : ScriptMemoryObject, IScriptMemoryObject_Factory
    {
        public const int VariableCount = 70;

        public int SubType { get
            {
                return GetVariableValue((int)AP_Factory_Variables.SubType);
            } }

        public StationCargoEntry[] Cargo
        {
            get
            {
                var cargoItems = GetVariable((int)AP_Factory_Variables.CargoHashTable).GetAsHashTableObject();
                StationCargoEntry[] entries = new StationCargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (var id in cargoItems.hashTable.ScanContents())
                {
                    var entryType = SectorObject.Full_Type.FromInt(id.Value);
                    var entryCapacity = TypeData.GetFactoryWareCapacity(entryType.MainType, entryType.SubType);
                    var entryPrice = TypeData.GetPrice(entryType.MainType, entryType.SubType, (cargoItems.hashTable.GetObject(id).Value / entryCapacity));
                    entries[i++] = new StationCargoEntry()
                    {
                        Type = entryType,
                        Count = cargoItems.hashTable.GetObject(id).Value,
                        Capacity = entryCapacity,
                        Price = entryPrice
                    };
                }
                return entries;
            }
        }

        public override string GetVariableName(int index)
        {
            return ((AP_Factory_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Factory() : base(VariableCount)
        {

        }
    }
}
