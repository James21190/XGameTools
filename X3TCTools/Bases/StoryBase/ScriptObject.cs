using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.Bases
{
    public class ScriptObject : MemoryObject
    {
        public MemoryObjectPointer<ScriptObject> pNext = new MemoryObjectPointer<ScriptObject>();
        public MemoryObjectPointer<ScriptObject> pPrevious = new MemoryObjectPointer<ScriptObject>();
        public int ID;

        public uint FlagAndIntArrSize;
        public MemoryObjectPointer<DynamicValue> pFlagAndIntArrEnd = new MemoryObjectPointer<DynamicValue>();
        public int FlagAndIntIndex;
        public int InstructionOffset;

        public DynamicValue ReturnValue = new DynamicValue();

        public uint FunctionIndex;

        public MemoryObjectPointer<EventObject> pEventObject = new MemoryObjectPointer<EventObject>();

        #region IMemoryObject

        public const int ByteSize = 64;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
            var collection = new ObjectByteList();
            collection.Append(pNext);
            collection.Append(pPrevious);
            collection.Append(ID);


            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pNext.address = collection.PopIntPtr();
            pPrevious.address = collection.PopIntPtr();
            ID = collection.PopInt();

            FlagAndIntArrSize = collection.PopUInt(0x10);
            pFlagAndIntArrEnd.address = collection.PopIntPtr();
            FlagAndIntIndex = collection.PopInt();
            InstructionOffset = collection.PopInt();

            ReturnValue = collection.PopIMemoryObject<DynamicValue>(0x28);

            FunctionIndex = collection.PopUInt(0x30);

            pEventObject.address = collection.PopIntPtr(0x3c);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address);
            pPrevious.SetLocation(hProcess, address);
        }
        #endregion
    }
}
