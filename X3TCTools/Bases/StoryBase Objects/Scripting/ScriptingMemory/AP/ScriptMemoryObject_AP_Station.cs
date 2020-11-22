using X3TCTools.Sector_Objects;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
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

        public int CurrentSectorEventObjectID => GetVariableValue((int)AP_Station_Variables.CurrentSectorEventObjectID);
        public ScriptingObject CurrentSectorEventObject => GameHook.storyBase.GetEventObject(CurrentSectorEventObjectID);

        public int pCargoHashTable => GetVariable((int)AP_Station_Variables.CargoHashTable).Value;

        public ScriptingHashTableObject CargoHashTable => GetVariable((int)AP_Station_Variables.CargoHashTable).GetAsHashTableObject();

        public int OwnerDataEventObjectID => GetVariableValue((int)AP_Station_Variables.OwningRaceDataEventObjectID);
        public ScriptingObject OwnerDataEventObject => GameHook.storyBase.GetEventObject(OwnerDataEventObjectID);

        public override string GetVariableName(int index)
        {
            return ((AP_Station_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Station() : base(VariableCount)
        {

        }
    }
}
