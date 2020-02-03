using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;
using Common.Vector;

using X3TCTools;

namespace X3TCTools.Bases
{
    public class SystemBase : MemoryObject
    {
        public const int ByteSize = 1960;

        public byte[] top = new byte[204];
        public X3FixedPointValue SETAValue = new X3FixedPointValue();
        public byte[] bottom = new byte[ByteSize - 204 - 4];

        public SystemBase()
        {

        }

        #region Set Individual
        public void SaveSETA()
        {
            MemoryControl.Write(m_hProcess, pThis + 204, SETAValue.GetBytes());
        }
        #endregion

        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(top);
            collection.Append(SETAValue);
            collection.Append(bottom);

            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref top);
            collection.PopFirst(ref SETAValue);
            collection.PopFirst(ref bottom);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
    }
}
