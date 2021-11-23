using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptTaskObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptTaskObject
    {
        #region Memory Fields
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public override int ByteSize => throw new NotImplementedException();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            base.SetDataFromMemoryObjectConverter(objectByteList);
        }
        #endregion
    }
}
