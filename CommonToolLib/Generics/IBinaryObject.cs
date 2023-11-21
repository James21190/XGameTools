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

        /// <summary>
        /// Sets the values in the object from a BinaryObjectConverter.
        /// This approach means that objects with variable length can be easily popped from the converter.
        /// </summary>
        /// <param name="boc"></param>
        void SetData(BinaryObjectConverter boc);

        /// <summary>
        /// Returns the object in bytes.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytes();
    }
}
