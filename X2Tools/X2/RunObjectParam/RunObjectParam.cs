using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Tools.X2.RunObjectParam
{
    /// <summary>
    /// Currently not understood.
    /// </summary>
    public class RunObjectParam
    {
        public const int ByteLength = 1232;

        public IntPtr Next;
        public IntPtr Previous;
        public int ID;

        public RunObjectParam(byte[] Memory)
        {
            Next = (IntPtr)BitConverter.ToInt32(Memory, 0);
            Previous = (IntPtr)BitConverter.ToInt32(Memory,4);
            ID = BitConverter.ToInt32(Memory,8);
        }
    }
}
