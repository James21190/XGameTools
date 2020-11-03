using Common.Memory;
using Common.Vector;
using System;

namespace X3TCTools.Sector_Objects
{
    public class TypeData : MemoryObject
    {
        public int BodyID;
        public Vector3 RotationSpeed;
        public int ObjectClass;
        public int NameID;
        public int WareVolume;
        /// <summary>
        /// The relative value of the type. Used to calculate storage in docks and factories, and price in credits.
        /// </summary>
        public int RelVal;
        public int PriceRangePercentage;

        public int WareSizeClass;

        public MemoryObjectPointer<MemoryString> pTypeString;

        public const int ByteSize = 3512;
        public sealed override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public sealed override int GetByteSize()
        {
            return ByteSize;
        }


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            BodyID = objectByteList.PopInt();

            RotationSpeed = objectByteList.PopIMemoryObject<Vector3>(0x8);
            ObjectClass = objectByteList.PopInt();
            NameID = objectByteList.PopInt();
            WareVolume = objectByteList.PopInt();
            RelVal = objectByteList.PopInt();
            PriceRangePercentage = objectByteList.PopInt();

            WareSizeClass = objectByteList.PopInt(0x2c);

            pTypeString = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);

            SetUniqueData(objectByteList);
        }

        public virtual string GetObjectClassAsString() { return ObjectClass.ToString(); }

        protected virtual void SetUniqueData(ObjectByteList obl)
        {

        }

        /// <summary>
        /// Returns the capacity of a ware stored in a dock.
        /// </summary>
        /// <param name="mainType"></param>
        /// <param name="subType"></param>
        /// <returns></returns>
        public static int GetDockWareCapacity(SectorObject.Main_Type mainType, int subType)
        {
            TypeData typeData = GameHook.GetTypeData((int)mainType, subType);

            int result = (int)Math.Floor(20000m / typeData.RelVal);
            if (result % 2 != 0)
            {
                result -= 1;
            }

            if (result < 2)
            {
                result = 2;
            }

            return result;
        }

        /// <summary>
        /// Returns the capacity of a ware stored in a dock.
        /// </summary>
        /// <param name="mainType"></param>
        /// <param name="subType"></param>
        /// <returns></returns>
        public static int GetFactoryWareCapacity(SectorObject.Main_Type mainType, int subType)
        {
            return GetDockWareCapacity(mainType, subType) * 5;
        }

        /// <summary>
        /// Returns the price in credits of a relval which is dependent on the MainType.
        /// </summary>
        /// <param name="mainType"></param>
        /// <param name="relativePrice"></param>
        /// <returns></returns>
        private static int GetPriceAsCredits(SectorObject.Main_Type mainType, decimal relativePrice)
        {

            switch (mainType)
            {
                case SectorObject.Main_Type.Ware_M:
                    return (int)Math.Ceiling(relativePrice * 1.3125m - 0.4625m) * 4; // Accurate
                case SectorObject.Main_Type.Ware_E:
                    return (int)Math.Floor(relativePrice * 4); // Accurate
                default:
                    return (int)relativePrice;
            }
        }

        /// <summary>
        /// Returns the price of a type in credits.
        /// PercentPrice is used to define where in the price range the calculated value will be:
        /// 0: Minimum value, 0.5: Average value, 1: Maximum value
        /// </summary>
        /// <param name="mainType"></param>
        /// <param name="subType"></param>
        /// <param name="percentPrice"></param>
        /// <returns></returns>
        public static int GetPrice(SectorObject.Main_Type mainType, int subType, decimal percentPrice)
        {
            TypeData typeData = GameHook.GetTypeData((int)mainType, subType);
            int price = GetPriceAsCredits(mainType, typeData.RelVal);
            decimal fraction = (typeData.PriceRangePercentage / 100m);
            decimal minimum = price * (1 - fraction);
            decimal maximum = price * (1 + fraction);
            decimal difference = (maximum - minimum) * percentPrice;
            decimal result = minimum + difference;
            if (percentPrice < 0.5m)
            {
                return (int)Math.Ceiling(result);
            }
            else
            {
                return (int)Math.Floor(result);
            }
        }
    }
}
