using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.Bases
{
    public class ScriptObject : IMemoryObject
    {
        #region IMemoryObject
        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int GetByteSize()
        {
            throw new NotImplementedException();
        }

        public void SetData(byte[] Memory)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
