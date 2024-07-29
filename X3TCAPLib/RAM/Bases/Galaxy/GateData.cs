﻿using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCAPLib.RAM.Bases.Galaxy
{
    public class GateData : XCommonLib.RAM.Bases.Galaxy.GateData
    {
        #region Memory Fields
        public override int DestinationSectorX { get; set; }
        public override int DestinationSectorY { get; set; }
        public override int DestinationSectorIndex { get; set; }

        public int Unknown1;
        public int Unknown2;
        public int Unknown3;
        public Vector3_32 Position;
        public int Unknown4;
        #endregion

        #region Common
        #endregion

        #region IMemoryObject
        public const int BYTE_SIZE = 0x20;
        public override int ByteSize => BYTE_SIZE;


        public override byte[] GetBytes()
        {
            var objectByteList = new MemoryObjectConverter();
            objectByteList.Append((byte)DestinationSectorX);
            objectByteList.Append((byte)DestinationSectorY);
            objectByteList.Append((short)DestinationSectorIndex);
            objectByteList.Append(Unknown1);
            objectByteList.Append(Unknown2);
            objectByteList.Append(Unknown3);
            objectByteList.Append(Position);
            objectByteList.Append(Unknown4);
            return objectByteList.GetBytes();
        }

        public override void WriteSafeToMemory()
        {
            var objectByteList = new MemoryObjectConverter();
            objectByteList.Append((byte)DestinationSectorX);
            objectByteList.Append((byte)DestinationSectorY);
            objectByteList.Append((short)DestinationSectorIndex);

            ParentMemoryBlock.WriteBytes(pThis, objectByteList.GetBytes());
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            DestinationSectorX = memoryObjectConverter.PopByte();
            DestinationSectorY = memoryObjectConverter.PopByte();
            DestinationSectorIndex = memoryObjectConverter.PopShort();
            Unknown1 = memoryObjectConverter.PopInt();
            Unknown2 = memoryObjectConverter.PopInt();
            Unknown3 = memoryObjectConverter.PopInt();
            Position = memoryObjectConverter.PopIBinaryObject<Vector3_32>();
            Unknown4 = memoryObjectConverter.PopInt();
        }
        #endregion
    }
}
