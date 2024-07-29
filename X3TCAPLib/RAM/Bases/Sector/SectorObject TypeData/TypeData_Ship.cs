using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_TypeData
{
    public class TypeData_Ship : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship
    {
        public new class TurretData : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship.TurretData
        {
            public override int WeaponCount { get; set; }
            public override BitField WeaponCompatability { get; set; }
            public override int TurretNumber { get; set; }

            public const int BYTE_SIZE = 0x138;
            public override int ByteSize => BYTE_SIZE;

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
            {
                memoryObjectConverter.Seek(0x4);
                WeaponCount = memoryObjectConverter.PopInt();
                TurretNumber = memoryObjectConverter.PopInt();

                memoryObjectConverter.Seek(0x10);
                WeaponCompatability = memoryObjectConverter.PopIMemoryObject<BitField>();

                // Seek to end to consume the correct amount of bytes.
                memoryObjectConverter.Seek(BYTE_SIZE);
            }

            public override void WriteSafeToMemory()
            {
                ParentMemoryBlock.WriteBinaryObject(pThis + 0x10, WeaponCompatability);
            }
        }

        #region Memory Fields
        public override int MaxSpeed { get; set; }
        public override int ExteriorModelID { get; set; }
        public override int OriginRace { get; set; }
        public override int TurretCount { get; set; }

        public TurretData[] Turrets = new TurretData[10];
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship.TurretData GetTurretData(int index)
        {
            return Turrets[index];
        }
        #endregion

        #region IMemoryObject
        public const int BYTE_SIZE = 3512;
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

            memoryObjectConverter.Seek(0x40);
            pTypeName = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            #endregion
            MaxSpeed = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x68);
            ExteriorModelID = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0xb4);
            OriginRace = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x180);
            TurretCount = memoryObjectConverter.PopInt();
            Turrets = memoryObjectConverter.PopIMemoryObjects<TurretData>(10);

            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
        #endregion
    }
}
