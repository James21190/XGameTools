using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Memory
{
    public sealed class MemoryObjectPointer
    {

        public MemoryObjectPointer(IntPtr hProcess, IntPtr address)
        {
            this.hProcess = hProcess;
            this.intPtr = address;
        }

        public readonly IntPtr hProcess;
        uint address;
        IntPtr intPtr
        {
            get
            {
                return (IntPtr)address;
            }
            set
            {
                this.address = (uint)value;
            }
        }

        public T GetObject<T>() where T : IMemoryObject, new()
        {
            var obj = new T();
            obj.SetData(MemoryControl.Read(hProcess, intPtr, obj.GetByteSize()));
            return obj;
        }

    }
}
