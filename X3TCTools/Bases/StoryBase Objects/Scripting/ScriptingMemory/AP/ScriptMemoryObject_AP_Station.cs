using X3Tools.Bases.SectorBase_Objects;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Station : ScriptMemoryObject, IScriptMemoryObject_Station
    {
        public new const int VariableCount = 53;

        public int MainType => GetVariableValue((int)AP_Station_Variables.MainType);
        public int SubType => GetVariableValue((int)AP_Station_Variables.SubType);

        public CargoEntry[] CargoEntries
        {
            get
            {
                ScriptingHashTableObject cargoItems = CargoHashTable;
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

        public int CurrentSectorScriptingObjectID => GetVariableValue((int)AP_Station_Variables.CurrentSectorScriptingObjectID);
        public ScriptingObject CurrentSectorScriptingObject => GameHook.storyBase.GetScriptingObject(CurrentSectorScriptingObjectID);

        public int pCargoHashTable => GetVariable((int)AP_Station_Variables.CargoHashTable).Value;

        public ScriptingHashTableObject CargoHashTable => GetVariable((int)AP_Station_Variables.CargoHashTable).GetAsHashTableObject();

        public int OwnerDataScriptingObjectID => GetVariableValue((int)AP_Station_Variables.OwningRaceDataScriptingObjectID);
        public ScriptingObject OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public override string GetVariableName(int index)
        {
            return ((AP_Station_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Station() : base(VariableCount)
        {

        }
    }
}
