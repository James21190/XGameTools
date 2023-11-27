using CommonToolLib.Generics;
using CommonToolLib.Networking;
using CommonToolLib.ProcessHooking;
using XCommonLib.RAM;

namespace PushMyShip.Packets
{
    public class SectorDataPacket : Packet
    {
        public struct SectorObjectData : IBinaryObject
        {
            public int ID;
            public GameHook.GeneralRaces Race;
            public Vector3_32 Position;

            public int ByteSize => 18;

            public byte[] GetBytes()
            {
                var obl = new MemoryObjectConverter();
                obl.Append(ID);
                obl.Append((short)Race);
                obl.Append(Position);
                return obl.GetBytes();
            }

            public SetDataResult SetData(byte[] Memory)
            {
                var obl = new MemoryObjectConverter(Memory);
                ID = obl.PopInt();
                Race = (GameHook.GeneralRaces)obl.PopShort();
                Position = obl.PopIMemoryObject<Vector3_32>();
                return SetDataResult.Success;
            }
        }

        public SectorObjectData[] SectorObjects;

        public SectorDataPacket() : base((byte)PushMyShip.Packets.PacketType.SectorData)
        {

        }

        public override byte[] Data
        {
            get
            {
                var obl = new MemoryObjectConverter();
                obl.Append(SectorObjects);
                return obl.GetBytes();
            }
            set
            {
                var number = value.Length / 18;
                var obl = new MemoryObjectConverter(value);
                SectorObjects = obl.PopIBinaryObject<SectorObjectData>(number);
            }
        }
    }
}
