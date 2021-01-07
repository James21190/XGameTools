using Common.Memory;

namespace X3Tools.Bases.SectorBase_Objects
{
    public class TypeData_Missile : TypeData
    {
        public enum MissileClassification
        {
            Standard,
            AF,
            Khaak,
            Dumb,
            Bomber,
            Light,
            Medium,
            Heavy,
            Swarm,
        }
        protected override void SetUniqueData(ObjectByteList obl)
        {

        }

        public override string GetObjectClassAsString()
        {
            return ((MissileClassification)ObjectClass).ToString();
        }
    }
}
