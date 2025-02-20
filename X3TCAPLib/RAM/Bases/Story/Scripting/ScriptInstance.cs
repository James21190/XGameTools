using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int ReferenceCount { get; set; }
        public override MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue> pScriptVariableArr { get; set; }
        public MemoryObjectPointer<ScriptInstanceTypeDef> pSub { get; set; }
        #endregion

        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceTypeDef TypeDef => pSub.obj;

        #region IMemoryObject
        public override int ByteSize => 16;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            NegativeID = memoryObjectConverter.PopInt();
            ReferenceCount = memoryObjectConverter.PopInt();
            pSub = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceTypeDef>>();            
            pScriptVariableArr = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>>();
        }
        #endregion
    }
}
