using System;

namespace Common.Memory
{
    public interface IBinaryObject
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

    public interface IMemoryObject : IBinaryObject
    {
        void SetLocation(IntPtr hProcess, IntPtr address);

        /// <summary>
        /// Reloads values from memory with the data provided by SetLocation.
        /// </summary>
        void ReloadFromMemory();
    }
}
