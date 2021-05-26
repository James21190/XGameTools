﻿using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.RAM.Bases.SystemBase_Objects
{
    public class SystemBaseStringCollection : MemoryObject
    {
        #region Memory
        public MemoryObjectPointer<MemoryString> pText;
        #endregion

        public override int ByteSize => 0x94;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            pText = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
        }
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}
