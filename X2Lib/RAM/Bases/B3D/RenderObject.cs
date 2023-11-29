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
        public override int ByteSize => 488;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            pPrevious = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();

            pFirstChild = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>(0xc);

            pLastChild = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>(0x14);
            pParent = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();

            ID = objectByteList.PopInt(0x24);
            Position = objectByteList.PopIBinaryObject<Vector3_32>();
            Rotation = objectByteList.PopIBinaryObject<RotationMatrix_3>();

            BodyID = objectByteList.PopInt(0xf0);

            CollectionID = objectByteList.PopInt(0x1d8);

            return SetDataResult.Success;
        }
        #endregion
    }
}
