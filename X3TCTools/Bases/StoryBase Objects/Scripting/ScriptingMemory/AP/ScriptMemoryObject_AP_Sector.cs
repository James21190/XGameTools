using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX => GetVariableValue((int)AP_Sector_Variables.Sector_X);

        public int SectorY => GetVariableValue((int)AP_Sector_Variables.Sector_Y);

        public int BackgroundID => GetVariableValue((int)AP_Sector_Variables.BackgroundID);

        public int OwningRaceDataEventObjectID => GetVariableValue((int)AP_Sector_Variables.OwningRaceDataEventObjectID);
        public ScriptingObject OwningRaceDataEventObject => GameHook.storyBase.GetEventObject(OwningRaceDataEventObjectID);

        public int pShipEventObjectHashTableObject => GetVariableValue((int)AP_Sector_Variables.ShipEventObjectIDHashTable);
        public ScriptingHashTableObject ShipEventObjectHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pShipEventObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public int pGateEventObjectHashTableObject => GetVariableValue((int)AP_Sector_Variables.GateEventObjectIDHashTable);
        public ScriptingHashTableObject GateEventObjectHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pGateEventObjectHashTableObject); table.ReloadFromMemory(); return table; } }

        public bool IsValid => SectorX >= 0 && SectorX < GateSystemObject.width && SectorY >= 0 && SectorY < GateSystemObject.height;

        public int OwnerDataEventObjectID => GetVariableValue((int)AP_Sector_Variables.OwningRaceDataEventObjectID);
        public ScriptingObject OwnerDataEventObject => GameHook.storyBase.GetEventObject(OwnerDataEventObjectID);

        public ScriptMemoryObject_AP_Sector() : base(56)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((AP_Sector_Variables)index).ToString();
        }

    }
}
