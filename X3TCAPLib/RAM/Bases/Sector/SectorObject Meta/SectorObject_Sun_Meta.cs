﻿using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;

namespace X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta
{
    public class SectorObject_Sun_Meta : ISectorObjectMeta
    {
        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public int ByteSize => 8;

        public IntPtr pThis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMemoryBlockManager ParentMemoryBlock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ReloadFromMemory()
        {
            throw new NotImplementedException();
        }

        public SetDataResult SetData(byte[] Memory)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }

        public XCommonLib.RAM.Bases.Sector.SectorObject[] GetChildren()
        {
            throw new NotImplementedException();
        }

        public XCommonLib.RAM.Bases.Sector.SectorObject[] GetChildren(int main_Type)
        {
            throw new NotImplementedException();
        }
    }
}
