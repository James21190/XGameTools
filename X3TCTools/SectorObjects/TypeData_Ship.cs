using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.SectorObjects
{
    public class TypeData_Ship : MemoryObject
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
                var collection = new ObjectByteList(Memory);

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

            M7_Frigate = 13,
            TM_Military_Transport,
            M8_Bomber,
        }

        public Common.Vector.Vector3 RotationSpeed;

        public ShipClassification ObjectClass;
        public int NameID;

        public int Price1;
        public int Price2;

        public MemoryObjectPointer<MemoryString> pTypeString;
        public int MaxSpeed;

        public int ShieldPowerGenerator;

        public int ModelID;

        public int MaxLaserEnergy;
        public int LaserRechargeRate;
        public SectorObject.Shield_Sub_Type MaxShieldClass;
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

        #region IMemoryObject
        public const int ByteSize = 3512;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();

            // Must define all fields
            var collection = new ObjectByteList();

            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory,m_hProcess,pThis);

            RotationSpeed = collection.PopIMemoryObject<Common.Vector.Vector3>(0x8);

            ObjectClass = (ShipClassification)collection.PopInt(0x14);
            NameID = collection.PopInt();

            Price1 = collection.PopInt(0x20);
            Price2 = collection.PopInt();

            pTypeString = collection.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);
            MaxSpeed = collection.PopInt();

            ShieldPowerGenerator = collection.PopInt(0x5c);

            ModelID = collection.PopInt(0x5c);

            MaxLaserEnergy = collection.PopInt(0x78);
            LaserRechargeRate = collection.PopInt();
            MaxShieldClass = (SectorObject.Shield_Sub_Type)collection.PopInt();
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

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
