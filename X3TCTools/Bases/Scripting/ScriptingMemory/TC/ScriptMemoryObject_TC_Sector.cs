using System;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_Sector : ScriptMemoryObject, IScriptMemoryObject_Sector
    {
        public int SectorX => GetVariableValue((int)TC_Sector_Variables.Sector_X);

        public int SectorY => GetVariableValue((int)TC_Sector_Variables.Sector_Y);

        public int OwningRaceDataEventObjectID => throw new NotImplementedException();

        public EventObject OwningRaceDataEventObject => throw new NotImplementedException();

        public int pShipEventObjectHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject ShipEventObjectHashTableObject => throw new NotImplementedException();

        public int pGateEventObjectHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject GateEventObjectHashTableObject => throw new NotImplementedException();

        public int BackgroundID => throw new NotImplementedException();

        public bool IsValid => SectorX >= 0 && SectorX < GateSystemObject.width && SectorY >= 0 && SectorY < GateSystemObject.height;

        public int OwnerDataEventObjectID => throw new NotImplementedException();

        public EventObject OwnerDataEventObject => throw new NotImplementedException();

        public ScriptMemoryObject_TC_Sector() : base(55)
        {

        }

        public override string GetVariableName(int index)
        {
            return ((TC_Sector_Variables)index).ToString();
        }

    }
}
