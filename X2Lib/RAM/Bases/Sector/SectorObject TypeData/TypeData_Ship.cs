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

            protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
            {
                throw new System.NotSupportedException();
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
        public override int ByteSize => 0x61c;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            #region Base TypeData
            BodyID = objectByteList.PopInt();

            RotationSpeed = objectByteList.PopIBinaryObject<Vector3_32>(0x8);
            ObjectClass = objectByteList.PopInt();
            DefaultNameId = objectByteList.PopInt();
            WareVolume = objectByteList.PopInt();
            RelVal = objectByteList.PopInt();
            PriceRangePercentage = objectByteList.PopInt();

            WareClass = objectByteList.PopInt(0x2c);

            pTypeName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x30);
            #endregion
            MaxSpeed = objectByteList.PopInt();

            ExteriorModelID = objectByteList.PopInt(0x58);

            OriginRace = objectByteList.PopInt(0xa4);
            return SetDataResult.Success;
        }
        #endregion
    }
}
