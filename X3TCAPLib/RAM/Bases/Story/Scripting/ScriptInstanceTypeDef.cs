using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceTypeDef : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceTypeDef
    {
        #region Memory
        public int Unknown_1 { get; set; }
        public IntPtr pSelf { get; set; }
        public int Unknown_2 { get; set; }
        public int BaseClass { get; set; }
        public MemoryObjectPointer<ScriptInstanceTypeDef> pBase;
        public int Unknown_3 { get; set; }
        public int ScriptVariableCount { get; set; }
        public int Unknown_4 { get; set; }
        public int Unknown_5 { get; set; }
        public int FunctionCount_1 { get; set; }
        public MemoryObjectPointer<ScriptInstanceFunction> pFunctions;
        public int Unknown { get; set; }
        #endregion
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceTypeDef BaseType => pBase.IsValid ? pBase.obj : null;

        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceFunction[] Functions
        {
            get
            {
                ScriptInstanceFunction[] result = new ScriptInstanceFunction[FunctionCount_1];
                for (int i = 0; i < result.Length; i++)
                    result[i] = pFunctions.GetObjectInArray(i);
                return result;
            }
        }

        #region MemoryObject
        public override int ByteSize => 52;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            Class = memoryObjectConverter.PopInt();
            Unknown_1 = memoryObjectConverter.PopInt();
            pSelf = memoryObjectConverter.PopIntPtr();
            Unknown_2 = memoryObjectConverter.PopInt();
            BaseClass = memoryObjectConverter.PopInt();
            pBase = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceTypeDef>>();
            Unknown_3 = memoryObjectConverter.PopInt();
            ScriptVariableCount = memoryObjectConverter.PopInt();
            Unknown_4 = memoryObjectConverter.PopInt();
            Unknown_5 = memoryObjectConverter.PopInt();
            FunctionCount_1 = memoryObjectConverter.PopInt();
            pFunctions = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceFunction>>();
            Unknown = memoryObjectConverter.PopInt();
        }
        #endregion
    }
}
