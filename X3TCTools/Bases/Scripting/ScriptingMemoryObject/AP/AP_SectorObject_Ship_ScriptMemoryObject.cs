using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;

namespace X3TCTools.Bases.Scripting.ScriptingMemoryObject.AP
{
    public class AP_SectorObject_Ship_ScriptMemoryObject : ScriptingMemoryObject, IShip_ScriptMemoryObject
    {
        
        public AP_SectorObject_Ship_ScriptMemoryObject()
        {
            VariableCount = 95;
        }
        
        public enum VariableName
        {
            SubType = 14,
            Cargo = 35
        }

        public int GetVariableValue(VariableName variableName)
        {
            return GetVariableValue((int)variableName);
        }

        public void SetVariableValue(VariableName variableName, int value)
        {
            SetVariableValue((int)variableName, value);
        }

        public override string GetVariableName(int index)
        {
            return ((VariableName)index).ToString();
        }

        public int SubType { get { return GetVariableValue(VariableName.SubType); } set { SetVariableValue(VariableName.SubType, value); } }
        public CargoEntry[] Cargo { get { return GetCargo(); } }

        public CargoEntry[] GetCargo()
        {
            ReloadFromMemory();
            List<CargoEntry> entries = new List<CargoEntry>();
            var cargoHashTable = new ScriptingHashTableObject();
            cargoHashTable.SetLocation(m_hProcess, (IntPtr)GetVariableValue((int)VariableName.Cargo));
            cargoHashTable.ReloadFromMemory();
            foreach (var id in cargoHashTable.hashTable.ScanContents())
            {
                var type = SectorObject.Full_Type.FromInt(id.Value);
                var entry = new CargoEntry()
                {
                    Type = type,
                    Count = cargoHashTable.hashTable.GetObject(id).Value
                };
                entries.Add(entry);
            }
            entries.Sort();
            return entries.ToArray();
        }

        public int GetSubType()
        {
            return SubType;
        }

    }
}
