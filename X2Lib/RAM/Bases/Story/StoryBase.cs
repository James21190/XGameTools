using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib.Memory;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X2Lib.RAM.Bases.Story
{
    public class StoryBase : XCommonLib.RAM.Bases.Story.StoryBase
    {
        #region Memory Fields
        public override MemoryObjectPointer<MemoryString> pStrings => throw new NotImplementedException();
        #endregion

        #region Common
        public override ScriptInstance GetScriptInstance(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MemoryObject
        public override int ByteSize => throw new NotImplementedException();


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
