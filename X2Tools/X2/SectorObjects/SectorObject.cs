using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2.SectorObjects.Meta;
using CommonToolLib.Memory;
using CommonToolLib.Vector;

namespace X2Tools.X2.SectorObjects
{
    /// <summary>
    /// The main object type within X2 The Threat.
    /// Contains data relating to its type, speed, and copies of its position and rotation.
    /// Contains pointers to additional data structures.
    /// </summary>
    public partial class SectorObject : MemoryObject
    {
        /// <summary>
        /// The size of this object in bytes
        /// </summary>
        public const int ByteSize = 220;

        public bool IsValid { get
            {
                return pNext.IsValid && pPrevious.IsValid;
            } }

        #region Game memory values
        // All values stored in memory
        public MemoryObjectPointer<SectorObject> pNext = new MemoryObjectPointer<SectorObject>();
        public MemoryObjectPointer<SectorObject> pPrevious = new MemoryObjectPointer<SectorObject>();
        public int SectorObjectID;
        public MemoryObjectPointer<MemoryString> pDefaultName = new MemoryObjectPointer<MemoryString>();
        public int Speed;
        public int TargetSpeed;
        public CommonToolLib.Vector.Vector3 Rotation;
        public CommonToolLib.Vector.Vector3 LocalRotationDelta;
        public CommonToolLib.Vector.Vector3 AutoPilotRotationChange;
        public Race.RaceID RaceID;
        public int Unknown_4;
        public InteractionFlags InteractionFlags;
        public int Unknown_5;
        public Main_Type MainType;
        public int SubType;
        public IntPtr pMeta;
        public MemoryObjectPointer<SectorObject> pParent = new MemoryObjectPointer<SectorObject>();
        public CommonToolLib.Vector.Vector3 StrafePositionDelta;
        public MemoryObjectPointer<SectorObjectData> pData = new MemoryObjectPointer<SectorObjectData>();
        public int Unknown_6;
        public int Unknown_7;
        public int RunObjectParamID;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public int Unknown_12;
        public int SelectInformation;
        public int Unknown_14;
        public int ModelCollectionID;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public IntPtr p1;
        public int Unknown_19;
        public IntPtr p2;
        public CommonToolLib.Vector.Vector3 PositionCopy;
        public CommonToolLib.Vector.Vector3 RotationCopy;
        public CommonToolLib.Vector.Vector3 LocalDeltaRotationCopy;
        public int SpeedCopy;
        public int Hull;
        public int Unknown_20;
        public int Unknown_21;
        #endregion

        /// <summary>
        /// Load a sectorobject from an address in memory.
        /// </summary>
        /// <param name="gameHook"></param>
        /// <param name="Address"></param>
        public SectorObject()
        {
        }

        #region Public Methods

        public IntPtr GetFirstChildPointer()
        {
            switch (MainType)
            {
                default: throw new NotImplementedException();
            }
        }

        #region IMemoryObject

