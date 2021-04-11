using System;

namespace X3Tools.RAM.Bases.Sector.Meta
{
    public class SectorObject_Sun_Meta : ISectorObjectMeta
    {
        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int ByteSize => 8;

        public IntPtr pThis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IntPtr hProcess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SectorObject GetFirstChild(SectorObject.Main_Type main_Type)
        {
            return null;
        }

        public SectorObject GetLastChild(SectorObject.Main_Type main_Type)
        {
            return null;
        }

        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }

        public void SetData(byte[] Memory)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }

        public SectorObject[] GetChildren()
        {
            throw new NotImplementedException();
        }

        public SectorObject[] GetChildren(SectorObject.Main_Type main_Type)
        {
            throw new NotImplementedException();
        }
    }
}
