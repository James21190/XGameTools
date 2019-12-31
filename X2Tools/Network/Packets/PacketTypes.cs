using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Network;

namespace X2Tools.Network
{
    public partial class GameNetworkManager
    {
        public enum PacketTypes
        {
            ShipUpdateData = 3,
            ShieldUpdateData
        }
    }
}
