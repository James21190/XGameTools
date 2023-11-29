using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using X3TCAPLib.RAM.Bases.B3D;
using X3TCAPLib.RAM.Bases.Sector.SectorObject_Meta;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace X3TCAPLib.RAM.Bases.Sector
{
    public class SectorObject : XCommonLib.RAM.Bases.Sector.SectorObject
    {
        #region Memory Fields
        public MemoryObjectPointer<SectorObject> pNext;
        public MemoryObjectPointer<SectorObject> pPrevious;
        public override int ID { get; set; }
        public MemoryObjectPointer<MemoryString> pDefaultName;
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
        public int Unknown_6;
        public IntPtr pMeta;
        public override ISectorObjectMeta Meta
        {
            get
            {
                ISectorObjectMeta meta;
                switch ((X3TCGameHook.MainType_X3TCAP)ObjectType.MainType)
                {
                    case X3TCGameHook.MainType_X3TCAP.Sector: meta = new SectorObject_Sector_Meta(); break;
                    case X3TCGameHook.MainType_X3TCAP.Dock:
                    case X3TCGameHook.MainType_X3TCAP.Factory: meta = new SectorObject_Station_Meta(); break;
                    case X3TCGameHook.MainType_X3TCAP.Ship: meta = new SectorObject_Ship_Meta(); break;
                    default: return null;
                }
                meta.ParentMemoryBlock = ParentMemoryBlock;
                meta.pThis = pMeta;
                meta.ReloadFromMemory();
                return meta;
            }
        }
        public MemoryObjectPointer<SectorObject> pParent;
        public int Unknown_7;
        public int Unknown_8;
        public override Vector3_32 PositionStrafeDelta { get; set; }
        public int Unknown_9;
        public MemoryObjectPointer<RenderObject> pRenderObject;
        public int Unknown_10;
        public int Unknown_11;
        public int _RelatedToEvents_1;
        public int _RelatedToEvents_2;
        public int Unknown_12;
        public int Unknown_13;
        public DynamicValue DynamicValue;
        public byte Unknown_14_0;
        public byte Unknown_14_1;
        public byte Unknown_14_2;
        public override int ScriptInstanceID { get; set; }
        public override int ModelCollectionID { get; set; }
        public int Unknown_16;
        public int Mass;
        public int Unknown_18;
        public int AbsTime;
        public int pFirstUnknown;
        public int NULL_2;
        public int pLastUnknown;
        public int Unknown_22;
        public int Unknown_23;
        public override Vector3_32 CopyPosition { get; set; }
        public int Unknown_24;
        public Vector3_32 EulerRotationCopy2;
        public Vector3_32 LocalEulerRotationDeltaCopy;
        public int Speed_Copy;
        public int Hull;
        public int Unknown_25;
        public int Unknown_26;
        public int Unknown_27;
        public int Unknown_28;
        public int Unknown_29;
        public int Unknown_30;
        public int Unknown_31;
        public int Unknown_32;
        public int Unknown_33;
        public int Unknown_34;
        public int Unknown_35;
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject Next => pNext.obj.IsValid ? pNext.obj : null;
        public override XCommonLib.RAM.Bases.Sector.SectorObject Previous => pPrevious.obj.IsValid ? pPrevious.obj : null;
        public override MemoryString DefaultName => pDefaultName.obj;
        public override XCommonLib.RAM.Bases.B3D.RenderObject RenderObject => pRenderObject.obj;
        #endregion

        public override bool IsValid =>
            pNext.PointedAddress != IntPtr.Zero &&
            pPrevious.PointedAddress != IntPtr.Zero;

        public override void WriteSafeToMemory()
        {
            var collection = new MemoryObjectConverter();
            collection.Append(Speed);
            collection.Append(DesiredSpeed);
            collection.Append(EulerRotationCopy);
            collection.Append(LocalEulerRotationDelta);
            collection.Append(LocalAutopilotRotationDeltaTarget);
            collection.Append(RaceID);
            collection.Append(Unknown_4);
            collection.Append(InteractionFlags);
            collection.Append(Unknown_5);
            collection.Append(base.ObjectType);
            collection.Append(Unknown_6);
            ParentMemoryBlock.WriteBytes(pThis + 0x10, collection.GetBytes());
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            MemoryObjectConverter collection = new MemoryObjectConverter();

            collection.Append(pNext.PointedAddress);
            collection.Append(pPrevious.PointedAddress);
            collection.Append(ID);
            collection.Append(pDefaultName);
            collection.Append(Speed);
            collection.Append(DesiredSpeed);
            collection.Append(EulerRotationCopy);
            collection.Append(LocalEulerRotationDelta);
            collection.Append(LocalAutopilotRotationDeltaTarget);
            collection.Append(RaceID);
            collection.Append(Unknown_4);
            collection.Append(InteractionFlags);
            collection.Append(Unknown_5);
            collection.Append(ObjectType);
            collection.Append(Unknown_6);
            collection.Append(pMeta);
            collection.Append(pParent);
            collection.Append(Unknown_7);
            collection.Append(Unknown_8);
            collection.Append(PositionStrafeDelta);
            collection.Append(Unknown_9);
            collection.Append(pRenderObject);
            collection.Append(Unknown_10);
            collection.Append(Unknown_11);
            collection.Append(_RelatedToEvents_1);
            collection.Append(_RelatedToEvents_2);
            collection.Append(Unknown_12);
            collection.Append(Unknown_13);
            collection.Append(DynamicValue);
            collection.Append(Unknown_14_0);
            collection.Append(Unknown_14_1);
            collection.Append(Unknown_14_2);
            collection.Append(ScriptInstanceID);
            collection.Append(ModelCollectionID);
            collection.Append(Unknown_16);
            collection.Append(Mass);
            collection.Append(Unknown_18);
            collection.Append(AbsTime);
            collection.Append(pFirstUnknown);
            collection.Append(NULL_2);
            collection.Append(pLastUnknown);
            collection.Append(Unknown_22);
            collection.Append(Unknown_23);
            collection.Append(CopyPosition);
            collection.Append(Unknown_24);
            collection.Append(EulerRotationCopy2);
            collection.Append(LocalEulerRotationDeltaCopy);
            collection.Append(Speed_Copy);
            collection.Append(Hull);
            collection.Append(Unknown_25);
            collection.Append(Unknown_26);
            collection.Append(Unknown_27);
            collection.Append(Unknown_28);
            collection.Append(Unknown_29);
            collection.Append(Unknown_30);
            collection.Append(Unknown_31);
            collection.Append(Unknown_32);
            collection.Append(Unknown_33);
            collection.Append(Unknown_34);
            collection.Append(Unknown_35);

            return collection.GetBytes();
        }
        public override int ByteSize => 304;
        protected override SetDataResult SetDataFromMemoryObjectConverter(MemoryObjectConverter objectByteList)
        {
            pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            pPrevious = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            ID = objectByteList.PopInt();
            pDefaultName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            Speed = objectByteList.PopInt();
            DesiredSpeed = objectByteList.PopInt();
            EulerRotationCopy = objectByteList.PopIBinaryObject<Vector3_32>();
            LocalEulerRotationDelta = objectByteList.PopIBinaryObject<Vector3_32>();
            LocalAutopilotRotationDeltaTarget = objectByteList.PopIBinaryObject<Vector3_32>();
            RaceID = objectByteList.PopUShort();
            Unknown_4 = objectByteList.PopUShort();
            InteractionFlags = objectByteList.PopIMemoryObject<BitField>();
            Unknown_5 = objectByteList.PopInt();
            ObjectType = objectByteList.PopIMemoryObject<SectorObjectType>();
            Unknown_6 = objectByteList.PopInt();
            pMeta = objectByteList.PopIntPtr();
            pParent = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_7 = objectByteList.PopInt();
            Unknown_8 = objectByteList.PopInt();
            PositionStrafeDelta = objectByteList.PopIBinaryObject<Vector3_32>();
            Unknown_9 = objectByteList.PopInt();
            pRenderObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<B3D.RenderObject>>();
            Unknown_10 = objectByteList.PopInt();
            Unknown_11 = objectByteList.PopInt();
            _RelatedToEvents_1 = objectByteList.PopInt();
            _RelatedToEvents_2 = objectByteList.PopInt();
            Unknown_12 = objectByteList.PopInt();
            Unknown_13 = objectByteList.PopInt();
            DynamicValue = objectByteList.PopIMemoryObject<DynamicValue>();
            Unknown_14_0 = objectByteList.PopByte();
            Unknown_14_1 = objectByteList.PopByte();
            Unknown_14_2 = objectByteList.PopByte();
            ScriptInstanceID = objectByteList.PopInt();
            ModelCollectionID = objectByteList.PopInt();
            Unknown_16 = objectByteList.PopInt();
            Mass = objectByteList.PopInt();
            Unknown_18 = objectByteList.PopInt();
            AbsTime = objectByteList.PopInt();
            pFirstUnknown = objectByteList.PopInt();
            NULL_2 = objectByteList.PopInt();
            pLastUnknown = objectByteList.PopInt();
            Unknown_22 = objectByteList.PopInt();
            Unknown_23 = objectByteList.PopInt();
            CopyPosition = objectByteList.PopIBinaryObject<Vector3_32>();
            Unknown_24 = objectByteList.PopInt();
            EulerRotationCopy2 = objectByteList.PopIBinaryObject<Vector3_32>();
            LocalEulerRotationDeltaCopy = objectByteList.PopIBinaryObject<Vector3_32>();
            Speed_Copy = objectByteList.PopInt();
            Hull = objectByteList.PopInt();
            Unknown_25 = objectByteList.PopInt();
            Unknown_26 = objectByteList.PopInt();
            Unknown_27 = objectByteList.PopInt();
            Unknown_28 = objectByteList.PopInt();
            Unknown_29 = objectByteList.PopInt();
            Unknown_30 = objectByteList.PopInt();
            Unknown_31 = objectByteList.PopInt();
            Unknown_32 = objectByteList.PopInt();
            Unknown_33 = objectByteList.PopInt();
            Unknown_34 = objectByteList.PopInt();
            Unknown_35 = objectByteList.PopInt();

            return SetDataResult.Success;
        }
        #endregion
    }
}
