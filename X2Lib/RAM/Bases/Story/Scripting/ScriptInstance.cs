using CommonToolLib.Memory;
using System;

namespace X2Lib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int ReferenceCount { get; set; }
        public MemoryObjectPointer<MemoryInt32> pSub;
        public MemoryObjectPointer<MemoryInt32> pScriptVariableArr;
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public override int ByteSize => 16;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            base.SetDataFromObjectByteList(objectByteList);
        }
        #endregion
    }
}
