using Common.Memory;
using Common.Vector;
using System;
using System.ComponentModel;

namespace X3TCTools.Sector_Objects
{
    public class TypeData : MemoryObject
    {
        #region Memory
        public int BodyID;
        public Vector3 RotationSpeed;
        public int ObjectClass;
        public int DefaultNameID;
        public int WareVolume;
        /// <summary>
        /// The relative value of the type. Used to calculate storage in docks and factories, and price in credits.
        /// </summary>
        public int RelVal;
        public int PriceRangePercentage;

        public int WareSizeClass;

        public MemoryObjectPointer<MemoryString> pTypeString;

        #endregion

        public SectorObject.SectorObjectType ObjectType;

        public string DefaultName
        {
            get
            {
                try
                {
                    var storyBase = GameHook.storyBase;
                    return storyBase.GetParsedText(GameHook.Language.English, storyBase.GetText(GameHook.Language.English, 17, DefaultNameID));
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public TypeData()
        {

        }

        public TypeData(SectorObject.SectorObjectType type)
        {
            ObjectType = type;
        }

        public sealed override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 3512;


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            BodyID = objectByteList.PopInt();

            RotationSpeed = objectByteList.PopIMemoryObject<Vector3>(0x8);
            ObjectClass = objectByteList.PopInt();
            DefaultNameID = objectByteList.PopInt();
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

        const int RelvalThreshhold = 1323077;
        const int RelvalThreshholdSubtraction = 41802301;

        public int GetPrice(decimal percentPrice)
        {
            int averagePrice;
            switch (ObjectType.MainTypeEnum)
            {
                case SectorObject.Main_Type.Ship:
                    averagePrice = (int)Math.Round((decimal)RelVal * 64.92389m);
                    //if (RelVal > RelvalThreshhold) averagePrice -= RelvalThreshholdSubtraction;
                    break;
                default: averagePrice = RelVal; break;
            }


            return (int)Math.Round(averagePrice * (percentPrice + 0.5m));
        }
    }
}
