using Common.Memory;

namespace X3Tools.Bases.SectorBase_Objects
{
    public class TypeData_Sun : TypeData
    {
        public int ModelID;
        public int AppearenceID;
        protected override void SetUniqueData(ObjectByteList obl)
        {
            ModelID = obl.PopInt();
            AppearenceID = obl.PopInt();
        }
    }
}
