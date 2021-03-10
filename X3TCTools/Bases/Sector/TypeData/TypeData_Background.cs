﻿using Common.Memory;

namespace X3Tools.Bases.Sector
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