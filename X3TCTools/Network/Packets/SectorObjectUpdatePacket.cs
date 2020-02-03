using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Network;
using Common.Vector;
using Common.Memory;

namespace X3TCTools.Network.Packets
{
    public class SectorObjectUpdate : ITransmittable
    {
        public const int ByteSize = (2*2) + (4*4) + (Vector3.ByteSize * 3) + RotationMatrix_4.ByteSize;

        // Main data
        public int ID;
        public SectorObjects.SectorObject.Main_Type MainType;
        public short SubType;

        public int Hull;

        // Speeds
        public int Speed;
        public int TargetSpeed;

        // Position
        public Vector3 Position;
        public Vector3 PositionStrafeDelta;

        // Rotation
        public Vector3 LocalRotationDelta;
        public RotationMatrix_4 Rotation = new RotationMatrix_4();

        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(ID);
            collection.Append((short)MainType);
            collection.Append(SubType);
            collection.Append(Hull);
            collection.Append(Speed);
            collection.Append(TargetSpeed);
            collection.Append(Position);
            collection.Append(PositionStrafeDelta);
            collection.Append(Rotation);
            collection.Append(LocalRotationDelta);
            return collection.GetBytes();
        }

        public void FromSectorObject(SectorObjects.SectorObject sectorObject)
        {
            ID = sectorObject.ObjectID;
            MainType = sectorObject.MainType;
            SubType = sectorObject.SubType;

            Hull = sectorObject.Hull;

            Speed = sectorObject.Speed;
            TargetSpeed = sectorObject.TargetSpeed;

            PositionStrafeDelta = sectorObject.PositionStrafeDelta;
            LocalRotationDelta = sectorObject.LocalEulerRotationDelta;

            // Data
            var data = sectorObject.GetData();

            Position = data.Position;
            Rotation = data.rotationMatrix;
        }

        /// <summary>
        /// Saves the values in this packet to a sector object.
        /// </summary>
        /// <param name="sectorObject"></param>
        public void ToSectorObject(ref SectorObjects.SectorObject sectorObject)
        {
            // Speed
            sectorObject.Speed = Speed;
            sectorObject.TargetSpeed = TargetSpeed;

            sectorObject.Hull = Hull;

            // Deltas
            sectorObject.LocalEulerRotationDelta = LocalRotationDelta;
            sectorObject.PositionStrafeDelta = PositionStrafeDelta;

            // Data
            var data = sectorObject.GetData();

            data.Position = Position;
            data.rotationMatrix = Rotation;

            sectorObject.Save();
            data.Save(sectorObject.pData);
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public byte GetDataType()
        {
            return (byte)GameNetworkManager.PacketTypes.SectorObjectUpdate;
        }

        public void SetData(byte[] Memory)
        {
            short tempshort = 0;  
            var collection = new ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref ID);
            collection.PopFirst(ref tempshort);
            MainType = (SectorObjects.SectorObject.Main_Type)tempshort;
            collection.PopFirst(ref SubType);
            collection.PopFirst(ref Hull);
            collection.PopFirst(ref Speed);
            collection.PopFirst(ref TargetSpeed);
            collection.PopFirst(ref Position);
            collection.PopFirst(ref PositionStrafeDelta);
            collection.PopFirst(ref Rotation);
            collection.PopFirst(ref LocalRotationDelta);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }
    }
}
