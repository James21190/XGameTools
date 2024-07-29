using CommonToolLib.Generics;
using CommonToolLib.Generics.BinaryObjects;
using CommonToolLib.ProcessHooking;
using System.Collections.Generic;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector;

namespace XWrapperLib.Networking
{
    public class UniverseManager
    {
        private GameHook _GameHook;

        public UniverseManager(GameHook gameHook)
        {
            _GameHook = gameHook;
        }

        #region InSector
        public struct InSectorObjectData : IBinaryObject
        {
            public int Speed;
            public int DesiredSpeed;
            public Vector3_32 Position;
            public Vector3_32 EulerRotation;

            public static InSectorObjectData FromSectorObject(SectorObject sectorObject)
            {
                var result = new InSectorObjectData();
                result.Speed = sectorObject.Speed;
                result.DesiredSpeed = sectorObject.DesiredSpeed;
                result.Position = sectorObject.CopyPosition;
                result.EulerRotation = sectorObject.EulerRotationCopy;
                return result;
            }

            public void ToSectorObject(ref SectorObject sectorObject)
            {
                sectorObject.Speed = Speed;
                sectorObject.DesiredSpeed = DesiredSpeed;
                sectorObject.CopyPosition = Position;
                sectorObject.EulerRotationCopy = EulerRotation;
            }

            public const int BYTE_SIZE = 32;
            public int ByteSize => BYTE_SIZE;

            public byte[] GetBytes()
            {
                var obl = new MemoryObjectConverter();

                obl.Append(Speed);
                obl.Append(DesiredSpeed);
                obl.Append(Position);
                obl.Append(EulerRotation);

                return obl.GetBytes();
            }

            public void SetData(byte[] data, out int bytesConsumed)
            {
                var obl = new MemoryObjectConverter(data);
                Speed = obl.PopInt();
                DesiredSpeed = obl.PopInt();
                Position = obl.PopIBinaryObject<Vector3_32>();
                EulerRotation = obl.PopIBinaryObject<Vector3_32>();
                bytesConsumed = BYTE_SIZE;
            }
        }

        public InSectorObjectData[] GetObjectsInSector()
        {
            List<InSectorObjectData> sectorObjects = new List<InSectorObjectData>();
            var sector = _GameHook.SectorBase.GetFirstObjectOfMainType(_GameHook.GetMainTypeID(GameHook.GeneralMainType.Sector));
            foreach (var child in sector.Meta.GetChildren())
            {
                sectorObjects.Add(InSectorObjectData.FromSectorObject(child));
            }
            return sectorObjects.ToArray();
        }
        #endregion
    }
}
