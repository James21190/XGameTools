using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Lib.RAM.Bases.Sector.SectorObject_TypeData
{
    public class TypeData_Background : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Background
    {
        public override int ByteSize => 0x61c;

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

            pTypeName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x30);
            #endregion
            return SetDataResult.Success;
        }
    }
}
