using Common.Memory;
using System;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting
{
    public class ScriptingTextObject : MemoryObject
    {

        public const int ByteSize = 12;

        public int id;
        public int unknown_1;
        public MemoryObjectPointer<MemoryString> pText = new MemoryObjectPointer<MemoryString>();

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
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            id = collection.PopInt();
            unknown_1 = collection.PopInt();
            pText = collection.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
        }

        public override string ToString()
        {
            return string.Format("TextObject \"{0}\"", pText.obj.value);
        }
    }
}
