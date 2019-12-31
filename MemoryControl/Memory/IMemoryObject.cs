using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
{
    public interface IMemoryObject
    {
        /// <summary>
        /// Returns the size of the object in bytes.
        /// </summary>
        /// <returns></returns>
        int GetByteSize();
        /// <summary>
        /// Sets values in the object from a byte array.
        /// </summary>
        /// <param name="Memory"></param>
        void SetData(byte[] Memory);
        /// <summary>
        /// Returns the object in bytes.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}
