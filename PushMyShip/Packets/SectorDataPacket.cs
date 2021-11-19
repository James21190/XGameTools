using CommonToolLib.Generics;
using CommonToolLib.Networking;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var obl = new ObjectByteList();
                obl.Append(ID);
                obl.Append((short)Race);
                obl.Append(Position);
                return obl.GetBytes();
            }

            public void SetData(byte[] Memory)
            {
                var obl = new ObjectByteList(Memory);
                ID = obl.PopInt();
                Race = (GameHook.GeneralRaces)obl.PopShort();
                Position = obl.PopIMemoryObject<Vector3_32>();
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
                var obl = new ObjectByteList();
                obl.Append(SectorObjects);
                return obl.GetBytes();
            }
            set
            {
                var number = value.Length / 18;
                var obl = new ObjectByteList(value);
                SectorObjects = obl.PopIBinaryObject<SectorObjectData>(number);
            }
        }
    }
}
