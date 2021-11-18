using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Generics
{
    public interface IBinaryObject
    {
        /// <summary>
        /// The size of the object in bytes.
        /// </summary>
        /// <returns></returns>
        int ByteSize { get; }
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
