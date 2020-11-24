using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX => GetVariableValue((int)AP_Sector_Variables.Sector_X);

        public int SectorY => GetVariableValue((int)AP_Sector_Variables.Sector_Y);

        public int BackgroundID => GetVariableValue((int)AP_Sector_Variables.BackgroundID);

        public int OwningRaceDataScriptingObjectID => GetVariableValue((int)AP_Sector_Variables.OwningRaceDataScriptingObjectID);
        public ScriptingObject OwningRaceDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwningRaceDataScriptingObjectID);

        public int pShipScriptingObjectHashTableObject => GetVariableValue((int)AP_Sector_Variables.ShipScriptingObjectIDHashTable);
        public ScriptingHashTableObject ShipScriptingObjectHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pShipScriptingObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pGateScriptingObjectHashTableObject => GetVariableValue((int)AP_Sector_Variables.GateScriptingObjectIDHashTable);
        public ScriptingHashTableObject GateScriptingObjectHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pGateScriptingObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public bool IsValid => SectorX >= 0 && SectorX < GateSystemObject.width && SectorY >= 0 && SectorY < GateSystemObject.height;

        public int OwnerDataScriptingObjectID => GetVariableValue((int)AP_Sector_Variables.OwningRaceDataScriptingObjectID);
        public ScriptingObject OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public ScriptMemoryObject_AP_Sector() : base(56)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((AP_Sector_Variables)index).ToString();
        }

    }
}
