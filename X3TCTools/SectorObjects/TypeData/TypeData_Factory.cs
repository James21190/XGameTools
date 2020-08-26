using Common.Memory;

namespace X3TCTools.SectorObjects
{
    public class TypeData_Factory : TypeData
    {
        public enum FactoryClassification
        {
            Shipyard
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {

        }

        public override string GetObjectClassAsString()
        {
            return ((FactoryClassification)ObjectClass).ToString();
        }
    }
}
