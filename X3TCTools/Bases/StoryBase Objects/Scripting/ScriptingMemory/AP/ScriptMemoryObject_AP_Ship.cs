using System;
using X3Tools.Bases.SectorBase_Objects;

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
                ScriptTableObject cargoItems = GetVariable((int)AP_Ship_Variables.Cargo).GetAsHashTableObject();
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
        public ScriptInstance PreviousSectorScriptingObject => GameHook.storyBase.GetScriptingObject(PreviousSectorScriptingObjectID);
        public int CurrentSectorScriptingObjectID => GetVariableValue((int)AP_Ship_Variables.CurrentSectorScriptingObjectID);
        public ScriptInstance CurrentSectorScriptingObject => GameHook.storyBase.GetScriptingObject(CurrentSectorScriptingObjectID);

        public int OwnerDataScriptingObjectID => GetVariableValue((int)AP_Ship_Variables.OwningRaceDataScriptingObjectID);
        public ScriptInstance OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public int pCustomNameArrayObject => GetVariableValue((int)AP_Ship_Variables.CustomShipName);

        public ScriptArrayObject CustomNameArrayObject { get { ScriptArrayObject array = new ScriptArrayObject(); array.SetLocation(GameHook.hProcess, (IntPtr)pCustomNameArrayObject); array.ReloadFromMemory(); return array; } }

        public string CustomName { get
            {
                var array = CustomNameArrayObject;
                for(int i = 0; i < array.Count; i++)
                {
                    if(array.pDynamicValueArr[i].Flag == DynamicValue.FlagType.pTextObject)
                    {
                        var textobj = new ScriptStringObject();
                        textobj.SetLocation(GameHook.hProcess, (IntPtr)array.pDynamicValueArr[i].Value);
                        textobj.ReloadFromMemory();
                        return textobj.pText.obj.value;
                    }
                }
                return null;
            } 
        }

        public bool IsValid => SubType < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship);

        public override string GetVariableName(int index)
        {
            return ((AP_Ship_Variables)index).ToString();
        }

        public override string ToString()
        {
            var name = CustomName;
            if(name == null)
            {
                return SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, SubType);
            }
            return string.Format("{0} ({1})", SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, SubType), name);
        }
        public ScriptMemoryObject_AP_Ship() : base(VariableCount)
        {

        }
    }
}
