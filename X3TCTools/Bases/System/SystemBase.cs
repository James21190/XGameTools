﻿using Common.Memory;
using System;
using System.CodeDom.Compiler;
using X3Tools.Generics;

namespace X3Tools.Bases.SystemBase_Objects
{
    public class SystemBase : MemoryObject
    {
        #region Memory
        public int SystemFlags;

        public MemoryObjectPointer<SystemBaseStringCollection> pStringCollection;

        public X3FixedPointValue TimeWarpFactor = new X3FixedPointValue();

        public GameHook.Language Language;

        #endregion
        public SystemBase()
        {

        }

        #region Set Individual
        public void SaveSETA()
        {
            MemoryControl.Write(m_hProcess, pThis + 204, TimeWarpFactor.GetBytes());
        }

        public void SaveLanguage()
        {
            MemoryControl.Write(m_hProcess, pThis + 0x768, BitConverter.GetBytes((int)Language));
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
            SystemFlags = objectByteList.PopInt(0xbc);

            pStringCollection = objectByteList.PopIMemoryObject<MemoryObjectPointer<SystemBaseStringCollection>>(0xd8);

            TimeWarpFactor = objectByteList.PopIMemoryObject<X3FixedPointValue>(0xcc);

            Language = (GameHook.Language)objectByteList.PopInt(0x768);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}