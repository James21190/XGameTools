using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace X3TCTools.SectorObjects
{
    public partial class SectorObject
    {

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

            Cocpit = 25,

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
            var lines = File.ReadAllLines("./SectorObjectTypes.csv");

            if (lines.Length < SubType) goto failed;

            var line = lines[SubType];

            var names = line.Split(',');

            var name = names[(int)main_Type];

            if (string.IsNullOrEmpty(name)) goto failed;

            return name;

            failed:
            return SubType.ToString();
        }

        //public static int GetMaxSubType(Main_Type main_Type)
        //{
        //    switch(main_Type)
        //    {
        //        case Main_Type.Bullet: // 0
        //        case Main_Type.Laser: // 8
        //            return WEAPON_SUB_TYPE_COUNT;
        //        case Main_Type.Sun: // 3
        //            return SUN_SUB_TYPE_COUNT;
        //        case Main_Type.Planet: // 4
        //            return PLANET_SUB_TYPE_COUNT;
        //        case Main_Type.Dock: // 5
        //            return DOCK_SUB_TYPE_COUNT;
        //        case Main_Type.Factory: // 6
        //            return FACTORY_SUB_TYPE_COUNT;
        //        case Main_Type.Ship: // 7
        //            return SHIP_SUB_TYPE_COUNT;
        //        case Main_Type.Shield: // 9
        //            return SHIELD_SUB_TYPE_COUNT;
        //        case Main_Type.Missile: // 10
        //            return MISSILE_SUB_TYPE_COUNT;
        //        case Main_Type.Ware_Bio: // 14
        //            return WARE_BIO_SUB_TYPE_COUNT;
        //        case Main_Type.Ware_Miscellaneous: // 16
        //            return WARE_MMISCELLANEOUS_SUB_TYPE_COUNT;
        //        case Main_Type.Gate: // 18
        //            return GATE_SUB_TYPE_COUNT;
        //        case Main_Type.Miscellaneous: // 20
        //            return MISCELLANEOUS_SUB_TYPE_COUNT;
        //        default: throw new NotImplementedException();
        //    }
        //}
    }
}
