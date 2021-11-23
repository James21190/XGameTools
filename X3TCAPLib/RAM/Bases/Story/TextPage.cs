using CommonToolLib.ProcessHooking;
using System;
using X3TCAPLib.RAM.Bases.Story.Scripting;

namespace X3TCAPLib.RAM.Bases.Story
{
    public class TextPage : XCommonLib.RAM.Bases.Story.TextPage
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

                protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
                {
                    U_1 = objectByteList.PopInt();
                }
            }
            public int ID;
            public XCommonLib.RAM.Bases.Story.Scripting.DynamicValue Value;
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
            protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
            {
                ID = objectByteList.PopInt();
                Value = objectByteList.PopIMemoryObject<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>();
                Unknown_2 = objectByteList.PopByte();
                Unknown_3 = objectByteList.PopByte();
                Unknown_4 = objectByteList.PopByte();
            }
        }

        public int Count;
        public MemoryObjectPointer<TextEntry> pEntries = new MemoryObjectPointer<TextEntry>();
        public int Unknown;

        public TextEntry[] TextEntries
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
                    var strObj = new ScriptStringObject();
                    strObj.hProcess = hProcess;
                    strObj.pThis = (IntPtr)entry.Value.Value;
                    strObj.ReloadFromMemory();
                    return strObj;
                }
            }
            throw new IndexOutOfRangeException();
        }

        public override MemoryString GetText(int id)
        {
            return _GetTextObject(id).Text;
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

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            Count = objectByteList.PopInt();
            pEntries = objectByteList.PopIMemoryObject<MemoryObjectPointer<TextEntry>>();
            Unknown = objectByteList.PopInt();
        }

    }
}
