using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptTaskObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject
    {
        #region Memory Fields
        public override int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int StackSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override DynamicValue[] Stack => throw new NotImplementedException();

        public override int InstructionIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public override int ByteSize => throw new NotImplementedException();


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
