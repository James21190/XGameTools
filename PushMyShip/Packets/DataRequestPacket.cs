using CommonToolLib.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushMyShip.Packets
{
    public class DataRequestPacket : Packet
    {
        public DataRequestPacket() : base((byte)PushMyShip.Packets.PacketType.DataRequest)
        {

        }

        public enum Request
        {
            SectorData,
            DetailedObject,
        }
    }
}
