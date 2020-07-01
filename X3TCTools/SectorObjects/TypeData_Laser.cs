using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public class TypeData_Laser : MemoryObject
    {
        public MemoryObjectPointer<MemoryString> pTypeName;


        public const int ByteSize = 3512;
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
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pTypeName = collection.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);
        }
    }
}
