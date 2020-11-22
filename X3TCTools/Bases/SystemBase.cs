﻿using Common.Memory;
using System;
using System.CodeDom.Compiler;
using X3TCTools.Generics;

namespace X3TCTools.Bases
{
    public class SystemBase : MemoryObject
    {
        #region Memory
        public X3FixedPointValue SETAValue = new X3FixedPointValue();

        public GameHook.Language Language;

        #endregion
        public SystemBase()
        {

        }

        #region Set Individual
        public void SaveSETA()
        {
            MemoryControl.Write(m_hProcess, pThis + 204, SETAValue.GetBytes());
        }
        #endregion

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 1960;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            SETAValue = objectByteList.PopIMemoryObject<X3FixedPointValue>(204);

            Language = (GameHook.Language)objectByteList.PopInt(0x768);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
