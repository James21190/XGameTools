using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.RAM.Bases.Story.Scripting
{
    public abstract class ScriptInstanceSub : MemoryObject
    {
        #region Memory
        public abstract int Class { get; set; }
        public abstract int Unknown_1 { get; set; }
        public abstract IntPtr pSelf { get; set; }
        public abstract int Unknown_2 { get; set; }
        public abstract int NextID { get; set; }
        public abstract ScriptInstanceSub Next { get; }
        public abstract int Unknown_3 { get; set; }
        public abstract int ScriptVariableCount { get; set; }
        public abstract int Unknown_4 { get; set; }
        public abstract int Unknown_5 { get; set; }
        public abstract int FunctionCount_1 { get; set; }
        //public abstract MemoryObjectPointer<MemoryInt32> pFunctions { get; set; }
        public abstract int Unknown { get; set; }
        #endregion
    }
}
