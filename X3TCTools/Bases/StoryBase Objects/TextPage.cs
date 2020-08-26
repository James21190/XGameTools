using Common.Memory;
using System;

namespace X3TCTools.Bases.StoryBase_Objects
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

                public override int GetByteSize()
                {
                    return 4;
                }

                protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
                {
                    U_1 = objectByteList.PopInt();
                }
            }
            public int ID;
            public byte Unknown_1;
            public MemoryObjectPointer<Txt> Index = new MemoryObjectPointer<Txt>();
            public byte Unknown_2;
            public byte Unknown_3;
            public byte Unknown_4;

            public override string ToString()
            {
                return "Entry " + ID + ":" + Index.obj.U_1;
            }

            public override byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            public override int GetByteSize()
            {
                return 12;
            }
            protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
            {
                ID = objectByteList.PopInt();
                Unknown_1 = objectByteList.PopByte();
                Index = objectByteList.PopIMemoryObject<MemoryObjectPointer<Txt>>();
                Unknown_2 = objectByteList.PopByte();
                Unknown_3 = objectByteList.PopByte();
                Unknown_4 = objectByteList.PopByte();
            }
        }

        public int Count;
        public MemoryObjectPointer<TextEntry> pEntries = new MemoryObjectPointer<TextEntry>();
        public int Unknown;

        public const int ByteSize = 12;

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

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

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
