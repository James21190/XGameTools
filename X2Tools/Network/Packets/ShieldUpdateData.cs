using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Network;
using X2Tools.X2.SectorObjects;
using X2Tools.X2.SectorObjects.Meta;

namespace X2Tools.Network.Packet
{
    class ShieldUpdateData : ITransmittable
    {
        public const int ByteSize = 8;

        public int SectorObjectID = 0;
        public byte Shield_1MW = 0;
        public byte Shield_5MW = 0;
        public byte Shield_25MW = 0;
        public byte Shield_125MW = 0;

        public ShieldUpdateData(SectorObject sectorObject, GameHook gameHook)
        {
            SectorObjectID = sectorObject.SectorObjectID;
            SectorObject start;
            switch (sectorObject.MainType) 
            {
                case SectorObject.Main_Type.Ship:
                    start = ((ShipMeta)sectorObject.GetMetaData()).pFirstChild.obj;
                    break;
                default:
                    throw new NotImplementedException();
            }
            foreach (var shield in gameHook.SectorObjectManager.GetSectorObjectsWithType(start, SectorObject.Main_Type.Shield, false))
            {
                switch ((SectorObject.Shield_Sub_Type)shield.SubType)
                {
                    case SectorObject.Shield_Sub_Type.Shield_1MW: Shield_1MW++; break;
                    case SectorObject.Shield_Sub_Type.Shield_5MW: Shield_5MW++; break;
                    case SectorObject.Shield_Sub_Type.Shield_25MW: Shield_25MW++; break;
                    case SectorObject.Shield_Sub_Type.Shield_125MW: Shield_125MW++; break;
                }
            }
        }

        public ShieldUpdateData()
        {

        }
        public byte[] GetBytes()
        {
            var collection = new Common.Memory.ObjectByteList();
            collection.Append(SectorObjectID);
            collection.Append(Shield_1MW);
            collection.Append(Shield_5MW);
            collection.Append(Shield_25MW);
            collection.Append(Shield_125MW);
            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public byte GetDataType()
        {
            return (byte)GameNetworkManager.PacketTypes.ShieldUpdateData;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new Common.Memory.ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref SectorObjectID);
            collection.PopFirst(ref Shield_1MW);
            collection.PopFirst(ref Shield_5MW);
            collection.PopFirst(ref Shield_25MW);
            collection.PopFirst(ref Shield_125MW);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }
    }
}
