using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptTaskObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject
    {
        #region Memory Fields
        public override int ID { get; set; }
        public override int StackSize { get; set; }

        private MemoryObjectPointer<DynamicValue> _pStackTop;

        public override DynamicValue[] Stack
        {
            get
            {
                DynamicValue[] result = new DynamicValue[StackSize];
                for(int i = 0; i < StackSize; i++)
                {
                    result[i] = _pStackTop.GetObjectInArray(-i);
                }
                return result;
            }
        }

        public override int InstructionIndex { get; set; }
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public override int ByteSize => 0x40;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter moc)
        {
            moc.Seek(0x8);
            ID = moc.PopInt();

            moc.Seek(0x10);
            StackSize = moc.PopInt();
            _pStackTop = moc.PopIMemoryObject<MemoryObjectPointer<DynamicValue>>(4);
        }
        #endregion
    }
}
