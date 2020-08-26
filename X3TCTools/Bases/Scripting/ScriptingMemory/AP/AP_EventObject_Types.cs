using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting
{
    public partial class EventObject
    {
        public enum AP_EventObject_Type
        {
            RaceData_Player = 400,
            RaceData,

            Sector = 2001,
            Planet,

            Sun = 2008,

            Gate = 2014,

            Ship_1 = 2021,

            Ship_2 = 2024,

            Ship_Player = 2026,

            Ship_3 = 2030,
            Ship_4,
            Ship_5,


            Station_Factory = 2006,

            Station_Trading = 2074,
            Station_Equipment,

            Station_Shipyard = 2082,

            Station_3 = 2148,

        }
    }
}
