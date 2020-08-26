using Common.Memory;
using System;

namespace X3TCTools.SectorObjects
{
    public class TypeData_Ship : TypeData
    {

        public class TurretData : MemoryObject
        {
            public int FirstWeaponIndex;
            public int WeaponsCount;

            public BitField WeaponCompatability;

            public const int ByteSize = 312;

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            public override int GetByteSize()
            {
                return ByteSize;
            }

            public override void SetData(byte[] Memory)
            {
                ObjectByteList collection = new ObjectByteList(Memory);

                FirstWeaponIndex = collection.PopInt();
                WeaponsCount = collection.PopInt();

                WeaponCompatability = collection.PopIMemoryObject<BitField>(0x10);

            }
        }

        public enum ShipClassification
        {
            TL_Large_Transporter,
            TS_Transporter,

            M1_Carrier = 3,
            M2_Destroyer,
            M3_Heavy_Fighter,
            M4_Interceptor,
            M5_Scout,

            Ranger = 10,
            M6_Corvette,
            TP_Personel_Transporter,
            M7_Frigate,
            TM_Military_Transport,
            M8_Bomber,
        }

        public int MaxSpeed;

        public int ShieldPowerGenerator;

        public int ModelID;

        public int MaxLaserEnergy;
        public int LaserRechargeRate;
        public int MaxShieldClass;
        public int MaxShieldCount;

        public BitField MissileCompatability;

        public int MinimumCargoSpace;
        public int MaximumCargoSpace;

        public int HangarSize;
        public int MaxWeaponClass;
        public GameHook.RaceID OriginRace;
        public int MaxHull;

        public int EventObjectID;

        public int TurretCount;
        public TurretData[] TurretDatas;

        public override string GetObjectClassAsString()
        {
            return ((ShipClassification)ObjectClass).ToString();
        }
        protected override void SetUniqueData(ObjectByteList collection)
        {
            MaxSpeed = collection.PopInt();

            ShieldPowerGenerator = collection.PopInt(0x5c);

            ModelID = collection.PopInt(0x5c);

            MaxLaserEnergy = collection.PopInt(0x78);
            LaserRechargeRate = collection.PopInt();
            MaxShieldClass = collection.PopInt();
            MaxShieldCount = collection.PopInt();

            MissileCompatability = collection.PopIMemoryObject<BitField>(0x8c);

            MinimumCargoSpace = collection.PopInt(0x9c);
            MaximumCargoSpace = collection.PopInt();

            HangarSize = collection.PopInt(0xac);
            MaxWeaponClass = collection.PopInt();
            OriginRace = (GameHook.RaceID)collection.PopInt();
            MaxHull = collection.PopInt();

            EventObjectID = collection.PopInt(0xc8);

            TurretCount = collection.PopInt(0x180);
            TurretDatas = collection.PopIMemoryObjects<TurretData>(10);
        }
    }
}
