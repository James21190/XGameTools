using CommonToolLib.ProcessHooking;
using System;

namespace X2Lib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int ReferenceCount { get; set; }
        //public MemoryObjectPointer<ScriptInstanceSub> pSub;
        public override MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue> pScriptVariableArr { get; set; }
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceSub Sub => throw new NotImplementedException();
        #endregion

        #region IMemoryObject
        public override int ByteSize => 16;

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
