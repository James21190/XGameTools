using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Vector;
using X2Tools.X2.SectorObjects;
using Common.Memory;

namespace X2Tools.Network.Packet
{

    public class ShipUpdateData : Common.Network.ITransmittable
    {
        public const int ByteSize = (Vector3.ByteSize * 4) + RotationMatrix_3.ByteSize + (4 * 6);

        public int SectorObjectID, Main_Type, Sub_Type, Speed, TargetSpeed, Hull;
        public Vector3 Position, PositionDelta, LocalRotationDelta, StrafePositionDelta;
        public RotationMatrix_3 Rotation = new RotationMatrix_3();

        public ShipUpdateData(SectorObject sectorObject)
        {
            FromSectorObject(sectorObject);
        }

        public ShipUpdateData()
        {
            
        }

        /// <summary>
        /// Set values from a SectorObject.
        /// </summary>
        /// <param name="sectorObject"></param>
        public void FromSectorObject(SectorObject sectorObject)
        {
            Main_Type = (int)sectorObject.MainType;
            Sub_Type = sectorObject.SubType;
            SectorObjectID = sectorObject.SectorObjectID;

            var data = sectorObject.GetData();
            var meta = sectorObject.GetMetaData();

            // Data variables
            Position = data.Position;
            PositionDelta = data.PositionDelta;
            Rotation = data.RotationMatrix;

            LocalRotationDelta = sectorObject.LocalRotationDelta;
            StrafePositionDelta = sectorObject.StrafePositionDelta;
            Speed = sectorObject.Speed;
            TargetSpeed = sectorObject.TargetSpeed;
            Hull = sectorObject.Hull;
        }

        /// <summary>
        /// Save the values of this object to a SectorObject.
        /// </summary>
        /// <param name="sectorObject"></param>
        public void ToSectorObject(SectorObject sectorObject)
        {

            var data = sectorObject.GetData();

            data.Position = Position;
            data.RotationMatrix = Rotation;
            data.PositionDelta = PositionDelta;

            sectorObject.SaveData(data);
            
            sectorObject.LocalRotationDelta = LocalRotationDelta;
            sectorObject.StrafePositionDelta = StrafePositionDelta;
            sectorObject.Speed = Speed;
            sectorObject.TargetSpeed = TargetSpeed;
            sectorObject.Hull = Hull;
            sectorObject.Save();
        }

        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(Main_Type);
            collection.Append(Sub_Type);
            collection.Append(SectorObjectID);
            collection.Append(Position);
            collection.Append(PositionDelta);
            collection.Append(LocalRotationDelta);
            collection.Append(StrafePositionDelta);
            collection.Append(Rotation);
            collection.Append(Speed);
            collection.Append(TargetSpeed);
            collection.Append(Hull);
            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);
            collection.PopFirst(ref Main_Type);
            collection.PopFirst(ref Sub_Type);
            collection.PopFirst(ref SectorObjectID);
            collection.PopFirst(ref Position);
            collection.PopFirst(ref PositionDelta);
            collection.PopFirst(ref LocalRotationDelta);
            collection.PopFirst(ref StrafePositionDelta);
            collection.PopFirst(ref Rotation);
            collection.PopFirst(ref Speed);
            collection.PopFirst(ref TargetSpeed);
            collection.PopFirst(ref Hull);
        }

        public byte GetDataType()
        {
            return (byte)GameNetworkManager.PacketTypes.ShipUpdateData;
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }
    }
}
