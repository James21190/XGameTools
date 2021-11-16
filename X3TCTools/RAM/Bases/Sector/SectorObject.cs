using CommonToolLib.Memory;
using CommonToolLib.Vector;
using System;
using System.Collections.Generic;
using X3Tools.RAM.Bases.B3D;
using X3Tools.RAM.Bases.Sector.Meta;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3Tools.RAM.Bases.Sector
{
    public partial class SectorObject : MemoryObject, IComparable, INumericIDObject
    {
        public bool IsValid => (pNext.address != IntPtr.Zero && pPrevious.address != IntPtr.Zero && (int)ObjectType.MainTypeEnum < MAIN_TYPE_COUNT);

        #region Memory Fields
        public MemoryObjectPointer<SectorObject> pNext;
        public MemoryObjectPointer<SectorObject> pPrevious;
        public int ID;
        public MemoryObjectPointer<MemoryString> pDefaultName;
        public int Speed;
        public int TargetSpeed;
        public Vector3_32 EulerRotationCopy;
        public Vector3_32 LocalEulerRotationDelta;
        public Vector3_32 LocalAutopilotRotationDeltaTarget;
        public GameHook.RaceID RaceID;
        public int Unknown_4;
        public int Unknown_5;
        public SectorObjectType ObjectType;
        public int Unknown_6;
        public IntPtr pMeta;
        public MemoryObjectPointer<SectorObject> pParent;
        public int Unknown_7;
        public int Unknown_8;
        public Vector3_32 PositionStrafeDelta;
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
        public int ScriptInstanceID;
        public int ModelCollectionID;
        public int Unknown_16;
        public int Mass;
        public int Unknown_18;
        public int AbsTime;
        public int pFirstUnknown;
        public int NULL_2;
        public int pLastUnknown;
        public int Unknown_22;
        public int Unknown_23;
        public Vector3_32 Position_Copy;
        public int Unknown_24;
        public Vector3_32 EulerRotationCopy2;
        public Vector3_32 LocalRotationDeltaCopy;
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

        public ScriptInstance ScriptInstance
        {
            get
            {
                try
                {
                    return GameHook.storyBase.GetScriptingObject(ScriptInstanceID);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public decimal[] MetricPosition => new decimal[] { (decimal)Position_Copy.X / 500000, (decimal)Position_Copy.Y / 500000, (decimal)Position_Copy.Z / 500000 };


        public SectorObject()
        {
            pNext = new MemoryObjectPointer<SectorObject>();
            pPrevious = new MemoryObjectPointer<SectorObject>();
            pParent = new MemoryObjectPointer<SectorObject>();
            ObjectType = new SectorObjectType();
            DynamicValue = new DynamicValue();
            pRenderObject = new MemoryObjectPointer<RenderObject>();
        }

        /// <summary>
        /// Returns the meta of the object.
        /// </summary>
        /// <returns></returns>
        public ISectorObjectMeta GetMeta()
        {
            ISectorObjectMeta meta;
            switch (ObjectType.MainTypeEnum)
            {
                case Main_Type.Ship: meta = new SectorObject_Ship_Meta(); break;
                case Main_Type.Sector: meta = new SectorObject_Sector_Meta(); break;
                case Main_Type.Gate: meta = new SectorObject_Gate_Meta(); break;
                case Main_Type.Dock:
                case Main_Type.Factory: meta = new SectorObject_Station_Meta(); break;
                default: return null;
            }
            meta.SetLocation(hProcess, pMeta);
            meta.ReloadFromMemory();
            return meta;
        }

        #region Children
        /// <summary>
        /// Get all children with a given main type.
        /// </summary>
        /// <param name="main_Type"></param>
        /// <returns></returns>
        public SectorObject[] GetAllChildrenWithType(Main_Type main_Type)
        {
            ISectorObjectMeta meta = GetMeta();
            if (meta != null)
            {
                return meta.GetChildren(main_Type);
            }
            else
            {
                return Array.Empty<SectorObject>();
            }
        }

        public SectorObject[] GetAllChildrenWithType(int main_Type)
        {
            return GetAllChildrenWithType((Main_Type)main_Type);
        }

        public SectorObject[] GetAllChildren(bool TraverseDown)
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();
            for (int main_Type = 0; main_Type < MAIN_TYPE_COUNT; main_Type++)
            {
                foreach (SectorObject child in GetAllChildrenWithType(main_Type))
                {
                    sectorObjects.Add(child);
                    if (TraverseDown)
                    {
                        sectorObjects.AddRange(child.GetAllChildren(true));
                    }
                }
            }

            return sectorObjects.ToArray();
        }

        #endregion

        public RenderObject GetData()
        {
            RenderObject data = new RenderObject();
            data.SetLocation(hProcess, pRenderObject.address);
            return data;


        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();

            collection.Append(pNext.address);
            collection.Append(pPrevious.address);
            collection.Append(ID);
            collection.Append(pDefaultName);
            collection.Append(Speed);
            collection.Append(TargetSpeed);
            collection.Append(EulerRotationCopy);
            collection.Append(LocalEulerRotationDelta);
            collection.Append(LocalAutopilotRotationDeltaTarget);
            collection.Append((int)RaceID);
            collection.Append(Unknown_4);
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
            collection.Append(Position_Copy);
            collection.Append(Unknown_24);
            collection.Append(EulerRotationCopy2);
            collection.Append(LocalRotationDeltaCopy);
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

        int INumericIDObject.ID => ID;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            pNext = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            pPrevious = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            ID = objectByteList.PopInt();
            pDefaultName = objectByteList.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            Speed = objectByteList.PopInt();
            TargetSpeed = objectByteList.PopInt();
            EulerRotationCopy = objectByteList.PopIMemoryObject<Vector3_32>();
            LocalEulerRotationDelta = objectByteList.PopIMemoryObject<Vector3_32>();
            LocalAutopilotRotationDeltaTarget = objectByteList.PopIMemoryObject<Vector3_32>();
            RaceID = (GameHook.RaceID)objectByteList.PopInt();
            Unknown_4 = objectByteList.PopInt();
            Unknown_5 = objectByteList.PopInt();
            ObjectType = objectByteList.PopIMemoryObject<SectorObjectType>();
            Unknown_6 = objectByteList.PopInt();
            pMeta = objectByteList.PopIntPtr();
            pParent = objectByteList.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            Unknown_7 = objectByteList.PopInt();
            Unknown_8 = objectByteList.PopInt();
            PositionStrafeDelta = objectByteList.PopIMemoryObject<Vector3_32>();
            Unknown_9 = objectByteList.PopInt();
            pRenderObject = objectByteList.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
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
            Position_Copy = objectByteList.PopIMemoryObject<Vector3_32>();
            Unknown_24 = objectByteList.PopInt();
            EulerRotationCopy2 = objectByteList.PopIMemoryObject<Vector3_32>();
            LocalRotationDeltaCopy = objectByteList.PopIMemoryObject<Vector3_32>();
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
        }
        #endregion

        /// <summary>
        /// Save all non pointer variables to memory.
        /// </summary>
        public void Save()
        {
            MemoryControl.Write(hProcess, pThis + 16, Speed);
            MemoryControl.Write(hProcess, pThis + 20, TargetSpeed);
            MemoryControl.Write(hProcess, pThis + 24, LocalEulerRotationDelta);
            MemoryControl.Write(hProcess, pThis + 96, PositionStrafeDelta);
            MemoryControl.Write(hProcess, pThis + 236, Hull);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address);
            pPrevious.SetLocation(hProcess, address + 0x4);
            pParent.SetLocation(hProcess, address + 0x54);
            DynamicValue.SetLocation(hProcess, address);
            pRenderObject.SetLocation(hProcess, address + 0x70);

        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is SectorObject))
            {
                throw new Exception("Type missmatch");
            }

            SectorObject type = (SectorObject)obj;

            if (ObjectType.MainTypeEnum > type.ObjectType.MainTypeEnum)
            {
                return -1;
            }

            if (ObjectType.MainTypeEnum < type.ObjectType.MainTypeEnum)
            {
                return 1;
            }

            if (ObjectType.SubType > type.ObjectType.SubType)
            {
                return -1;
            }

            if (ObjectType.SubType < type.ObjectType.SubType)
            {
                return 1;
            }

            if (RaceID > type.RaceID)
            {
                return -1;
            }

            if (RaceID < type.RaceID)
            {
                return 1;
            }

            if (ID > type.ID)
            {
                return -1;
            }

            if (ID < type.ID)
            {
                return 1;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is SectorObject))
            {
                throw new Exception("Type missmatch");
            }

            SectorObject sectorObject = (SectorObject)obj;
            return ID == sectorObject.ID;
        }

        public static bool operator ==(SectorObject a, SectorObject b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }
        public static bool operator !=(SectorObject a, SectorObject b)
        {
            return !(a == b);
        }
    }
}
