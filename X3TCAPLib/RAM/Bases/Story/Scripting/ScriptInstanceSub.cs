using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptInstanceSub : XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceSub
    {
        #region Memory
        public override int Class { get; set; }
        public override int Unknown_1 { get; set; }
        public override IntPtr pSelf { get; set; }
        public override int Unknown_2 { get; set; }
        public MemoryObjectPointer<ScriptInstanceSub> pNext;
        public override int NextID { get; set; }
        public override int Unknown_3 { get; set; }
        public override int ScriptVariableCount { get; set; }
        public override int Unknown_4 { get; set; }
        public override int Unknown_5 { get; set; }
        public override int FunctionCount_1 { get; set; }
        public MemoryObjectPointer<MemoryInt32> pFunctions;
        public override int Unknown { get; set; }
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceSub Next => pNext.obj;
        #endregion

        #region MemoryObject
        public override int ByteSize => 52;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            Class = objectByteList.PopInt();
            Unknown_1 = objectByteList.PopInt();
            pSelf = objectByteList.PopIntPtr();
            Unknown_2 = objectByteList.PopInt();
            NextID = objectByteList.PopInt();
            pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptInstanceSub>>();
            Unknown_3 = objectByteList.PopInt();
            ScriptVariableCount = objectByteList.PopInt();
            Unknown_4 = objectByteList.PopInt();
            Unknown_5 = objectByteList.PopInt();
            FunctionCount_1 = objectByteList.PopInt();
            pFunctions = objectByteList.PopIMemoryObject <MemoryObjectPointer<MemoryInt32>>();
            Unknown = objectByteList.PopInt();
        }
        #endregion
    }
}
