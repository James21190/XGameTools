using System;
using X3Tools.Sector_Objects;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Ship : ScriptMemoryObject, IScriptMemoryObject_Ship
    {
        public int SubType => GetVariableValue((int)TC_Ship_Variables.SubType);
        public CargoEntry[] CargoEntries
        {
            get
            {
                ScriptingHashTableObject cargoItems = GetVariable((int)TC_Ship_Variables.Cargo).GetAsHashTableObject();
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
        public int PreviousSectorEventObjectID => GetVariableValue((int)TC_Ship_Variables.PreviousSectorEventObjectID);
        public ScriptingObject PreviousSectorEventObject => GameHook.storyBase.GetEventObject(PreviousSectorEventObjectID);

        public int CurrentSectorEventObjectID => GetVariableValue((int)TC_Ship_Variables.CurrentSectorEventObjectID);
        public ScriptingObject CurrentSectorEventObject => GameHook.storyBase.GetEventObject(CurrentSectorEventObjectID);

        public bool IsValid => SubType < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship);

        public int OwnerDataEventObjectID => GetVariableValue((int)TC_Ship_Variables.OwningRaceDataEventObjectID);

        public ScriptingObject OwnerDataEventObject => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_Ship_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_Ship() : base(95)
        {

        }
    }
}
