using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX => GetVariableValue((int)TC_Sector_Variables.Sector_X);

        public int SectorY => GetVariableValue((int)TC_Sector_Variables.Sector_Y);

        public int OwningRaceDataScriptingObjectID => throw new NotImplementedException();

        public ScriptInstance OwningRaceDataScriptingObject => throw new NotImplementedException();

        public int pShipScriptingObjectHashTableObject => GetVariableValue((int)TC_Sector_Variables.ShipScriptingObjectIDHashTable);

        public ScriptTableObject ShipScriptingObjectHashTableObject { get { ScriptTableObject table = new ScriptTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr) pShipScriptingObjectHashTableObject); table.ReloadFromMemory(); return table; }}

        public int pGateScriptingObjectHashTableObject => throw new NotImplementedException();

        public ScriptTableObject GateScriptingObjectHashTableObject => throw new NotImplementedException();

        public int BackgroundID => GetVariableValue((int)TC_Sector_Variables.BackgroundID);

        public bool IsValid => SectorX >= 0 && SectorX < GalaxyBase.width && SectorY >= 0 && SectorY < GalaxyBase.height;

        public int OwnerDataScriptingObjectID => throw new NotImplementedException();

        public ScriptInstance OwnerDataScriptingObject => throw new NotImplementedException();

        public int MusicId => throw new NotImplementedException();

        public ScriptMemoryObject_TC_Sector() : base(55)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((TC_Sector_Variables)index).ToString();
        }

    }
}
