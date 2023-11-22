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

            public override int ByteSize => 0x138;

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
            {
                WeaponCount = objectByteList.PopInt(0x4);
                TurretNumber = objectByteList.PopInt();

                WeaponCompatability = objectByteList.PopIMemoryObject<BitField>(0x10);
                return SetDataResult.Success;
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
        public override int ByteSize => 3512;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            #region Base TypeData
            BodyID = objectByteList.PopInt();

            RotationSpeed = objectByteList.PopIMemoryObject<Vector3_32>(0x8);
            ObjectClass = objectByteList.PopInt();
            DefaultNameId = objectByteList.PopInt();
            WareVolume = objectByteList.PopInt();
            RelVal = objectByteList.PopInt();
            PriceRangePercentage = objectByteList.PopInt();

            WareClass = objectByteList.PopInt(0x2c);

            pTypeName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);
            #endregion
            MaxSpeed = objectByteList.PopInt();

            ExteriorModelID = objectByteList.PopInt(0x68);

            OriginRace = objectByteList.PopInt(0xb4);

            TurretCount = objectByteList.PopInt(0x180);
            Turrets = objectByteList.PopIMemoryObjects<TurretData>(10);
            return SetDataResult.Success;
        }
        #endregion
    }
}
