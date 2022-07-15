using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptTableObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptTableObject
    {
        public struct ScriptHashTableEntry : IMemoryObject
        {

            public MemoryObjectPointer<ScriptHashTableEntry> pNext;
            public DynamicValue Id;
            public DynamicValue Value;

            public IntPtr pThis { get; set; }
            public IntPtr hProcess { get; set; }

            public int ByteSize => 14;

            public byte[] GetBytes()
            {
                throw new NotImplementedException();
            }

            public void ReloadFromMemory()
            {
                SetData(MemoryControl.Read(hProcess, pThis, ByteSize));
            }

            public void SetData(byte[] Memory)
            {
                var memoryObjectConverter = new MemoryObjectConverter(Memory,hProcess, pThis);
                pNext = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<ScriptHashTableEntry>>();
                Id = memoryObjectConverter.PopIMemoryObject<DynamicValue>();
                Value = memoryObjectConverter.PopIMemoryObject<DynamicValue>();
            }

            public void SetLocation(IntPtr hProcess, IntPtr address)
            {
                pThis = address;
                this.hProcess = hProcess;
            }
        }


        #region Memory Fields
        public int ID;
        public int Unknown_1;
        public MemoryObjectPointer<MemoryObjectPointer<ScriptHashTableEntry>> ppEntries;
        public int TableLength;
        public int NextAvailableID;
        public override int Count { get; set; }
        #endregion

        #region Common
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
            return null;
        }

        public override DynamicValue[] ScanContents()
        {
            List<DynamicValue> result = new List<DynamicValue>();
            for(int index = 0; index < TableLength; index++)
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
        #endregion

        #region IMemoryObject
        public override int ByteSize => 24;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            ID = objectByteList.PopInt();
            Unknown_1 = objectByteList.PopInt();
            ppEntries = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<ScriptHashTableEntry>>>();
            TableLength = objectByteList.PopInt();
            NextAvailableID = objectByteList.PopInt();
            Count = objectByteList.PopInt();
        }
        #endregion
    }
}
