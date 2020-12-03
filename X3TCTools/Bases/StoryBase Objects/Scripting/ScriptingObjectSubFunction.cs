using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;
using X3Tools;

namespace X3TCTools.Bases.StoryBase_Objects.Scripting
{
    public class ScriptingObjectSubFunction : MemoryObject
    {
        #region Memory
        public int unknown_1;
        public int stringOffset;
        public int unknown_3;
        public int unknown_4;
        #endregion

        public string str => GameHook.storyBase.GetStringFromStoryBaseCharArray(stringOffset).value;
        public override int ByteSize => 0x10;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            unknown_1 = objectByteList.PopInt();
            stringOffset = objectByteList.PopInt();
            unknown_3 = objectByteList.PopInt();
            unknown_4 = objectByteList.PopInt();
        }

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}
