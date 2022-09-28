using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM.Bases.Sector.SectorObject_TypeData
{
    public abstract class TypeData_Ship : TypeData
    {
        public abstract class TurretData : MemoryObject
        {
            public abstract int WeaponCount { get; set; }
            public abstract int WeaponCompatability { get; set; }
            public abstract int TurretNumber { get; set; }
        }

        public abstract int MaxSpeed { get; set; }
        public abstract int ExteriorModelID { get; set; }
        public abstract int OriginRace { get; set; }

        public abstract int TurretCount { get; set; }

        public abstract TurretData GetTurretData(int index);
    }
}
