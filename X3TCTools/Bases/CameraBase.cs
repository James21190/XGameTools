using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class CameraBase : MemoryObject
    {
        public const int ByteSize = 27208;

        public MemoryObjectPointer<HashTable<Camera>> pCameraHashTable = new MemoryObjectPointer<HashTable<Camera>>();
        
        public CameraBase()
        {

        }

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
            collection.GoTo(0xc);
            collection.PopFirst(ref pCameraHashTable);

        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pCameraHashTable.SetLocation(hProcess, address + 12);
        }
    }
}
