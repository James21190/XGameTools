using System;
using X3Tools.RAM.Bases.Sector;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Station : ScriptMemoryObject, IScriptMemoryObject_Station
    {
        public new const int VariableCount = 51;

        public int MainType => GetVariableValue((int)TC_Station_Variables.MainType);

        public int SubType => GetVariableValue((int)TC_Station_Variables.SubType);

        public int CurrentSectorScriptingObjectID => GetVariableValue((int)TC_Station_Variables.CurrentSectorScriptingObjectID);

        public ScriptInstance CurrentSectorScriptingObject => GameHook.storyBase.GetScriptingObject(CurrentSectorScriptingObjectID);

        public int pCargoHashTable => GetVariable((int)TC_Station_Variables.CargoHashTable).Value;

        public ScriptTableObject CargoHashTable => GetVariable((int)TC_Station_Variables.CargoHashTable).GetAsHashTableObject();

        public CargoEntry[] CargoEntries
        {
            get
            {
                ScriptTableObject cargoItems = CargoHashTable;
                CargoEntry[] entries = new CargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (DynamicValue id in cargoItems.hashTable.ScanContents())
                {
                    SectorObject.SectorObjectType entryType = SectorObject.SectorObjectType.FromInt(id.Value);
                    entries[i++] = new CargoEntry()
                    {
                        Type = entryType,
                        Count = cargoItems.hashTable.GetObject(id).Value
                    };
                }
                return entries;
            }
        }

        public int OwnerDataScriptingObjectID => GetVariableValue((int)TC_Station_Variables.OwningRaceDataScriptingObjectID);
        public ScriptInstance OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public override string GetVariableName(int index)
        {
            return ((TC_Station_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Station() : base(VariableCount)
        {

        }
    }
}
