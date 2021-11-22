using CommonToolLib.Networking;

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
