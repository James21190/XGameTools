using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.Scripting.ScriptingMemory.TC;

namespace X3TCTools.Bases.Scripting
{
    public partial class EventObject
    {
        public enum EventObject_Type
        {
            Unknown,
            Unknown_Ship,
            Unknown_Station,

            Station_Trading,
            Station_Equipment,
            Station_Factory,
            Station_Shipyard,
            Station_Unknown_3,

            Ship_Player,
            Ship_Unknown_1,
            Ship_Unknown_2,
            Ship_Unknown_3,
            Ship_Unknown_4,
            Ship_Unknown_5,

            Sector,
            
            Planet,

            Sun,

            Gate,

            RaceData,
            RaceData_Player,
        }
    }
}
