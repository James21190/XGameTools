using Common.Memory;
using Common.Vector;
using System;
using System.Collections.Generic;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Sector_Objects.Meta;

namespace X3TCTools.Sector_Objects
{
    public partial class SectorObject : MemoryObject, IComparable
    {
        public bool IsValid => (pNext.address != IntPtr.Zero && pPrevious.address != IntPtr.Zero && (int)MainType < MAIN_TYPE_COUNT);

        #region Memory Fields
        public MemoryObjectPointer<SectorObject> pNext;
        public MemoryObjectPointer<SectorObject> pPrevious;
        public int ObjectID;
        public IntPtr pDefaultName;
        public int Speed;
        public int TargetSpeed;
        public Vector3 EulerRotationCopy;
        public Vector3 LocalEulerRotationDelta;
        public Vector3 LocalAutopilotRotationDeltaTarget;
        public GameHook.RaceID RaceID;
        public int Unknown_4;
        public int Unknown_5;
        public Main_Type MainType;
        public short SubType;
        public int Unknown_6;
        public IntPtr pMeta;
        public MemoryObjectPointer<SectorObject> pParent;
        public int Unknown_7;
        public int Unknown_8;
        public Vector3 PositionStrafeDelta;
        public int Unknown_9;
        public MemoryObjectPointer<RenderObject> pData;
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
        public int EventObjectID;
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
        public Vector3 Position_Copy;
        public int Unknown_24;
        public Vector3 EulerRotationCopy2;
        public Vector3 LocalRotationDeltaCopy;
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

