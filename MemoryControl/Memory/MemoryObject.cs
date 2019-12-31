using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory.Unimplemented
{
    /// <summary>
    /// The base class of memory objects.
    /// </summary>
    public abstract class MemoryObject : IMemoryObject
    {
        #region IMemoryObject
        public virtual int GetByteSize()
        {
            return GetBytes().Length;
        }
        public abstract byte[] GetBytes();
        public abstract void SetData(byte[] Memory);
        #endregion
    }
}
