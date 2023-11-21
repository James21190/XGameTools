using System.IO;

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
        /// <param name="data"></param>
        void SetData(byte[] data);

        void SetData(BinaryObjectConverter boc);

        /// <summary>
        /// Returns the object in bytes.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}
