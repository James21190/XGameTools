using CommonToolLib.Memory;
using System;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3Tools.RAM.Bases.Story
{
    public class TextPage : MemoryObject
    {
        public class TextEntry : MemoryObject
        {
            public class Txt : MemoryObject
            {
                public int U_1;
                public override byte[] GetBytes()
                {
                    throw new NotImplementedException();
                }

                public override int ByteSize => 4;

                protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
                {
                    U_1 = objectByteList.PopInt();
                }
            }
            public int ID;
            public DynamicValue value;
            public byte Unknown_2;
            public byte Unknown_3;
            public byte Unknown_4;

            public override string ToString()
            {
                return "Entry " + ID;
            }

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            public override int ByteSize => 12;
            protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
            {
                ID = objectByteList.PopInt();
                value = objectByteList.PopIMemoryObject<DynamicValue>();
                Unknown_2 = objectByteList.PopByte();
                Unknown_3 = objectByteList.PopByte();
                Unknown_4 = objectByteList.PopByte();
            }
        }

        public int Count;
        public MemoryObjectPointer<TextEntry> pEntries = new MemoryObjectPointer<TextEntry>();
        public int Unknown;

        public TextEntry[] textEntries
        {
            get
            {
                TextEntry[] result = new TextEntry[Count];
                for (int i = 0; i < Count; i++)
                {
                    result[i] = pEntries.GetObjectInArray(i);
                }
                return result;
            }
        }

        private ScriptStringObject _GetTextObject(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                TextEntry entry = pEntries.GetObjectInArray(i);
                if (entry.ID == id)
                {
                    return entry.value.GetAsTextObject();
                }
            }
            throw new IndexOutOfRangeException();
        }

        public string GetText(int id)
        {
            return _GetTextObject(id).pText.obj.Value;
        }

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 12;

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pEntries.SetLocation(hProcess, address + 0x4);
        }

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            Count = objectByteList.PopInt();
            pEntries = objectByteList.PopIMemoryObject<MemoryObjectPointer<TextEntry>>();
            Unknown = objectByteList.PopInt();
        }

    }
}
