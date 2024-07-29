using System.IO;

namespace CommonToolLib.Generics.BinaryObjects
{
    public interface IBinaryObject
    {
        /// <summary>
        /// Sets values in the object from a byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bytesConsumed"></param>
        void SetData(byte[] data, out int bytesConsumed);

        /// <summary>
        /// Returns the object in bytes.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}
