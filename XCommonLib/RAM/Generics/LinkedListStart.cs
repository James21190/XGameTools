﻿using CommonToolLib.ProcessHooking;
using System;

namespace XCommonLib.RAM.Generics
{
    /// <summary>
    /// Top of a linked list for objects. Holds pointers to both the first and last object in a list.
    /// Notabaly used for children of an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListStart<T> : MemoryObject where T : IMemoryObject, new()
    {
        // Pointer to the first object.
        public MemoryObjectPointer<T> pFirst = new MemoryObjectPointer<T>();
        // Null value used when no objects are in the list.
        public int NullValue;
        // Pointer to the last object.
        public MemoryObjectPointer<T> pLast = new MemoryObjectPointer<T>();

        public override byte[] GetBytes()
        {
            MemoryObjectConverter collection = new MemoryObjectConverter();
            collection.Append(pFirst);
            collection.Append(NullValue);
            collection.Append(pLast);
            return collection.GetBytes();
        }

        public const int BYTE_SIZE = 12;
        public override int ByteSize => BYTE_SIZE;

        public override void SetData(byte[] data, out int bytesConsumed)
        {
            MemoryObjectConverter collection = new MemoryObjectConverter(data, ParentMemoryBlock, pThis);
            pFirst = collection.PopIMemoryObject<MemoryObjectPointer<T>>();
            NullValue = collection.PopInt();
            pLast = collection.PopIMemoryObject<MemoryObjectPointer<T>>();
            bytesConsumed = BYTE_SIZE;
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            throw new NotSupportedException();
        }

        public override IMemoryBlockManager ParentMemoryBlock
        {
            get => base.ParentMemoryBlock;
            set
            {
                pFirst.ParentMemoryBlock = value;
                pLast.ParentMemoryBlock = value;
                base.ParentMemoryBlock = value;
            }
        }

        public override IntPtr pThis
        {
            get => base.pThis;
            set
            {
                pFirst.pThis = value;
                pLast.pThis = value + 0x8;
                base.pThis = value;
            }
        }
    }
}
