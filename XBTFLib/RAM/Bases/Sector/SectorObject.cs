using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;

namespace XBTFLib.RAM.Bases.Sector
{
    public class SectorObject : XCommonLib.RAM.Bases.Sector.SectorObject
    {

        #region Memory
        public MemoryObjectPointer<SectorObject> pNext;
        public MemoryObjectPointer<SectorObject> pPrevious;
        public override int ID { get; set; }
        public MemoryObjectPointer<MemoryString> pDefaultName;
        public override int Speed { get; set; }
        public override int DesiredSpeed { get; set; }

        public MemoryObjectPointer<SectorObject> pParent;
        #endregion
        public override bool IsValid => pNext.IsValid && pPrevious.IsValid;

        public override XCommonLib.RAM.Bases.Sector.SectorObject Next => pNext.obj;

        public override XCommonLib.RAM.Bases.Sector.SectorObject Previous => pPrevious.obj;

        public override MemoryString DefaultName => pDefaultName.obj;

        public override Vector3_32 EulerRotationCopy { get; set; }
        public override Vector3_32 LocalEulerRotationDelta { get; set; }
        public override Vector3_32 LocalAutopilotRotationDeltaTarget { get; set; }
        public override ushort RaceID { get; set; }
        public override BitField InteractionFlags { get; set; }
        public override Vector3_32 CopyPosition { get; set; }
        public override Vector3_32 PositionStrafeDelta { get; set; }

        public override RenderObject RenderObject => throw new NotImplementedException();

        public override ISectorObjectMeta Meta => throw new NotImplementedException();

        public override int ScriptInstanceID { get; set; }
        public override int ModelCollectionID { get; set; }

        public override int ByteSize => 0x78;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            pPrevious = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            ID = objectByteList.PopInt();
            pDefaultName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            Speed = objectByteList.PopInt();
            DesiredSpeed = objectByteList.PopInt();

            ObjectType = objectByteList.PopIMemoryObject<SectorObjectType>(0x54);

            pParent = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>(0x5c);

            return SetDataResult.Success;
        }
    }
}
