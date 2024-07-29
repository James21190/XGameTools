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

        public const int BYTE_SIZE = 0x78;
        public override int ByteSize => BYTE_SIZE;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            pNext = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            pPrevious = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            ID = memoryObjectConverter.PopInt();
            pDefaultName = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            Speed = memoryObjectConverter.PopInt();
            DesiredSpeed = memoryObjectConverter.PopInt();

            memoryObjectConverter.Seek(0x54);
            ObjectType = memoryObjectConverter.PopIMemoryObject<SectorObjectType>();

            memoryObjectConverter.Seek(0x5c);
            pParent = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();

            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
    }
}
