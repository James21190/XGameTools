using System;
using System.IO;

namespace X3TCTools.Sector_Objects
{
    public partial class SectorObject
    {

        public struct Full_Type : IComparable
        {
            public Main_Type MainType;
            public int SubType;

            public int ToInt()
            {
                return (((int)MainType) << 16 | SubType);
            }

            public static Full_Type FromInt(int value)
            {
                Full_Type type = new Full_Type
                {
                    MainType = (Main_Type)(value >> 16),
                    SubType = value & 0x0000ffff
                };
                return type;
            }

            public override string ToString()
            {
                return MainType.ToString() + " - " + GetSubTypeAsString(MainType, SubType);
            }

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                if (!(obj is Full_Type))
                {
                    throw new Exception("Type missmatch");
                }

                Full_Type type = (Full_Type)obj;

                if (MainType > type.MainType)
                {
                    return -1;
                }

                if (MainType < type.MainType)
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

        public static int ToFullType(Main_Type MainType, int SubType)
        {
            return (((int)MainType) << 16 | SubType);
        }

        public static void FromFullType(int FullType, out Main_Type MainType, out int SubType)
        {
            MainType = (Main_Type)(FullType >> 16);
            SubType = FullType & 0x0000ffff;
        }

        /// <summary>
        /// Returns the object's subtype in as a string. Takes maintype into account.
        /// </summary>
        /// <returns></returns>
        public string GetSubTypeAsString()
        {
            return (GetSubTypeAsString(MainType, SubType));
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
