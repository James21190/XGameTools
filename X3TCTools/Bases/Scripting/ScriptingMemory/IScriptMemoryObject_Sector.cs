using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Sector : IMemoryObject
    {
        int SectorX { get; }
        int SectorY { get; }

        int BackgroundID { get; }

        int OwningRaceDataEventObjectID { get; }
        EventObject OwningRaceDataEventObject { get; }

        int pShipEventObjectHashTableObject { get; }
        ScriptingHashTableObject ShipEventObjectHashTableObject { get; }

        int pGateEventObjectHashTableObject { get; }
        ScriptingHashTableObject GateEventObjectHashTableObject { get; }

    }
}
