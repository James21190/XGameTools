using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Tools.X2.TypeData
{
    public class ShipTypeData
    {
        #region Constants
        public const int Length = 1564;
        #endregion

        #region Enums
        public const int SHIP_CLASS_COUNT = 13;
        public enum ShipClass
        {
            TL_LargeTransporter=0,
            TS_Transporter=1,
            M0_Mothership=2,
            M1_Carrier=3,
            M2_Destroyer=4,
            M3_Fighter=5,
            M4_Intercepter=6,
            M5_Scout=7,
            TL=8,
            TS=9,
            GO_GonorShip=10,
            M6_Corvette=11,
            TP_PersonTransporter=12
        }

        public const int CONTAINER_SIZE_COUNT = 6;
        public enum ContainerSize
        {
            Tiny = 0,
            S_Small = 1,
            M_Medium = 2,
            L_Large = 3,
            XL_ExtraLarge = 4,
            ST_Station = 5
        }
        #endregion

        #region Public Fields

        public ShipClass Class;
        public int AudioDescription_And_DefaultNameID;
        /// SubData
        public Race.RaceID OriginRace;
        public int MaxSpeed;
        public int Acceleration;
        public int PowerGenerator;
        public int ObjectModelID;
        public int CockpitModelID;
        public SectorObjects.SectorObject.Shield_Sub_Type ShieldClass;
        public int MaxShieldCount;
        public int MinimumCargoBay;
        public int MaximumCargoBay;
        public int HangarSize;
        public int MaxHull;
        public ContainerSize CargoClass;

        #endregion

        #region Constructors
        public ShipTypeData(byte[] Memory)
        {
            // Check if the length of memory is correct
            if (Memory.Length != Length)
                throw new ArgumentException("Byte array length incorrect!");
            // If correct, load memory into approriate fields.

            Class = (ShipClass)BitConverter.ToInt32(Memory, 20);
            AudioDescription_And_DefaultNameID = BitConverter.ToInt32(Memory, 24);
            OriginRace = Race.ConvertToRaceID(BitConverter.ToInt32(Memory, 164));
            MaxSpeed = BitConverter.ToInt32(Memory, 52);
            Acceleration = BitConverter.ToInt32(Memory, 56);
            PowerGenerator = BitConverter.ToInt32(Memory, 76);
            ObjectModelID = BitConverter.ToInt32(Memory, 88);
            CockpitModelID = BitConverter.ToInt32(Memory, 92);
            ShieldClass = (SectorObjects.SectorObject.Shield_Sub_Type)BitConverter.ToInt32(Memory, 104);
            MaxShieldCount = BitConverter.ToInt32(Memory, 108);
            MinimumCargoBay = BitConverter.ToInt32(Memory, 128);
            MaximumCargoBay = BitConverter.ToInt32(Memory, 132);
            HangarSize = BitConverter.ToInt32(Memory, 136);
            MaxHull = BitConverter.ToInt32(Memory, 168);
            CargoClass = (ContainerSize)BitConverter.ToInt32(Memory, 172);

        }
        #endregion
    }
}
