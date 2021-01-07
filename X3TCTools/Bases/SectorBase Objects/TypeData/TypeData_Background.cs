using Common.Memory;

namespace X3Tools.Bases.SectorBase_Objects
{
    public class TypeData_Background : TypeData
    {
        public MemoryObjectPointer<MemoryString> pName = new MemoryObjectPointer<MemoryString>();
        protected override void SetUniqueData(ObjectByteList obl)
        {
            pName = obl.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
        }
    }
}
