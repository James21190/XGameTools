using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            base.SetDataFromObjectByteList(objectByteList);
        }
        #endregion
    }
}
