using Common.Memory;
using Common.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public class TypeData : MemoryObject
    {
        public Vector3 RotationSpeed;
        public int ObjectClass;
        public int NameID;

        public int Price;
        public int PriceRangePercentage;

        public MemoryObjectPointer<MemoryString> pTypeString;

        public const int ByteSize = 3512;
        public override sealed byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override sealed int GetByteSize()
        {
            return ByteSize;
        }

        public override sealed void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);

            RotationSpeed = collection.PopIMemoryObject<Vector3>(0x8);
            ObjectClass = collection.PopInt();
            NameID = collection.PopInt();

            Price = collection.PopInt(0x20);
            PriceRangePercentage = collection.PopInt();

            pTypeString = collection.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);

            SetUniqueData(collection);
        }
        public virtual string GetObjectClassAsString() { return ObjectClass.ToString(); }

        protected virtual void SetUniqueData(ObjectByteList obl)
        {

        }

        public static int GetDockWareCapacity(SectorObject.Main_Type mainType, int subType)
        {
            TypeData typeData = GameHook.GetTypeData((int)mainType, subType);

            var result = (int)Math.Floor(20000m / typeData.Price);
            if (result % 2 != 0) result -= 1;
            if (result < 4) result = 4;
            return result;
        }

        public static int GetFactoryWareCapacity(SectorObject.Main_Type mainType, int subType)
        {
            return GetDockWareCapacity(mainType, subType) * 5;
        }

        private static int GetPriceAsCredits(SectorObject.Main_Type mainType, decimal relativePrice)
        {

            switch (mainType)
            {
                case SectorObject.Main_Type.Ware_M:
                    return (int)Math.Ceiling(relativePrice * 1.3125m - 0.4625m) * 4;
                case SectorObject.Main_Type.Ware_E:
                    return (int)Math.Floor(relativePrice * 4);
                default:
                    return (int)relativePrice;
            }
        }

        public static int GetPrice(SectorObject.Main_Type mainType, int subType, decimal percentPrice)
        {
            var typeData = GameHook.GetTypeData((int)mainType, subType);
            var price = GetPriceAsCredits(mainType, typeData.Price);
            decimal fraction = (typeData.PriceRangePercentage / 100m);
            decimal minimum = price * (1 - fraction);
            decimal maximum = price * (1 + fraction);
            var difference = (maximum - minimum) * percentPrice;
            var result = minimum + difference;
            if (percentPrice < 0.5m) return (int)Math.Ceiling(result);
            else return (int)Math.Floor(result);
        }
    }
}