        /// <summary>
        /// Loads dynamic data from the sectorobject memory.
        /// </summary>
        /// <param name="memory"></param>
        public override void SetData(byte[] memory)
        {
            // Load object data from memory
            var collection = new ObjectByteList(memory,m_hProcess, pThis);

            pNext = collection.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            pPrevious = collection.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            SectorObjectID = collection.PopInt();
            pDefaultName = collection.PopIMemoryObject<MemoryObjectPointer<MemoryString>>();
            Speed = collection.PopInt();
            TargetSpeed = collection.PopInt();
            Rotation = collection.PopIMemoryObject<Vector3>();
            LocalRotationDelta = collection.PopIMemoryObject<Vector3>();
            AutoPilotRotationChange = collection.PopIMemoryObject<Vector3>();
            RaceID = Race.ConvertToRaceID(collection.PopShort());
            Unknown_4 = collection.PopShort();
            InteractionFlags = collection.PopIMemoryObject<InteractionFlags>();
            Unknown_5 = collection.PopInt();
            MainType = (SectorObject.Main_Type)collection.PopShort();
            SubType = collection.PopShort();
            pMeta = (IntPtr)collection.PopInt();
            pParent = collection.PopIMemoryObject<MemoryObjectPointer<SectorObject>>();
            StrafePositionDelta = collection.PopIMemoryObject<Vector3>();
            pData = collection.PopIMemoryObject<MemoryObjectPointer<SectorObjectData>>();

            Unknown_6 = BitConverter.ToInt32(memory, 100);
            Unknown_7 = BitConverter.ToInt32(memory, 104);
            RunObjectParamID = BitConverter.ToInt32(memory, 108);
            Unknown_9 = BitConverter.ToInt32(memory, 112);
            Unknown_10 = BitConverter.ToInt32(memory, 116);
            Unknown_11 = BitConverter.ToInt32(memory, 120);
            Unknown_12 = BitConverter.ToInt32(memory, 124);
            SelectInformation = BitConverter.ToInt32(memory, 128);
            Unknown_14 = BitConverter.ToInt32(memory, 132);
            ModelCollectionID = BitConverter.ToInt32(memory, 136);
            Unknown_15 = BitConverter.ToInt32(memory, 140);
            Unknown_16 = BitConverter.ToInt32(memory, 144);
            Unknown_17 = BitConverter.ToInt32(memory, 148);
            Unknown_18 = BitConverter.ToInt32(memory, 152);
            p1 = (IntPtr)BitConverter.ToInt32(memory, 156);
            Unknown_19 = BitConverter.ToInt32(memory, 160);
            p2 = (IntPtr)BitConverter.ToInt32(memory, 164);
            PositionCopy = new CommonToolLib.Vector.Vector3(BitConverter.ToInt32(memory, 168), BitConverter.ToInt32(memory, 172), BitConverter.ToInt32(memory, 176));
            RotationCopy = new CommonToolLib.Vector.Vector3(BitConverter.ToInt32(memory, 180), BitConverter.ToInt32(memory, 184), BitConverter.ToInt32(memory, 188));
            LocalDeltaRotationCopy = new CommonToolLib.Vector.Vector3(BitConverter.ToInt32(memory, 192), BitConverter.ToInt32(memory, 196), BitConverter.ToInt32(memory, 200));
            SpeedCopy = BitConverter.ToInt32(memory, 204);
            Hull = BitConverter.ToInt32(memory, 208);
            Unknown_20 = BitConverter.ToInt32(memory, 212);
            Unknown_21 = BitConverter.ToInt32(memory, 216);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        /// <summary>
        /// Returns the object in bytes compatable with the game.
        /// </summary>
        /// <returns></returns>
        public override byte[] GetBytes()
        {
            List<byte> Memory = new List<byte>();

            Memory.AddRange(BitConverter.GetBytes((int) pNext.address));
            Memory.AddRange(BitConverter.GetBytes((int) pPrevious.address));
            Memory.AddRange(BitConverter.GetBytes((int) SectorObjectID));
            Memory.AddRange(BitConverter.GetBytes((int) pDefaultName.address));
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
            Memory.AddRange(BitConverter.GetBytes((int) pParent.address));
            Memory.AddRange(StrafePositionDelta.GetBytes());
            Memory.AddRange(BitConverter.GetBytes((int) pData.address));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_6));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_7));
            Memory.AddRange(BitConverter.GetBytes((int) RunObjectParamID));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_9));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_10));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_11));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_12));
            Memory.AddRange(BitConverter.GetBytes((int) SelectInformation));
            Memory.AddRange(BitConverter.GetBytes((int) Unknown_14));
            Memory.AddRange(BitConverter.GetBytes((int) ModelCollectionID));
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
            MemoryControl.Write(m_hProcess, pThis+8, GetBytes().Skip(8).ToArray());
        }

        #endregion

        /// <summary>
        /// Returns the sectorobject's meta data.
        /// </summary>
        /// <returns></returns>
        public ISectorObjectMeta GetMetaData()
        {
            if (pMeta == IntPtr.Zero)
                return null;
            switch (MainType)
            {
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion

    }
}
