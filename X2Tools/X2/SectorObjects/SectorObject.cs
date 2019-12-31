using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2.SectorObjects.Meta;
using Common.Memory;
using Common.Memory;

namespace X2Tools.X2.SectorObjects
{
    /// <summary>
    /// The main object type within X2 The Threat.
    /// Contains data relating to its type, speed, and copies of its position and rotation.
    /// Contains pointers to additional data structures.
    /// </summary>
    public partial class SectorObject : IMemoryObject
    {
        /// <summary>
        /// The size of this object in bytes
        /// </summary>
        public const int ByteSize = 220;

        #region Private Fields
        private GameHook m_GameHook;      
        #endregion

        #region Public Fields

        /// <summary>
        /// The pointer to this sectorobject in game memory
        /// </summary>
        public readonly IntPtr pThis;

        #region Game memory values
        // All values stored in memory
        public readonly IntPtr Next;
        public readonly IntPtr Previous;
        public int SectorObjectID;
        public readonly IntPtr pDefaultName;
        public int Speed;
        public int TargetSpeed;
        public Common.Vector.Vector3 Rotation;
        public Common.Vector.Vector3 LocalRotationDelta;
        public Common.Vector.Vector3 AutoPilotRotationChange;
        public Race.RaceID RaceID;
        public int Unknown_4;
        public InteractionFlags InteractionFlags;
        public int Unknown_5;
        public readonly Main_Type MainType;
        public readonly int SubType;
        public readonly IntPtr pMeta;
        public readonly IntPtr pParent;
        public Common.Vector.Vector3 StrafePositionDelta;
        public readonly IntPtr pData;
        public int Unknown_6;
        public int Unknown_7;
        public int RunObjectParamID;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public int Unknown_12;
        public int SelectInformation;
        public int Unknown_14;
        public int ObjectModleID;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public IntPtr p1;
        public int Unknown_19;
        public IntPtr p2;
        public Common.Vector.Vector3 PositionCopy;
        public Common.Vector.Vector3 RotationCopy;
        public Common.Vector.Vector3 LocalDeltaRotationCopy;
        public int SpeedCopy;
        public int Hull;
        public int Unknown_20;
        public int Unknown_21;
        #endregion

        #endregion

        /// <summary>
        /// Load a sectorobject from an address in memory.
        /// </summary>
        /// <param name="gameHook"></param>
        /// <param name="Address"></param>
        public SectorObject(GameHook gameHook, IntPtr Address)
        {
            m_GameHook = gameHook;

            var Memory = MemoryControl.Read(m_GameHook.hProcess, Address, ByteSize);

            // Load readonly variables
            pThis = Address;
            Next = (IntPtr)BitConverter.ToInt32(Memory, 0);
            Previous = (IntPtr)BitConverter.ToInt32(Memory, 4);
            pDefaultName = (IntPtr)BitConverter.ToInt32(Memory, 12);
            MainType = (Main_Type)BitConverter.ToInt16(Memory, 72);
            SubType = BitConverter.ToInt16(Memory, 74);
            pMeta = (IntPtr)BitConverter.ToInt32(Memory, 76);
            pParent = (IntPtr)BitConverter.ToInt32(Memory, 80);
            pData = (IntPtr)BitConverter.ToInt32(Memory, 96);

            // Load dynamic data
            SetData(Memory);
        }

        /// <summary>
        /// Load a sectorobject from a byte array.
        /// pThis will be set to null.
        /// </summary>
        /// <param name="gameHook"></param>
        /// <param name="Memory"></param>
        public SectorObject(GameHook gameHook, byte[] Memory)
        {
            m_GameHook = gameHook;
            // Load readonly variables
            pThis = IntPtr.Zero;
            Next = (IntPtr)BitConverter.ToInt32(Memory, 0);
            Previous = (IntPtr)BitConverter.ToInt32(Memory, 4);
            pDefaultName = (IntPtr)BitConverter.ToInt32(Memory, 12);
            MainType = (Main_Type)BitConverter.ToInt16(Memory, 72);
            SubType = BitConverter.ToInt16(Memory, 74);
            pMeta = (IntPtr)BitConverter.ToInt32(Memory, 76);
            pParent = (IntPtr)BitConverter.ToInt32(Memory, 80);
            pData = (IntPtr)BitConverter.ToInt32(Memory, 96);

            // Load dynamic data
            SetData(Memory);
        }

