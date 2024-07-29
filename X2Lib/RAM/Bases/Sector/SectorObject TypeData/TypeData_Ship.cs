using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Lib.RAM.Bases.Sector.SectorObject_TypeData
{
    public class TypeData_Ship : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship
    {
        public new class TurretData : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship.TurretData
        {
            public override int WeaponCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override BitField WeaponCompatability { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override int TurretNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override int ByteSize => throw new NotImplementedException();

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
            {
                throw new NotImplementedException();
            }
        }

        #region Memory Fields
        public override int MaxSpeed { get; set; }
        public override int ExteriorModelID { get; set; }
        public override int OriginRace { get; set; }
        public override int TurretCount { get; set; }
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship.TurretData GetTurretData(int index)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IMemoryObject
        public const int BYTE_SIZE = 0x61c;
        public override int ByteSize => BYTE_SIZE;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            #region Base TypeData
            BodyID = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x8);
            RotationSpeed = memoryObjectConverter.PopIBinaryObject<Vector3_32>();
            ObjectClass = memoryObjectConverter.PopInt();
            DefaultNameId = memoryObjectConverter.PopInt();
            WareVolume = memoryObjectConverter.PopInt();
            RelVal = memoryObjectConverter.PopInt();
            PriceRangePercentage = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x2c);
            WareClass = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x30);
            pTypeName = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            #endregion
            MaxSpeed = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x58);
            ExteriorModelID = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0xa4);
            OriginRace = memoryObjectConverter.PopInt();

            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
        #endregion
    }
}
