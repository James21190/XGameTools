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
    public partial class SectorObject : IMemoryObject
    {
        public struct ListTop : IMemoryObject
        {
            public IntPtr pFirst;
            public int pDefault;
            public IntPtr pLast;

            public byte[] GetBytes()
            {
                var collection = new ObjectByteList();

                collection.Append(pFirst);
                collection.Append(pDefault);
                collection.Append(pLast);

                return collection.GetBytes();
            }

            public int GetByteSize()
            {
                return 12;
            }

            public void SetData(byte[] Memory)
            {
                var collection = new ObjectByteList();
                collection.SetData(Memory);

                collection.PopFirst(ref pFirst);
                collection.PopFirst(ref pDefault);
                collection.PopFirst(ref pLast);
            }
        }
        

        private GameHook m_GameHook;

        public IntPtr pThis;

        public IntPtr pNext;
        public IntPtr pPrevious;
        public int ObjectID;
        public IntPtr pDefaultName;
        public int Speed;
        public int TargetSpeed;
        public Vector3 EulerRotationCopy;
        public Vector3 LocalEulerRotationDelta;
        public int Unknown_2;
        public int Unknown_3;
        public int Unknown_4;
        public GameHook.RaceID RaceID;
        public int Unknown_6;
        public int Unknown_7;
        public Main_Type MainType;
        public short SubType;
        public int Unknown_9;
        public IntPtr pMeta;
        public IntPtr pParent;
        public int Unknown_11;
        public int Unknown_12;
        public Vector3 PositionStrafeDelta;
        public int Unknown_16;
        public IntPtr pData;
        public int Unknown_18;
        public int Unknown_19;
        public int Unknown_20;
        public int Unknown_21;
        public int Unknown_22;
        public int Unknown_23;
        public int Unknown_24;
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
        public int Unknown_36;
        public Vector3 Position_Copy;
        public int Unknown_40;
        public int Unknown_41;
        public int Unknown_42;
        public int Unknown_43;
        public int Unknown_44;
        public int Unknown_45;
        public int Unknown_46;
        public int Speed_Copy;
        public int Hull;
        public int Unknown_49;
        public int Unknown_50;
        public int Unknown_51;
        public int Unknown_52;
        public int Unknown_53;
        public int Unknown_54;
        public int Unknown_55;
        public int Unknown_56;
        public int Unknown_57;
        public int Unknown_58;
        public int Unknown_59;

        public const int ByteSize = 304;

        public SectorObject(GameHook gameHook)
        {
            m_GameHook = gameHook;
        }

        public SectorObject(GameHook gameHook, IntPtr address)
        {
            m_GameHook = gameHook;
            pThis = address;
            SetData(MemoryControl.Read(m_GameHook.hProcess, address, ByteSize));
        }

        public string GetSubTypeAsString()
        {
            switch (MainType)
            {
                case Main_Type.Projectile: // 0
                case Main_Type.Weapon: // 8
                    return ((Weapon_Sub_Type)SubType).ToString();
                case Main_Type.Dock: // 5
                    return ((Dock_Sub_Type)SubType).ToString();
                case Main_Type.Factory: // 6
                    return ((Factory_Sub_Type)SubType).ToString();
                case Main_Type.Ship: // 7
                    return ((Ship_Sub_Type)SubType).ToString();
                case Main_Type.Shield: // 9
                    return ((Shield_Sub_Type)SubType).ToString();
                case Main_Type.Missile: return ((Missile_Sub_Type)SubType).ToString(); // 10
                case Main_Type.Gate: // 9
                    return ((Gate_Sub_Type)SubType).ToString();
                default:
                    return SubType.ToString();
            }
        }

        public ISectorObjectMeta GetMeta()
        {
            switch(MainType)
            {
                case Main_Type.Sector: return new SectorMeta(m_GameHook, pMeta); // 1
                case Main_Type.Dock: return new DockMeta(m_GameHook, pMeta); // 5
                case Main_Type.Ship: return new ShipMeta(m_GameHook, pMeta); // 7
                case Main_Type.Weapon: return new ShipGunMeta(m_GameHook, pMeta); // 8
                case Main_Type.Shield: return new ShieldMeta(m_GameHook, pMeta); // 9
                default: return null;
            }
        }

        /// <summary>
        /// Get all children with a given main type.
        /// </summary>
        /// <param name="main_Type"></param>
        /// <returns></returns>
        public SectorObject[] GetAllChildrenWithType(Main_Type main_Type)
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();
            SectorObject next;
            if (m_GameHook.SectorObjectManager.SectorObjectExists(GetMeta().GetChildrenList()[(int)main_Type].pFirst, out next)) {
                sectorObjects.Add(next);
                while (m_GameHook.SectorObjectManager.SectorObjectExists(next.pNext, out next))
                {
                    sectorObjects.Add(next);
                }
            }

            return sectorObjects.ToArray();
        }

        public SectorObject[] GetAllChildren(bool TraverseDown)
        {
            List<SectorObject> sectorObjects = new List<SectorObject>();
            SectorObject next;
            for (int main_Type = 0; main_Type < MAIN_TYPE_COUNT; main_Type++) 
            {
                var meta = GetMeta();
                if (meta != null)
                {
                    var childlist = meta.GetChildrenList();
                    if(childlist != null)
                        if (m_GameHook.SectorObjectManager.SectorObjectExists(childlist[main_Type].pFirst, out next))
                        {
                            sectorObjects.Add(next);
                            if (TraverseDown)
                                sectorObjects.AddRange(next.GetAllChildren(true));
                            while (m_GameHook.SectorObjectManager.SectorObjectExists(next.pNext, out next))
                            {
                                sectorObjects.Add(next);
                                if (TraverseDown)
                                    sectorObjects.AddRange(next.GetAllChildren(true));
                            }
                        }
                }
            }

            return sectorObjects.ToArray();
        }

        public SectorObjectData GetData()
        {
            return new SectorObjectData(m_GameHook, pData);
            
        }

        #region IMemoryObject
        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(pNext);
            collection.Append(pPrevious);
            collection.Append(ObjectID);
            collection.Append(pDefaultName);
            collection.Append(Speed);
            collection.Append(TargetSpeed);
            collection.Append(EulerRotationCopy);
            collection.Append(LocalEulerRotationDelta);
            collection.Append(Unknown_2);
            collection.Append(Unknown_3);
            collection.Append(Unknown_4);
            collection.Append((int)RaceID);
            collection.Append(Unknown_6);
            collection.Append(Unknown_7);
            collection.Append((short)MainType);
            collection.Append(SubType);
            collection.Append(Unknown_9);
            collection.Append(pMeta);
            collection.Append(pParent);
            collection.Append(Unknown_11);
            collection.Append(Unknown_12);
            collection.Append(PositionStrafeDelta);
            collection.Append(Unknown_16);
            collection.Append(pData);
            collection.Append(Unknown_18);
            collection.Append(Unknown_19);
            collection.Append(Unknown_20);
            collection.Append(Unknown_21);
            collection.Append(Unknown_22);
            collection.Append(Unknown_23);
            collection.Append(Unknown_24);
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
            collection.Append(Unknown_36);
            collection.Append(Position_Copy);
            collection.Append(Unknown_40);
            collection.Append(Unknown_41);
            collection.Append(Unknown_42);
            collection.Append(Unknown_43);
            collection.Append(Unknown_44);
            collection.Append(Unknown_45);
            collection.Append(Unknown_46);
            collection.Append(Speed_Copy);
            collection.Append(Hull);
            collection.Append(Unknown_49);
            collection.Append(Unknown_50);
            collection.Append(Unknown_51);
            collection.Append(Unknown_52);
            collection.Append(Unknown_53);
            collection.Append(Unknown_54);
            collection.Append(Unknown_55);
            collection.Append(Unknown_56);
            collection.Append(Unknown_57);
            collection.Append(Unknown_58);
            collection.Append(Unknown_59);

            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);
            
            collection.PopFirst(ref pNext);
            collection.PopFirst(ref pPrevious);

            if (pNext == IntPtr.Zero || pPrevious == IntPtr.Zero)
                throw new Exception("Data provided is not a valid SectorObject.");

            int tempint = 0;
            short tempshort = 0;

            collection.PopFirst(ref ObjectID);
            collection.PopFirst(ref pDefaultName);
            collection.PopFirst(ref Speed);
            collection.PopFirst(ref TargetSpeed);
            collection.PopFirst(ref EulerRotationCopy);
            collection.PopFirst(ref LocalEulerRotationDelta);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref Unknown_4);
            collection.PopFirst(ref tempint);
            RaceID = (GameHook.RaceID)tempint;
            collection.PopFirst(ref Unknown_6);
            collection.PopFirst(ref Unknown_7);
            collection.PopFirst(ref tempshort);
            MainType = (Main_Type)tempshort;
            collection.PopFirst(ref SubType);
            collection.PopFirst(ref Unknown_9);
            collection.PopFirst(ref pMeta);
            collection.PopFirst(ref pParent);
            collection.PopFirst(ref Unknown_11);
            collection.PopFirst(ref Unknown_12);
            collection.PopFirst(ref PositionStrafeDelta);
            collection.PopFirst(ref Unknown_16);
            collection.PopFirst(ref pData);
            collection.PopFirst(ref Unknown_18);
            collection.PopFirst(ref Unknown_19);
            collection.PopFirst(ref Unknown_20);
            collection.PopFirst(ref Unknown_21);
            collection.PopFirst(ref Unknown_22);
            collection.PopFirst(ref Unknown_23);
            collection.PopFirst(ref Unknown_24);
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
            collection.PopFirst(ref Unknown_36);
            collection.PopFirst(ref Position_Copy);
            collection.PopFirst(ref Unknown_40);
            collection.PopFirst(ref Unknown_41);
            collection.PopFirst(ref Unknown_42);
            collection.PopFirst(ref Unknown_43);
            collection.PopFirst(ref Unknown_44);
            collection.PopFirst(ref Unknown_45);
            collection.PopFirst(ref Unknown_46);
            collection.PopFirst(ref Speed_Copy);
            collection.PopFirst(ref Hull);
            collection.PopFirst(ref Unknown_49);
            collection.PopFirst(ref Unknown_50);
            collection.PopFirst(ref Unknown_51);
            collection.PopFirst(ref Unknown_52);
            collection.PopFirst(ref Unknown_53);
            collection.PopFirst(ref Unknown_54);
            collection.PopFirst(ref Unknown_55);
            collection.PopFirst(ref Unknown_56);
            collection.PopFirst(ref Unknown_57);
            collection.PopFirst(ref Unknown_58);
            collection.PopFirst(ref Unknown_59);
        }
        #endregion

        /// <summary>
        /// Save all non pointer variables to memory.
        /// </summary>
        public void Save()
        {
            MemoryControl.Write(m_GameHook.hProcess, pThis + 16, Speed);
            MemoryControl.Write(m_GameHook.hProcess, pThis + 20, TargetSpeed);
            MemoryControl.Write(m_GameHook.hProcess, pThis + 24, LocalEulerRotationDelta);
            MemoryControl.Write(m_GameHook.hProcess, pThis + 96, PositionStrafeDelta);
            MemoryControl.Write(m_GameHook.hProcess, pThis + 236, Hull);
        }

        public string[] GetValuesAsStrings()
        {
            var result = new string[64];
            
            result[0] = "0x" + pNext.ToString("X");
            result[1] = "0x" + pPrevious.ToString("X");
            result[2] = ObjectID.ToString();
            result[3] = "0x" + pDefaultName.ToString("X");
            result[4] = Speed.ToString();
            result[5] = TargetSpeed.ToString();
            result[6] = EulerRotationCopy.ToString();
            result[7] = LocalEulerRotationDelta.ToString();
            result[8] = "0x" + Unknown_2.ToString("X");
            result[9] = "0x" + Unknown_3.ToString("X");
            result[10] = "0x" + Unknown_4.ToString("X");
            result[11] = RaceID.ToString();
            result[12] = "0x" + Unknown_6.ToString("X");
            result[13] = "0x" + Unknown_7.ToString("X");
            result[14] = MainType.ToString();
            result[15] = SubType.ToString();
            result[16] = "0x" + Unknown_9.ToString("X");
            result[17] = "0x" + pMeta.ToString("X");
            result[18] = "0x" + pParent.ToString("X");
            result[19] = "0x" + Unknown_11.ToString("X");
            result[20] = "0x" + Unknown_12.ToString("X");
            result[21] = PositionStrafeDelta.ToString();
            result[22] = "0x" + Unknown_16.ToString("X");
            result[23] = "0x" + pData.ToString("X");
            result[24] = "0x" + Unknown_18.ToString("X");
            result[25] = "0x" + Unknown_19.ToString("X");
            result[26] = "0x" + Unknown_20.ToString("X");
            result[27] = "0x" + Unknown_21.ToString("X");
            result[28] = "0x" + Unknown_22.ToString("X");
            result[29] = "0x" + Unknown_23.ToString("X");
            result[30] = "0x" + Unknown_24.ToString("X");
            result[31] = "0x" + Unknown_25.ToString("X");
            result[32] = "0x" + Unknown_26.ToString("X");
            result[33] = "0x" + Unknown_27.ToString("X");
            result[34] = "0x" + Unknown_28.ToString("X");
            result[35] = "0x" + Unknown_29.ToString("X");
            result[36] = "0x" + Unknown_30.ToString("X");
            result[37] = "0x" + Unknown_31.ToString("X");
            result[38] = "0x" + Unknown_32.ToString("X");
            result[39] = "0x" + Unknown_33.ToString("X");
            result[40] = "0x" + Unknown_34.ToString("X");
            result[41] = "0x" + Unknown_35.ToString("X");
            result[42] = "0x" + Unknown_36.ToString("X");
            result[43] = Position_Copy.ToString();
            result[44] = "0x" + Unknown_40.ToString("X");
            result[45] = "0x" + Unknown_41.ToString("X");
            result[46] = "0x" + Unknown_42.ToString("X");
            result[47] = "0x" + Unknown_43.ToString("X");
            result[48] = "0x" + Unknown_44.ToString("X");
            result[49] = "0x" + Unknown_45.ToString("X");
            result[50] = "0x" + Unknown_46.ToString("X");
            result[51] = Speed_Copy.ToString("X");
            result[52] = Hull.ToString();
            result[53] = "0x" + Unknown_49.ToString("X");
            result[54] = "0x" + Unknown_50.ToString("X");
            result[55] = "0x" + Unknown_51.ToString("X");
            result[56] = "0x" + Unknown_52.ToString("X");
            result[57] = "0x" + Unknown_53.ToString("X");
            result[58] = "0x" + Unknown_54.ToString("X");
            result[59] = "0x" + Unknown_55.ToString("X");
            result[60] = "0x" + Unknown_56.ToString("X");
            result[61] = "0x" + Unknown_57.ToString("X");
            result[62] = "0x" + Unknown_58.ToString("X");
            result[63] = "0x" + Unknown_59.ToString("X");

            return result;
        }
    }
}
