using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases
{
    public partial class EventObject
    {
        public const int ShipVariableCount = 20;
        public enum ShipVariables
        {
            SubType = 12,
            CustomShipNameID = 16,
            Hull = 18,
        }
    }
}
