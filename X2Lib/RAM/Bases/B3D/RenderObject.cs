using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;

namespace X2Lib.RAM.Bases.B3D
{
    public class RenderObject : XCommonLib.RAM.Bases.B3D.RenderObject
    {
        #region Memory Fields
        public MemoryObjectPointer<RenderObject> pNext;
        public MemoryObjectPointer<RenderObject> pPrevious;

        public MemoryObjectPointer<RenderObject> pFirstChild;
        public MemoryObjectPointer<RenderObject> pLastChild;
        
        public MemoryObjectPointer<RenderObject> pParent;

        public RotationMatrix_3 Rotation;
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.B3D.RenderObject Parent => pParent.IsValid ? pParent.obj : null;
        public override XCommonLib.RAM.Bases.B3D.RenderObject[] GetChildren(bool getChildrenOfChildren)
        {
            List<XCommonLib.RAM.Bases.B3D.RenderObject> result = new List<XCommonLib.RAM.Bases.B3D.RenderObject>();
            var child = pFirstChild.obj;
            while (child.pNext.IsValid)
            {
                result.Add(child);
                if(getChildrenOfChildren)
                {
                    result.AddRange(child.GetChildren(true));
                }
                child = child.pNext.obj;
            }
            return result.ToArray();
        }
        #endregion

        #region MemoryObject
        public const int BYTE_SIZE = 488;
        public override int ByteSize => BYTE_SIZE;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            pNext = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            pPrevious = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();

            memoryObjectConverter.Seek(0xc);
            pFirstChild = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();

            memoryObjectConverter.Seek(0x14);
            pLastChild = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            pParent = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();

            memoryObjectConverter.Seek(0x24);
            ID = memoryObjectConverter.PopInt();
            Position = memoryObjectConverter.PopIBinaryObject<Vector3_32>();
            Rotation = memoryObjectConverter.PopIBinaryObject<RotationMatrix_3>();

            memoryObjectConverter.Seek(0xf0);
            BodyID = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x1d8);
            CollectionID = memoryObjectConverter.PopInt();

            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
        #endregion
    }
}
