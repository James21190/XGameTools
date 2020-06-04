using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public partial class TypeData_Ship
    {
        public enum Class
        {
            TL_Large_Transporter,
            TS_Transporter,
            M1_Carrier = 3,
            M2_Destroyer,
            M3_Heavy_Fighter,
            M4_Interceptor,
            M5_Scout,
            M6_Corvette = 11,
            M7_Frigate = 13,
            TM_Military_Transport,
            M8_Bomber,
        }
    }
}
