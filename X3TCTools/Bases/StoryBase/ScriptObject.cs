using Common.Memory;
using System;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.KCode;
using X3TCTools.Bases.Scripting.KCode.AP;
using X3TCTools.Bases.Scripting.KCode.TC;

namespace X3TCTools.Bases
{
    public class ScriptObject : MemoryObject
    {
        public MemoryObjectPointer<ScriptObject> pNext = new MemoryObjectPointer<ScriptObject>();
        public MemoryObjectPointer<ScriptObject> pPrevious = new MemoryObjectPointer<ScriptObject>();
        public int ID;

        public int StackSize;
        public MemoryObjectPointer<DynamicValue> pStack = new MemoryObjectPointer<DynamicValue>();
        public int CurrentStackIndex;
        public int InstructionOffset;

        public DynamicValue ReturnValue = new DynamicValue();

        public uint FunctionIndex;

        public MemoryObjectPointer<EventObject> pEventObject = new MemoryObjectPointer<EventObject>();

        #region IMemoryObject

        public const int ByteSize = 64;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
            ObjectByteList collection = new ObjectByteList();
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
            KCodeDissassembler dissassembler;
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: dissassembler = new APKCodeDissassembler(); break;
                case GameHook.GameVersions.X3TC: dissassembler = new TCKCodeDissassembler(); break;
                default: return "ScriptObject " + ID;
            }
            return string.Format("ScriptObject {0} - {1}", ID, dissassembler.GetFunctionName(InstructionOffset));
        }
    }
}
