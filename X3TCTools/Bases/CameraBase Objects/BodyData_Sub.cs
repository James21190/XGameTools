﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.Bases.CameraBase_Objects
{
    public class BodyData_Sub : MemoryObject
    {
        public const int ByteSize = 96;

        public short SubLength;

        public MemoryObjectPointer<MemoryObjectPointer<MemoryInt32>> ppSub = new MemoryObjectPointer<MemoryObjectPointer<MemoryInt32>>();

        public MemoryObjectPointer<BodyData> pParentBodyData = new MemoryObjectPointer<BodyData>();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            SubLength = objectByteList.PopShort(4);

            ppSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<MemoryInt32>>>(16);

            pParentBodyData = objectByteList.PopIMemoryObject<MemoryObjectPointer<BodyData>>(84);
        }
    }
}