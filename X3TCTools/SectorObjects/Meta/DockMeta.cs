using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.SectorObjects.Meta
{
    public class DockMeta : ISectorObjectMeta
    {
        public const int ByteSize = 480;

        public SectorObject.ListTop[] ChildrenList = new SectorObject.ListTop[SectorObject.MAIN_TYPE_COUNT];

        private GameHook m_GameHook;

        public DockMeta(GameHook gameHook, IntPtr address)
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

        public SectorObject.ListTop[] GetChildrenList()
        {
            return ChildrenList;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);
            collection.PopFirst(ref ChildrenList);
        }
    }
}