        #region Public Methods

        public IntPtr GetFirstChildPointer()
        {
            switch (MainType)
            {
                case Main_Type.Ship: return ((ShipMeta)GetMetaData()).FirstChild;
                default: throw new NotImplementedException();
            }
        }

        #region Game Memory

        /// <summary>
        /// Loads dynamic data from the sectorobject memory.
        /// </summary>
        /// <param name="Memory"></param>
        public void SetData(byte[] Memory)
        {
            // Load object data from memory
            SectorObjectID = BitConverter.ToInt32(Memory, 8);
            Speed = BitConverter.ToInt32(Memory, 16);
            TargetSpeed = BitConverter.ToInt32(Memory, 20);
            Rotation = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 24), BitConverter.ToInt32(Memory, 28), BitConverter.ToInt32(Memory, 32));
            LocalRotationDelta = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 36), BitConverter.ToInt32(Memory, 40), BitConverter.ToInt32(Memory, 44));
            AutoPilotRotationChange = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 48), BitConverter.ToInt32(Memory, 52), BitConverter.ToInt32(Memory, 56));
            RaceID = Race.ConvertToRaceID(BitConverter.ToInt16(Memory, 60));
            Unknown_4 = BitConverter.ToInt16(Memory, 62);
            InteractionFlags = new InteractionFlags(BitConverter.ToInt32(Memory, 64));
            Unknown_5 = BitConverter.ToInt32(Memory, 68);
            StrafePositionDelta = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 84), BitConverter.ToInt32(Memory, 88), BitConverter.ToInt32(Memory, 92));
            Unknown_6 = BitConverter.ToInt32(Memory, 100);
            Unknown_7 = BitConverter.ToInt32(Memory, 104);
            RunObjectParamID = BitConverter.ToInt32(Memory, 108);
            Unknown_9 = BitConverter.ToInt32(Memory, 112);
            Unknown_10 = BitConverter.ToInt32(Memory, 116);
            Unknown_11 = BitConverter.ToInt32(Memory, 120);
            Unknown_12 = BitConverter.ToInt32(Memory, 124);
            SelectInformation = BitConverter.ToInt32(Memory, 128);
            Unknown_14 = BitConverter.ToInt32(Memory, 132);
            ObjectModleID = BitConverter.ToInt32(Memory, 136);
            Unknown_15 = BitConverter.ToInt32(Memory, 140);
            Unknown_16 = BitConverter.ToInt32(Memory, 144);
            Unknown_17 = BitConverter.ToInt32(Memory, 148);
            Unknown_18 = BitConverter.ToInt32(Memory, 152);
            p1 = (IntPtr)BitConverter.ToInt32(Memory, 156);
            Unknown_19 = BitConverter.ToInt32(Memory, 160);
            p2 = (IntPtr)BitConverter.ToInt32(Memory, 164);
            PositionCopy = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 168), BitConverter.ToInt32(Memory, 172), BitConverter.ToInt32(Memory, 176));
            RotationCopy = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 180), BitConverter.ToInt32(Memory, 184), BitConverter.ToInt32(Memory, 188));
            LocalDeltaRotationCopy = new Common.Vector.Vector3(BitConverter.ToInt32(Memory, 192), BitConverter.ToInt32(Memory, 196), BitConverter.ToInt32(Memory, 200));
            SpeedCopy = BitConverter.ToInt32(Memory, 204);
            Hull = BitConverter.ToInt32(Memory, 208);
            Unknown_20 = BitConverter.ToInt32(Memory, 212);
            Unknown_21 = BitConverter.ToInt32(Memory, 216);
        }

        public virtual int GetByteSize()
        {
            return ByteSize;
        }

        /// <summary>
        /// Returns the object in bytes compatable with the game.
        /// </summary>
        /// <returns></returns>
        public virtual byte[] GetBytes()
        {
            List<byte> Memory = new List<byte>();

            Memory.AddRange(BitConverter.GetBytes((int)Next));
            Memory.AddRange(BitConverter.GetBytes((int) Previous));
            Memory.AddRange(BitConverter.GetBytes((int) SectorObjectID));
            Memory.AddRange(BitConverter.GetBytes((int) pDefaultName));
            Memory.AddRange(BitConverter.GetBytes((int) Speed));
            Memory.AddRange(BitConverter.GetBytes((int) TargetSpeed));
            Memory.AddRange(Rotation.GetBytes());
            Memory.AddRange(LocalRotationDelta.GetBytes());
            Memory.AddRange(AutoPilotRotationChange.GetBytes());
            Memory.AddRange(BitConverter.GetBytes(Race.ConvertToShort(RaceID)));
            Memory.AddRange(BitConverter.GetBytes((short) Unknown_4));
            Memory.AddRange(InteractionFlags.GetBytes());
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_5));
            Memory.AddRange(BitConverter.GetBytes((short) MainType));
            Memory.AddRange(BitConverter.GetBytes((short) SubType));
            Memory.AddRange(BitConverter.GetBytes((int) pMeta));
            Memory.AddRange(BitConverter.GetBytes((int) pParent));
            Memory.AddRange(StrafePositionDelta.GetBytes());
            Memory.AddRange(BitConverter.GetBytes((int) pData));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_6));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_7));
            Memory.AddRange(BitConverter.GetBytes((int) RunObjectParamID));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_9));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_10));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_11));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_12));
            Memory.AddRange(BitConverter.GetBytes((int) SelectInformation));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_14));
            Memory.AddRange(BitConverter.GetBytes((int) ObjectModleID));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_15));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_16));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_17));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_18));
            Memory.AddRange(BitConverter.GetBytes((int) p1));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_19));
            Memory.AddRange(BitConverter.GetBytes((int) p2));
            Memory.AddRange(PositionCopy.GetBytes());
            Memory.AddRange(RotationCopy.GetBytes());
            Memory.AddRange(LocalDeltaRotationCopy.GetBytes());
            Memory.AddRange(BitConverter.GetBytes((int) SpeedCopy));
            Memory.AddRange(BitConverter.GetBytes((int) Hull));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_20));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_21));

            return Memory.ToArray();
            
        }

        /// <summary>
        /// Saves the changes to the sectorobject to game memory.
        /// </summary>
        public void Save()
        {
            if (pThis == IntPtr.Zero)
                throw new Exception("pThis is null, unable to save.");
            MemoryControl.Write(m_GameHook.hProcess, pThis+8, GetBytes().Skip(8).ToArray());
        }

        public void SaveMeta(IMemoryObject Meta)
        {
            throw new Common.KnownBrokenMethodExcption();
            MemoryControl.Write(m_GameHook.hProcess, pMeta, Meta.GetBytes());
        }

        public void SaveData(SectorObject.Data Data)
        {
            MemoryControl.Write(m_GameHook.hProcess, pData, Data.GetBytes());
        }

        #endregion

        /// <summary>
        /// Returns the sectorobject's meta data.
        /// </summary>
        /// <returns></returns>
        public IMemoryObject GetMetaData()
        {
            if (pMeta == IntPtr.Zero)
                return null;
            switch (MainType)
            {
                case Main_Type.Ship:
                    return new ShipMeta(m_GameHook.hProcess, pMeta);
                case Main_Type.Planet:
                case Main_Type.Nebula:
                case Main_Type.Gate:
                case Main_Type.Sun:
                    return null;
                case Main_Type.Sector:
                    return new SectorMeta(m_GameHook.hProcess, pMeta);
                case Main_Type.Asteroid:
                    return null;
                case Main_Type.Shield:
                    return null;
                case Main_Type.ShipGun:
                    return null;
                case Main_Type.Projectile:
                    return new ProjectileMeta(m_GameHook.hProcess, pMeta);
                case Main_Type.Factory:
                case Main_Type.Dock:
                    return null;
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion

    }
}