        public EventObject EventObject
        {
            get
            {
                try
                {
                    return GameHook.storyBase.GetEventObject(EventObjectID);
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
            DynamicValue = new DynamicValue();
            pData = new MemoryObjectPointer<RenderObject>();
        }

        /// <summary>
        /// Returns the meta of the object.
        /// </summary>
        /// <returns></returns>
        public ISectorObjectMeta GetMeta()
        {
            ISectorObjectMeta meta;
            switch (MainType)
            {
                case Main_Type.Ship: meta = new SectorObject_Ship_Meta(); break;
                case Main_Type.Sector: meta = new SectorObject_Sector_Meta(); break;
                case Main_Type.Gate: meta = new SectorObject_Gate_Meta(); break;
                case Main_Type.Dock:
                case Main_Type.Factory: meta = new SectorObject_Station_Meta(); break;
                default: return null;
            }
            meta.SetLocation(m_hProcess, pMeta);
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
            return GetAllChildrenWithType((int)main_Type);
        }

        public SectorObject[] GetAllChildrenWithType(int main_Type)
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();
            ISectorObjectMeta meta = GetMeta();
            if (meta == null)
            {
                return sectorObjects.ToArray();
            }

            SectorObject so = meta.GetFirstChild((SectorObject.Main_Type)main_Type);
            if (so != null)
            {
                while (so.IsValid)
                {
                    sectorObjects.Add(so);
                    so = so.pNext.obj;
                }
            }

            return sectorObjects.ToArray();
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
            data.SetLocation(m_hProcess, pData.address);
            return data;


        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();

            collection.Append(pNext.address);
            collection.Append(pPrevious.address);
            collection.Append(ObjectID);
            collection.Append(pDefaultName);
            collection.Append(Speed);
            collection.Append(TargetSpeed);
            collection.Append(EulerRotationCopy);
            collection.Append(LocalEulerRotationDelta);
            collection.Append(LocalAutopilotRotationDeltaTarget);
            collection.Append((int)RaceID);
            collection.Append(Unknown_4);
            collection.Append(Unknown_5);
            collection.Append((short)MainType);
            collection.Append(SubType);
            collection.Append(Unknown_6);
            collection.Append(pMeta);
            collection.Append(pParent);
            collection.Append(Unknown_7);
            collection.Append(Unknown_8);
            collection.Append(PositionStrafeDelta);
            collection.Append(Unknown_9);
            collection.Append(pData);
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
            collection.Append(EventObjectID);
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

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);

            collection.PopFirst(ref pNext);
            collection.PopFirst(ref pPrevious);
            int tempint = 0;
            short tempshort = 0;
            collection.PopFirst(ref ObjectID);
            collection.PopFirst(ref pDefaultName);
            collection.PopFirst(ref Speed);
            collection.PopFirst(ref TargetSpeed);
            collection.PopFirst(ref EulerRotationCopy);
            collection.PopFirst(ref LocalEulerRotationDelta);
            collection.PopFirst(ref LocalAutopilotRotationDeltaTarget);
            collection.PopFirst(ref tempint);
            RaceID = (GameHook.RaceID)tempint;
            collection.PopFirst(ref Unknown_4);
            collection.PopFirst(ref Unknown_5);
            collection.PopFirst(ref tempshort);
            MainType = (Main_Type)tempshort;
            collection.PopFirst(ref SubType);
            collection.PopFirst(ref Unknown_6);
            collection.PopFirst(ref pMeta);
            collection.PopFirst(ref pParent);
            collection.PopFirst(ref Unknown_7);
            collection.PopFirst(ref Unknown_8);
            collection.PopFirst(ref PositionStrafeDelta);
            collection.PopFirst(ref Unknown_9);
            collection.PopFirst(ref pData);
            collection.PopFirst(ref Unknown_10);
            collection.PopFirst(ref Unknown_11);
            collection.PopFirst(ref _RelatedToEvents_1);
            collection.PopFirst(ref _RelatedToEvents_2);
            collection.PopFirst(ref Unknown_12);
            collection.PopFirst(ref Unknown_13);
            collection.PopFirst(ref DynamicValue);
            collection.PopFirst(ref Unknown_14_0);
            collection.PopFirst(ref Unknown_14_1);
            collection.PopFirst(ref Unknown_14_2);
            collection.PopFirst(ref EventObjectID);
            collection.PopFirst(ref ModelCollectionID);
            collection.PopFirst(ref Unknown_16);
            collection.PopFirst(ref Mass);
            collection.PopFirst(ref Unknown_18);
            collection.PopFirst(ref AbsTime);
            collection.PopFirst(ref pFirstUnknown);
            collection.PopFirst(ref NULL_2);
            collection.PopFirst(ref pLastUnknown);
            collection.PopFirst(ref Unknown_22);
            collection.PopFirst(ref Unknown_23);
            collection.PopFirst(ref Position_Copy);
            collection.PopFirst(ref Unknown_24);
            collection.PopFirst(ref EulerRotationCopy2);
            collection.PopFirst(ref LocalRotationDeltaCopy);
            collection.PopFirst(ref Speed_Copy);
            collection.PopFirst(ref Hull);
            collection.PopFirst(ref Unknown_25);
            collection.PopFirst(ref Unknown_26);
            collection.PopFirst(ref Unknown_27);
            collection.PopFirst(ref Unknown_28);
            collection.PopFirst(ref Unknown_29);
            collection.PopFirst(ref Unknown_30);
            collection.PopFirst(ref Unknown_31);
            collection.PopFirst(ref Unknown_32);
            collection.PopFirst(ref Unknown_33);
            collection.PopFirst(ref Unknown_34);
            collection.PopFirst(ref Unknown_35);
        }
        #endregion

        /// <summary>
        /// Save all non pointer variables to memory.
        /// </summary>
        public void Save()
        {
            MemoryControl.Write(m_hProcess, pThis + 16, Speed);
            MemoryControl.Write(m_hProcess, pThis + 20, TargetSpeed);
            MemoryControl.Write(m_hProcess, pThis + 24, LocalEulerRotationDelta);
            MemoryControl.Write(m_hProcess, pThis + 96, PositionStrafeDelta);
            MemoryControl.Write(m_hProcess, pThis + 236, Hull);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address);
            pPrevious.SetLocation(hProcess, address + 0x4);
            pParent.SetLocation(hProcess, address + 0x54);
            DynamicValue.SetLocation(hProcess, address);
            pData.SetLocation(hProcess, address + 0x70);

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

            if (MainType > type.MainType)
            {
                return -1;
            }

            if (MainType < type.MainType)
            {
                return 1;
            }

            if (SubType > type.SubType)
            {
                return -1;
            }

            if (SubType < type.SubType)
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

            if (ObjectID > type.ObjectID)
            {
                return -1;
            }

            if (ObjectID < type.ObjectID)
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
            return ObjectID == sectorObject.ObjectID;
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
