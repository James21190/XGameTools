﻿using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.Story.Scripting
{
    public class ScriptStringObject : XCommonLib.RAM.Bases.Story.Scripting.ScriptStringObject
    {
        #region Memory Fields
        public int id;
        public int unknown_1;
        public MemoryObjectPointer<MemoryString> pText = new MemoryObjectPointer<MemoryString>();
        #endregion

        #region Common
        public override MemoryString Text => pText.obj;
        #endregion

        #region IMemoryObject
        public override int ByteSize => 12;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            id = memoryObjectConverter.PopInt();
            unknown_1 = memoryObjectConverter.PopInt();
            pText = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
        }
        #endregion
    }
}
