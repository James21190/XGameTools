using Common.Memory;

namespace X3TCTools.Sector_Objects
{
    public class TypeData_31 : TypeData
    {
        protected override void SetUniqueData(ObjectByteList obl)
        {

        }
        public override string GetObjectClassAsString()
        {
            return ((TypeData_Ship.ShipClassification)ObjectClass).ToString();
        }
    }
}
