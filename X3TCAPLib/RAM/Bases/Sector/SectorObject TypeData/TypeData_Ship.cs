using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_TypeData
{
    public class TypeData_Ship : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Ship
    {
        #region Memory Fields
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public override int ByteSize => 3512;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            #region Base TypeData
            BodyID = objectByteList.PopInt();

            RotationSpeed = objectByteList.PopIMemoryObject<Vector3_32>(0x8);
            ObjectClass = objectByteList.PopInt();
            DefaultNameId = objectByteList.PopInt();
            WareVolume = objectByteList.PopInt();
            RelVal = objectByteList.PopInt();
            PriceRangePercentage = objectByteList.PopInt();

            WareSizeClass = objectByteList.PopInt(0x2c);

            pTypeName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);
            #endregion
        }
        #endregion
    }
}
