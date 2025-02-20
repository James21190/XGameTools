using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstance : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance
    {
        #region Memory Fields
        public override int NegativeID { get; set; }
        public override int[] Classes
        {
            get {
                List<int> lst = new List<int>();
                for(ScriptInstanceTypeDef sub = _SubCopy; sub != null;)
                {
                    lst.Add(sub.Class);
                    if (sub.pBase.IsValid)
                    {
                        sub = sub.pBase.obj;
                    }
                    else
                    {
                        sub = null;
                    }
                }
                return lst.ToArray();
            }
        }

        public override int ScriptVariableCount
        {
            get => _SubCopy.ScriptVariableCount;
            set => _SubCopy.ScriptVariableCount = value;
        }
        public override int ReferenceCount { get; set; }
        public override MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue> pScriptVariableArr { get; set; }
        public MemoryObjectPointer<ScriptInstanceTypeDef> pSub { get; set; }
        #endregion

        public override FunctionInfo[] Functions
        {
            get
            {
                List<FunctionInfo> result = new List<FunctionInfo>();
                for(ScriptInstanceTypeDef sub = pSub.obj; sub != null;)
                {
                    for(int i = 0; i < sub.FunctionCount_1; i++)
                    {
                        result.Add(
                            new FunctionInfo
                            {
                                Function = sub.pFunctions.GetObjectInArray(i),
                                Class = sub.Class
                            }
                        );
                    }
                    if (sub.pBase.IsValid)
                    {
                        sub = sub.pBase.obj;
                    }
                    else
                    {
                        sub = null;
                    }
                }
                return result.ToArray();
            }
        }

        private ScriptInstanceTypeDef _SubCopy;

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

            _SubCopy = pSub.obj;
            
            pScriptVariableArr = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<XCommonLib.RAM.Bases.Story.Scripting.DynamicValue>>();
        }
        #endregion
    }
}
