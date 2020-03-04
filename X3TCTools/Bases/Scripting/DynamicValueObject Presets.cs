using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting
{
    public sealed partial class DynamicValueObject
    {
        public static DynamicValueObject GetSectorObjectShip()
        {
            return new DynamicValueObject("ShipVariables", new string[]
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "SubType",
                "13",
                "14",
                "15",
                "16",
                "17",
                "Hull",
                "19",
                "20",
                "21",
                "22",
                "23",
                "24",
                "25",
                "26",
                "27",
                "28",
                "29",
                "30",
                "31",
                "32",
                "CargoInfo"
            });
        }
    }
}
