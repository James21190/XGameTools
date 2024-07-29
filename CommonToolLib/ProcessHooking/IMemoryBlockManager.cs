using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using CommonToolLib.Generics.BinaryObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.ProcessHooking
{
    public interface IMemoryBlockManager
    {
        bool IsReadOnly { get; }
        byte[] ReadBytes(IntPtr address, int length);
        T ReadBinaryObject<T>(IntPtr address, int maxObjectSize) where T : IBinaryObject, new();
        T ReadMemoryObject<T>(IntPtr address, int maxObjectSize) where T : IMemoryObject, new();


        void WriteBytes(IntPtr address, byte[] bytes);
        void WriteBinaryObject(IntPtr address, IBinaryObject memoryObject);
    }
}
