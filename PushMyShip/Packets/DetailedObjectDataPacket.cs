using CommonToolLib.Generics;
using CommonToolLib.Networking;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushMyShip.Packets
{
    public class DetailedObjectDataPacket : Packet
    {
        public int Speed;
        public int DesiredSpeed;
        public Vector3_32 Position;

        public DetailedObjectDataPacket() : base((byte)PushMyShip.Packets.PacketType.DetailedObjectData)
        {
        }

        public override byte[] Data
        {
            get
            {
                var obl = new MemoryObjectConverter();
                obl.Append(Speed);
                obl.Append(DesiredSpeed);
                obl.Append(Position);
                return obl.GetBytes();
            }
            set
            {
                var obl = new MemoryObjectConverter(value);
                Speed = obl.PopInt();
                DesiredSpeed = obl.PopInt();
                Position = obl.PopIMemoryObject<Vector3_32>();
            }
        }
    }
}
