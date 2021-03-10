using System;

namespace Common.Memory
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

    public interface IMemoryObject : IBinaryObject
    {
        IntPtr pThis { get; set; }
        IntPtr hProcess { get; set; }

        [ObsoleteAttribute("This method is no longer in use. Use pThis and hProcess instead.", false)]
        void SetLocation(IntPtr hProcess, IntPtr address);

        /// <summary>
        /// Reloads values from memory with the data provided by SetLocation.
        /// </summary>
        void ReloadFromMemory();
    }
}
