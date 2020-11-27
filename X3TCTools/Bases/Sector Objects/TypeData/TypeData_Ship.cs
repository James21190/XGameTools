using Common.Memory;
using System;
using System.Collections.Generic;

namespace X3Tools.Sector_Objects
{
    public class TypeData_Ship : TypeData
    {
        public struct ProductionMaterial
        {
            public SectorObject.SectorObjectType WareType;
            public int Count;
        }
        public class TurretData : MemoryObject
        {
            public int FirstWeaponIndex;
            public int WeaponsCount;

            public BitField WeaponCompatability;


            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            public override int ByteSize => 312;

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
            Pirate_Ship,

            Ranger = 10,
            M6_Corvette,
            TP_Personel_Transporter,
            M7_Frigate,
            TM_Military_Transport,
            M8_Bomber,
        }

        #region Memory
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

        public int ScriptingObjectID;

        public int TurretCount;
        public TurretData[] TurretDatas;
        #endregion

        public bool IsBoardable { get
            {
                return MaxSpeed != 0 && OriginRace != GameHook.RaceID.Khaak;
            } }
        public TypeData_Ship()
        {

        }

        const decimal TimeMult = 60.09m;

        public TimeSpan GetProductionTime()
        {
            int classvar = 1;
            switch ((ShipClassification)ObjectClass)
            {
                case ShipClassification.M1_Carrier:
                case ShipClassification.M2_Destroyer:
                case ShipClassification.M7_Frigate:
                case ShipClassification.TL_Large_Transporter:
                case ShipClassification.TM_Military_Transport:
                case ShipClassification.M8_Bomber:
                    classvar = 25000;
                    break;
                case ShipClassification.M3_Heavy_Fighter:
                    classvar = 16666;
                    break;
                case ShipClassification.M4_Interceptor:
                    classvar = 12500;
                    break;
                case ShipClassification.M5_Scout:
                    classvar = 10000;
                    break;
                case ShipClassification.Ranger:
                    classvar = 16666;
                    break;
                case ShipClassification.TS_Transporter:
                case ShipClassification.TP_Personel_Transporter:
                    classvar = 5000;
                    break;
            }
            var seconds = (double)((GetPrice(0.5m) * TimeMult) / classvar);
            return TimeSpan.FromSeconds(seconds);
        }

        private ProductionMaterial _GetProductionMaterial(SectorObject.SectorObjectType type, int wareFactor, int shipPrice)
        {
            var material = new ProductionMaterial()
            {
                WareType = type,
                Count = (int)Math.Floor((decimal)shipPrice / (decimal)wareFactor)
            };
            return material;
        }

        const int EnergyCellWareFactor = 885;
        const int TeladianiumWareFactor = 28333;
        const int ClothRimesWareFactor = 85000;
        const int RastarOilWareFactor = 42500;
        const int OreWareFactor = 21250;
        const int SiliconWareFactor = 28333;
        const int CrystalWareFactor = 85000;
        const int QuantumTubesWareFactor = 85000;
        const int MicrochipsWareFactor = 42500;
        const int ComputerComponentsWareFactor = 85000;
        const int CreditsWareFactor = 3;
        const int NividiumWareFactor = 170000;

        public ProductionMaterial[] GetProductionMaterials()
        {

            List<ProductionMaterial> materials = new List<ProductionMaterial>();

            var shipPrice = GetPrice(0.5m);
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_E, 0), EnergyCellWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_B, 9), TeladianiumWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_F, 0), ClothRimesWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_F, 6), RastarOilWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_M, 0), OreWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_M, 1), SiliconWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_T, 1), CrystalWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_T, 2), QuantumTubesWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_T, 3), MicrochipsWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_T, 4), ComputerComponentsWareFactor, shipPrice));
            materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_T, 79), CreditsWareFactor, shipPrice));

            if(OriginRace == GameHook.RaceID.Khaak)
            {
                materials.Add(_GetProductionMaterial(new SectorObject.SectorObjectType(SectorObject.Main_Type.Ware_M, 2), NividiumWareFactor, shipPrice));
            }

            return materials.ToArray();
        }

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

            ScriptingObjectID = collection.PopInt(0xc8);

            TurretCount = collection.PopInt(0x180);
            TurretDatas = collection.PopIMemoryObjects<TurretData>(10);
        }
    }
}
