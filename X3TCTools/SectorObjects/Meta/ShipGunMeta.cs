using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public class ShipGunMeta : ISectorObjectMeta
    {
        public const int ByteSize = 0;

        private GameHook m_GameHook;
        public ShipGunMeta(GameHook gameHook, IntPtr address)
        {
            m_GameHook = gameHook;
            SetData(MemoryControl.Read(gameHook.hProcess, address, ByteSize));
        }
        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public SectorObject.ListTop[] GetChildrenList()
        {
            return null;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);
        }
    }
}
