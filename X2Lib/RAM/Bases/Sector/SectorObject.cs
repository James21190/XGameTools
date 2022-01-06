using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using X2Lib.RAM.Bases.B3D;
using X2Lib.RAM.Bases.Sector.SectorObject_Meta;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;

namespace X2Lib.RAM.Bases.Sector
{
    public class SectorObject : XCommonLib.RAM.Bases.Sector.SectorObject
    {
        #region Memory Fields
        // All values stored in memory
        public MemoryObjectPointer<SectorObject> pNext = new MemoryObjectPointer<SectorObject>();
        public MemoryObjectPointer<SectorObject> pPrevious = new MemoryObjectPointer<SectorObject>();
        public override int ID { get; set; }
        public MemoryObjectPointer<MemoryString> pDefaultName = new MemoryObjectPointer<MemoryString>();
        public override int Speed { get; set; }
        public override int DesiredSpeed { get; set; }
        public override Vector3_32 EulerRotationCopy { get; set; }
        public override Vector3_32 LocalEulerRotationDelta { get; set; }
        public override Vector3_32 LocalAutopilotRotationDeltaTarget { get; set; }
        public override ushort RaceID { get; set; }
        public ushort Unknown_4;
        public override BitField InteractionFlags { get; set; }
        public int Unknown_5;
        // base.ObjectType
        public IntPtr pMeta;
        public override ISectorObjectMeta Meta
        {
            get
            {
                ISectorObjectMeta meta;
                switch ((X2GameHook.MainType_X2)ObjectType.MainType)
                {
                    case X2GameHook.MainType_X2.Sector: meta = new SectorObject_Sector_Meta(); break;
                    case X2GameHook.MainType_X2.Dock:
                    case X2GameHook.MainType_X2.Factory: meta = new SectorObject_Station_Meta(); break;
                    case X2GameHook.MainType_X2.Ship: meta = new SectorObject_Ship_Meta(); break;
                    default: return null;
                }
                meta.hProcess = hProcess;
                meta.pThis = pMeta;
                meta.ReloadFromMemory();
                return meta;
            }
        }
        public MemoryObjectPointer<SectorObject> pParent = new MemoryObjectPointer<SectorObject>();
        public override Vector3_32 PositionStrafeDelta { get; set; }
        public MemoryObjectPointer<RenderObject> pRenderObject = new MemoryObjectPointer<RenderObject>();
        public int Unknown_6;
        public int Unknown_7;
        public int RunObjectParamID;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public int Unknown_12;
        public override int ScriptInstanceID { get; set; }
        public int Unknown_14;
        public int ModelCollectionID;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public IntPtr p1;
        public int Unknown_19;
        public IntPtr p2;
        public override Vector3_32 CopyPosition { get; set; }
        public Vector3_32 EulterRotationCopy;
        public Vector3_32 LocalEulerRotationDeltaCopy;
        public int SpeedCopy;
        public int Hull;
        public int Unknown_20;
        public int Unknown_21;
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject Next => pNext.obj.IsValid ? pNext.obj : null;
        public override XCommonLib.RAM.Bases.Sector.SectorObject Previous => pPrevious.obj.IsValid ? pPrevious.obj : null;
        public override MemoryString DefaultName => pDefaultName.obj;
        public override XCommonLib.RAM.Bases.B3D.RenderObject RenderObject => pRenderObject.obj.IsValid ? pRenderObject.obj : null;
        #endregion

        public override bool IsValid =>
            pNext.address != IntPtr.Zero &&
            pPrevious.address != IntPtr.Zero;

        #region IMemoryObject
        public override int ByteSize => 0xdc;
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
            EulerRotationCopy = memoryObjectConverter.PopIMemoryObject<Vector3_32>();
            LocalEulerRotationDelta = memoryObjectConverter.PopIMemoryObject<Vector3_32>();
            LocalAutopilotRotationDeltaTarget = memoryObjectConverter.PopIMemoryObject<Vector3_32>();
            RaceID = memoryObjectConverter.PopUShort();

            ObjectType = memoryObjectConverter.PopIMemoryObject<SectorObjectType>(0x48);
            pMeta = memoryObjectConverter.PopIntPtr();

            ScriptInstanceID = memoryObjectConverter.PopInt(0x80);

            ModelCollectionID = memoryObjectConverter.PopInt(0x88);

            CopyPosition = memoryObjectConverter.PopIMemoryObject<Vector3_32>(0xa8);
        }
        #endregion
    }
}
