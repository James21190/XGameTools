using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public class ShipMeta : ISectorObjectMeta
    {
        public const int ByteSize = 1168;

        private GameHook m_GameHook;

        public SectorObject.ListTop[] ChildrenList = new SectorObject.ListTop[SectorObject.MAIN_TYPE_COUNT];

        public ShipMeta(GameHook gameHook, IntPtr address)
        {
            m_GameHook = gameHook;
            SetData(MemoryControl.Read(gameHook.hProcess, address, ByteSize));
        }

        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(ChildrenList);
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

            collection.PopFirst(ref ChildrenList);
        }

        public SectorObject.ListTop[] GetChildrenList()
        {
            return ChildrenList;
        }
    }
}
