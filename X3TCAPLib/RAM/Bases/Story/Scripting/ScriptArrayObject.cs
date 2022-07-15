using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptArrayObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptArrayObject
    {
        public override int ID { get; set; }
        public int Unknown;
        public override int Length { get; set; }
        public override int Count { get; set; }
        public override MemoryObjectPointer<DynamicValue> pArr { get; set; }

        public override int ByteSize => 20;

        public override byte[] GetBytes()
        {
            var moc = new MemoryObjectConverter();
            moc.Append(ID);
            moc.Append(Unknown);
            moc.Append(Length);
            moc.Append(Count);
            moc.Append(pArr);
            return moc.GetBytes();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            ID = objectByteList.PopInt();
            Unknown = objectByteList.PopInt();
            Length = objectByteList.PopInt();
            Count = objectByteList.PopInt();
            pArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<DynamicValue>>();
        }
    }
}
