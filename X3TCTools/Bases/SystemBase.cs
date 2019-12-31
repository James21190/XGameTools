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
    public class SystemBase : IMemoryObject
    {
        public const int ByteSize = 1960;

        public readonly IntPtr pThis;

        public byte[] top = new byte[204];
        public X3FixedPointValue SETAValue = new X3FixedPointValue();
        public byte[] bottom = new byte[ByteSize - 204 - 4];

        private GameHook m_GameHook; 

        public SystemBase(GameHook gameHook)
        {
            m_GameHook = gameHook;
            pThis = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)GameHook.GlobalAddresses.SystemBase);
        }

        #region Set Individual
        public void SaveSETA()
        {
            MemoryControl.Write(m_GameHook.hProcess, pThis + 204, SETAValue.GetBytes());
        }
        #endregion

        public void Reload()
        {
            SetData(MemoryControl.Read(m_GameHook.hProcess, pThis, ByteSize));
        }

        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(top);
            collection.Append(SETAValue);
            collection.Append(bottom);

            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref top);
            collection.PopFirst(ref SETAValue);
            collection.PopFirst(ref bottom);
        }
    }
}
