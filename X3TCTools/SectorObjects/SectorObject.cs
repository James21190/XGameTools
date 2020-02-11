using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;
using Common.Vector;
using X3TCTools.SectorObjects.Meta;

namespace X3TCTools.SectorObjects
{
    public partial class SectorObject : MemoryObject
    {        public bool IsValid
        {
            get
            {
                return (pNext.address != IntPtr.Zero && pPrevious.address != IntPtr.Zero);
            }
        }

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
        public IntPtr pData;
        public int Unknown_10;
        public int Unknown_11;
        public int _RelatedToEvents_1;
        public int _RelatedToEvents_2;
        public int Unknown_12;
        public int Unknown_13;
        public Bases.DynamicValue DynamicValue;
        public byte Unknown_14_0;
        public byte Unknown_14_1;
        public byte Unknown_14_2;
        public int EventObjectID;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public int AbsTime;
        public int Unknown_19;
        public int Unknown_20;
        public int Unknown_21;
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
        public const int ByteSize = 304;

        public SectorObject()
        {
            pNext = new MemoryObjectPointer<SectorObject>();
            pPrevious = new MemoryObjectPointer<SectorObject>();
            pParent = new MemoryObjectPointer<SectorObject>();
            DynamicValue = new Bases.DynamicValue();
        }

        /// <summary>
        /// Returns the meta of the object.
        /// </summary>
        /// <returns></returns>
        public ISectorObjectMeta GetMeta()
        {
            ISectorObjectMeta meta;
            switch(MainType)
            {
                default: return null;
            }
            meta.SetLocation(m_hProcess, pMeta);
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
            //var list = GetMeta().GetChildrenList();
            //var entry = list[main_Type].pFirst;
            //while (entry.address != IntPtr.Zero)
            //{
            //    var next = entry.obj;
            //    sectorObjects.Add(next);
            //    entry = next.pNext;
            //}

            return sectorObjects.ToArray();
        }

        public SectorObject[] GetAllChildren(bool TraverseDown)
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();
            for (int main_Type = 0; main_Type < MAIN_TYPE_COUNT; main_Type++) 
            {
                foreach(var child in GetAllChildrenWithType(main_Type))
                {
                    sectorObjects.Add(child);
                    if (TraverseDown)
                        sectorObjects.AddRange(child.GetAllChildren(true));
                }
            }

            return sectorObjects.ToArray();
        }

        #endregion

        public SectorObjectData GetData()
        {
            return new SectorObjectData(m_hProcess, pData);
            
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();

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
            collection.Append(Unknown_15);
            collection.Append(Unknown_16);
            collection.Append(Unknown_17);
            collection.Append(Unknown_18);
            collection.Append(AbsTime);
            collection.Append(Unknown_19);
            collection.Append(Unknown_20);
            collection.Append(Unknown_21);
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

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);

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
            collection.PopFirst(ref Unknown_15);
            collection.PopFirst(ref Unknown_16);
            collection.PopFirst(ref Unknown_17);
            collection.PopFirst(ref Unknown_18);
            collection.PopFirst(ref AbsTime);
            collection.PopFirst(ref Unknown_19);
            collection.PopFirst(ref Unknown_20);
            collection.PopFirst(ref Unknown_21);
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
            pNext.SetLocation(hProcess,address);
            pPrevious.SetLocation(hProcess, address);
            pParent.SetLocation(hProcess, address);
            DynamicValue.SetLocation(hProcess, address);
        }

    }
}
