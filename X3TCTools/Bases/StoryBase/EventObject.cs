using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class EventObject : MemoryObject
    {
        public const int ByteSize = 16;

        public int NegativeID;
        public int ReferenceCount;
        public MemoryObjectPointer<EventObjectSub> pSub = new MemoryObjectPointer<EventObjectSub>();
        public MemoryObjectPointer<DynamicValue> pScriptVariableArr = new MemoryObjectPointer<DynamicValue>();

        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(NegativeID);
            collection.Append(ReferenceCount);
            collection.Append(pSub);
            collection.Append(pScriptVariableArr);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);

            collection.PopFirst(ref NegativeID);
            collection.PopFirst(ref ReferenceCount);
            collection.PopFirst(ref pSub);
            collection.PopFirst(ref pScriptVariableArr.address);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pScriptVariableArr.SetLocation(hProcess, address+8);
            pSub.SetLocation(hProcess, address+12);
        }

    }
}
