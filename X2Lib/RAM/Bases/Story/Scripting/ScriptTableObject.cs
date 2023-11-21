using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X2Lib.RAM.Bases.Story.Scripting
{
    public class ScriptTableObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptTableObject
    {
        public struct ScriptHashTableEntry : IMemoryObject
        {

            public MemoryObjectPointer<ScriptHashTableEntry> pNext;
            public DynamicValue Id;
            public DynamicValue Value;

            public IntPtr pThis { get; set; }
            public IMemoryBlockManager ParentMemoryBlock { get; set; }

            public int ByteSize => 14;

            public byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            public void ReloadFromMemory()
            {
                SetData(ParentMemoryBlock.ReadBytes(pThis, ByteSize));
            }

            public void SetData(byte[] Memory)
            {
                var memoryObjectConverter = new MemoryObjectConverter(Memory, ParentMemoryBlock, pThis);
                pNext = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<ScriptHashTableEntry>>();
                Id = memoryObjectConverter.PopIMemoryObject<DynamicValue>();
                Value = memoryObjectConverter.PopIMemoryObject<DynamicValue>();
            }

            public void SetData(BinaryObjectConverter boc)
            {
                throw new NotImplementedException();
            }
        }

        public MemoryObjectPointer<MemoryObjectPointer<ScriptHashTableEntry>> ppEntries;
        public int TableLength;
        public override int Count { get; set; }

        public override int ByteSize => 0x18;

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            ppEntries = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<ScriptHashTableEntry>>>(0x8);
            TableLength = objectByteList.PopInt();

            Count = objectByteList.PopInt(0x14);
        }

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override DynamicValue GetObject(DynamicValue id)
        {
            var index = GetIndex(id);

            var pEntry = ppEntries.GetObjectInArray(index);

            if (pEntry.IsValid)
            {
                var entry = pEntry.obj;
                while (true)
                {
                    if (entry.Id == id)
                        return entry.Value;
                    if (!entry.pNext.IsValid)
                        break;
                    entry = entry.pNext.obj;
                }
            }
            return DynamicValue.Null;
        }

        public override DynamicValue[] ScanContents()
        {
            List<DynamicValue> result = new List<DynamicValue>();
            for (int index = 0; index < TableLength; index++)
            {
                var pEntry = ppEntries.GetObjectInArray(index);

                if (pEntry.IsValid)
                {
                    var entry = pEntry.obj;
                    while (true)
                    {
                        result.Add(entry.Id);
                        if (!entry.pNext.IsValid)
                            break;
                        entry = entry.pNext.obj;
                    }
                }
            }
            return result.ToArray();
        }

        public override int GetIndex(DynamicValue id)
        {
            switch (id.Flag)
            {
                case DynamicValue.FlagType.Int:
                    return (TableLength - 1) & id.Value;
            }
            throw new NotImplementedException();
        }
    }
}
