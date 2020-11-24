using X3Tools.Sector_Objects;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Ship : ScriptMemoryObject, IScriptMemoryObject_Ship
    {
        public const int VariableCount = 108;
        public int SubType => GetVariableValue((int)AP_Ship_Variables.SubType);
        public CargoEntry[] CargoEntries
        {
            get
            {
                ScriptingHashTableObject cargoItems = GetVariable((int)AP_Ship_Variables.Cargo).GetAsHashTableObject();
                CargoEntry[] entries = new CargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (DynamicValue id in cargoItems.hashTable.ScanContents())
                {
                    entries[i++] = new CargoEntry()
                    {
                        Type = SectorObject.SectorObjectType.FromInt(id.Value),
                        Count = cargoItems.hashTable.GetObject(id).Value
                    };
                }
                return entries;
            }
        }
        public int PreviousSectorScriptingObjectID => GetVariableValue((int)AP_Ship_Variables.PreviousSectorScriptingObjectID);
        public ScriptingObject PreviousSectorScriptingObject => GameHook.storyBase.GetScriptingObject(PreviousSectorScriptingObjectID);
        public int CurrentSectorScriptingObjectID => GetVariableValue((int)AP_Ship_Variables.CurrentSectorScriptingObjectID);
        public ScriptingObject CurrentSectorScriptingObject => GameHook.storyBase.GetScriptingObject(CurrentSectorScriptingObjectID);

        public int OwnerDataScriptingObjectID => GetVariableValue((int)AP_Ship_Variables.OwningRaceDataScriptingObjectID);
        public ScriptingObject OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public bool IsValid => SubType < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship);

        public override string GetVariableName(int index)
        {
            return ((AP_Ship_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Ship() : base(VariableCount)
        {

        }
    }
}
