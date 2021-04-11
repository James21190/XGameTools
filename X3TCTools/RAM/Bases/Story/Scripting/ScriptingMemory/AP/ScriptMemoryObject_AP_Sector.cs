using System;
using X3Tools.RAM.Bases.Galaxy;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX => GetVariableValue((int)AP_Sector_Variables.Sector_X);

        public int SectorY => GetVariableValue((int)AP_Sector_Variables.Sector_Y);

        public int BackgroundID => GetVariableValue((int)AP_Sector_Variables.BackgroundID);

        public int OwningRaceDataScriptingObjectID => GetVariableValue((int)AP_Sector_Variables.OwningRaceDataScriptingObjectID);
        public ScriptInstance OwningRaceDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwningRaceDataScriptingObjectID);

        public int pShipScriptingObjectHashTableObject => GetVariableValue((int)AP_Sector_Variables.ShipScriptingObjectIDHashTable);
        public ScriptTableObject ShipScriptingObjectHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pShipScriptingObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pGateScriptingObjectHashTableObject => GetVariableValue((int)AP_Sector_Variables.GateScriptingObjectIDHashTable);
        public ScriptTableObject GateScriptingObjectHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pGateScriptingObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public bool IsValid => SectorX >= 0 && SectorX < GalaxyBase.width && SectorY >= 0 && SectorY < GalaxyBase.height;

        public int OwnerDataScriptingObjectID => GetVariableValue((int)AP_Sector_Variables.OwningRaceDataScriptingObjectID);
        public ScriptInstance OwnerDataScriptingObject => GameHook.storyBase.GetScriptingObject(OwnerDataScriptingObjectID);

        public int MusicId => throw new NotImplementedException();

        public ScriptMemoryObject_AP_Sector() : base(56)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((AP_Sector_Variables)index).ToString();
        }

    }
}
