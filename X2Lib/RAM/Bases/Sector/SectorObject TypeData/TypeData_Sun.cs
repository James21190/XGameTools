using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Lib.RAM.Bases.Sector.SectorObject_TypeData
{
    public class TypeData_Sun : XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData_Sun
    {
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
            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
    }
}
