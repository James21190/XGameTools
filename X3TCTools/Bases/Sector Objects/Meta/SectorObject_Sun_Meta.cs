using System;

namespace X3TCTools.Sector_Objects.Meta
{
    public class SectorObject_Sun_Meta : ISectorObjectMeta
    {
        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int ByteSize => 8;

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
    }
}
