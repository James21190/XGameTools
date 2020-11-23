using Common.Memory;
using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting
{
    public class ScriptingTaskObject : MemoryObject
    {
        public MemoryObjectPointer<ScriptingTaskObject> pNext = new MemoryObjectPointer<ScriptingTaskObject>();
        public MemoryObjectPointer<ScriptingTaskObject> pPrevious = new MemoryObjectPointer<ScriptingTaskObject>();
        public int ID;

        public int StackSize;
        public MemoryObjectPointer<DynamicValue> pStack = new MemoryObjectPointer<DynamicValue>();
        public int CurrentStackIndex;
        public int InstructionOffset;

        public DynamicValue ReturnValue = new DynamicValue();

        public uint FunctionIndex;

        public MemoryObjectPointer<ScriptingObject> pEventObject = new MemoryObjectPointer<ScriptingObject>();

        #region IMemoryObject

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
            ObjectByteList collection = new ObjectByteList();
            collection.Append(pNext);
            collection.Append(pPrevious);
            collection.Append(ID);


            return collection.GetBytes();
        }

        public override int ByteSize => 64;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pNext.address = collection.PopIntPtr();
            pPrevious.address = collection.PopIntPtr();
            ID = collection.PopInt();

            StackSize = collection.PopInt(0x10);
            pStack.address = collection.PopIntPtr();
            CurrentStackIndex = collection.PopInt();
            InstructionOffset = collection.PopInt();

            ReturnValue = collection.PopIMemoryObject<DynamicValue>(0x28);

            FunctionIndex = collection.PopUInt(0x30);

            pEventObject.address = collection.PopIntPtr(0x3c);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address);
            pPrevious.SetLocation(hProcess, address + 0x4);

            pStack.SetLocation(hProcess, address + 0x14);

            pEventObject.SetLocation(hProcess, address + 0x3c);
        }
        #endregion

        public override string ToString()
        {
            return string.Format("ScriptObject {0} - {1}", ID, InstructionOffset);
        }
    }
}
