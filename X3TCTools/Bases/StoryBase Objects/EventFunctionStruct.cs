using Common.Memory;
using System;
using System.Collections.Generic;

namespace X3TCTools.Bases.StoryBase_Objects
{
    public class EventFunctionStruct : MemoryObject
    {
        public IntPtr pPrimaryFunction;
        public IntPtr pFunction2;
        public IntPtr pFunction3;
        public IntPtr pFunction4;
        public MemoryObjectPointer<MemoryObjectPointer<MemoryString>> ppString = new MemoryObjectPointer<MemoryObjectPointer<MemoryString>>();
        public int Index;

        public string[] FunctionNames
        {
            get
            {
                List<string> result = new List<string>();
                int i = 0;
                while (true)
                {
                    var pString = ppString[i++];
                    if (pString.address == IntPtr.Zero)
                        break;
                    result.Add(pString.obj.value);
                }
                return result.ToArray();
            }
        }
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 24;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            pPrimaryFunction = objectByteList.PopIntPtr();
            pFunction2 = objectByteList.PopIntPtr();
            pFunction3 = objectByteList.PopIntPtr();
            pFunction4 = objectByteList.PopIntPtr();
            ppString = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<MemoryString>>>();
            Index = objectByteList.PopInt();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            ppString.SetLocation(hProcess, address + 0x10);
        }
    }
}
