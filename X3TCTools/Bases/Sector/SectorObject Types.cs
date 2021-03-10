using System;
using System.IO;
using Common.Memory;

namespace X3Tools.Bases.Sector
{
    public partial class SectorObject
    {
        public class SectorObjectType : MemoryObject, IComparable
        {
            public Main_Type MainTypeEnum
            {
                get
                {
                    return (Main_Type)MainType;
                }
                set
                {
                    MainType = (short)value;
                }
            }
            public short MainType;
            public short SubType;

            public TypeData typeData => GameHook.GetTypeData(this);

            public SectorObjectType()
            {

            }
            public SectorObjectType(short mainType, short subType)
            {
                MainType = mainType;
                SubType = subType;
            }
            public SectorObjectType(short mainType, int subType)
            {
                MainType = mainType;
                SubType = (short)subType;
            }
            public SectorObjectType(int mainType, short subType)
            {
                MainType = (short)mainType;
                SubType = subType;
            }
            public SectorObjectType(int mainType, int subType)
            {
                MainType = (short)mainType;
                SubType = (short)subType;
            }
            public SectorObjectType(Main_Type mainType, short subType)
            {
                MainTypeEnum = mainType;
                SubType = subType;
            }
            public SectorObjectType(Main_Type mainType, int subType)
            {
                MainTypeEnum = mainType;
                SubType = (short)subType;
            }


            public int ToInt()
            {
                return (((int)MainType) << 16 | SubType);
            }

            public static SectorObjectType[] GetAllOfMainType(SectorObject.Main_Type mainType)
            {
                int max = GameHook.GetTypeDataCount((int)mainType);
                var array = new SectorObjectType[max];
                for(int i = 0; i < max; i++)
                {
                    array[i] = new SectorObjectType(mainType, i);
                }

                return array;
            }

            public static SectorObjectType FromInt(int value)
            {
                SectorObjectType type = new SectorObjectType
                {
                    MainType = (short)(value >> 16),
                    SubType = (short)(value & 0x0000ffff)
                };
                return type;
            }

            public override string ToString()
            {
                return MainTypeEnum.ToString() + " - " + GetSubTypeAsString(MainTypeEnum, SubType);
            }

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                if (!(obj is SectorObjectType))
                {
                    throw new Exception("Type missmatch");
                }

                SectorObjectType type = (SectorObjectType)obj;

                if (MainTypeEnum > type.MainTypeEnum)
                {
                    return -1;
                }

                if (MainTypeEnum < type.MainTypeEnum)
                {
                    return 1;
                }

                if (SubType > type.SubType)
                {
                    return -1;
                }

                if (SubType < type.SubType)
                {
                    return 1;
                }

                return 0;
            }

            public override int ByteSize => 4;
            protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
            {
                MainTypeEnum = (Main_Type)objectByteList.PopShort();
                SubType = objectByteList.PopShort();
            }

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }
        }

        public const int MAIN_TYPE_COUNT = 32;
        public enum Main_Type : ushort
        {
            Bullet,
            Sector,
            Background,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            Laser,
            Shield,
            Missile,
            Ware_E,
            Ware_N,
            Ware_B,
            Ware_F,
            Ware_M,
            Ware_T,
            Asteroid,
            Gate,
            Camera,
            Special,

            Cockpit = 25,

            Debris = 28,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }

        /// <summary>
        /// Returns the object's subtype in as a string. Takes maintype into account.
        /// </summary>
        /// <returns></returns>
        public string GetSubTypeAsString()
        {
            return (GetSubTypeAsString(ObjectType.MainTypeEnum, ObjectType.SubType));
        }

        public static string GetSubTypeAsString(Main_Type main_Type, int SubType)
        {
            string path;

            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC: path = "./Data/TC/X3TCSectorObjectTypes.csv"; break;
                case GameHook.GameVersions.X3AP: path = "./Data/AP/X3APSectorObjectTypes.csv"; break;
                default: throw new Exception();
            }

            if (!File.Exists(path))
            {
                goto failed;
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length <= SubType)
            {
                goto failed;
            }

            string line = lines[SubType];

            string[] names = line.Split(',');

            if (names.Length <= (int)main_Type)
            {
                goto failed;
            }

            string name = names[(int)main_Type];

            if (string.IsNullOrEmpty(name))
            {
                goto failed;
            }

            return name;

        failed:
            return SubType.ToString();
        }

        #region TypeData

        #endregion
    }
}
