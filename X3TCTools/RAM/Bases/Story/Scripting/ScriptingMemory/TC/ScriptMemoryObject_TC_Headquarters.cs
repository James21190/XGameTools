using System;
using X3Tools.RAM.Bases.Sector;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Headquarters : ScriptMemoryObject, IScriptMemoryObject_Headquarters
    {
        public new const int VariableCount = 86;

        public int MainType => GetVariableValue((int)TC_Headquarters_Variables.MainType);

        public int SubType => GetVariableValue((int)TC_Headquarters_Variables.SubType);

        public int CurrentSectorScriptingObjectID => GetVariableValue((int)TC_Headquarters_Variables.CurrentSectorScriptingObjectID);

        public ScriptInstance CurrentSectorScriptingObject => GameHook.storyBase.GetScriptingObject(CurrentSectorScriptingObjectID);

        public int pCargoHashTable => GetVariable((int)TC_Headquarters_Variables.CargoHashTable).Value;

        public ScriptTableObject CargoHashTable => GetVariable((int)TC_Headquarters_Variables.CargoHashTable).GetAsHashTableObject();

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

        public int OwnerDataScriptingObjectID => GetVariableValue((int)TC_Headquarters_Variables.OwningRaceDataScriptingObjectID);
        public ScriptInstance OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public int pAvailableBlueprintHashTable => GetVariable((int)TC_Headquarters_Variables.AvailableBlueprintHashTable).Value;

        public ScriptTableObject AvailableBlueprintHashTable => GetVariable((int)TC_Headquarters_Variables.AvailableBlueprintHashTable).GetAsHashTableObject();

        public SectorObject.SectorObjectType[] AvailableBlueprints
        {
            get
            {
                ScriptTableObject cargoItems = AvailableBlueprintHashTable;
                SectorObject.SectorObjectType[] entries = new SectorObject.SectorObjectType[cargoItems.hashTable.Count];
                int i = 0;
                foreach (DynamicValue id in cargoItems.hashTable.ScanContents())
                {
                    entries[i++] = SectorObject.SectorObjectType.FromInt(id.Value);
                }
                Array.Sort(entries);
                Array.Reverse(entries);
                return entries;
            }
        }

        public override string GetVariableName(int index)
        {
            return ((TC_Headquarters_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Headquarters() : base(VariableCount)
        {

        }
    }
}
