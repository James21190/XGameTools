using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Networking.SystemPackets
{
    internal class ConnectionRequestPacket : Packet
    {
        public ConnectionRequestPacket() : base(255)
        {
        }
    }
}
