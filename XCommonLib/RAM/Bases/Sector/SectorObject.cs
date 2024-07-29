﻿using CommonToolLib.Generics;
using CommonToolLib.Generics.BinaryObjects;
using CommonToolLib.ProcessHooking;
using System;
using XCommonLib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.Sector
{
    public abstract class SectorObject : MemoryObject, IValidateable, INumericIDObject, IComparable
    {
        public struct SectorObjectType : IMemoryObject, IComparable
        {
            public short MainType;
            public short SubType;

            public override string ToString()
            {
                return string.Format("{0} - {1}", MainType, SubType);
            }

            public IntPtr pThis { get; set; }
            public IMemoryBlockManager ParentMemoryBlock { get; set; }

            public const int BYTE_SIZE = 4;
            public int ByteSize => BYTE_SIZE;

            public byte[] GetBytes()
            {
                byte[] arr = new byte[4];
                Array.Copy(BitConverter.GetBytes(MainType), 0, arr, 0, 2);
                Array.Copy(BitConverter.GetBytes(SubType), 0, arr, 2, 2);
                return arr;
            }

            public void ReloadFromMemory(int maxObjectSize = BinaryObjectConverter.DEFAULT_MAX_OBJECT_SIZE)
            {
                throw new NotImplementedException();
            }

            public void SetData(byte[] data, out int bytesConsumed)
            {
                MainType = BitConverter.ToInt16(data, 0);
                SubType = BitConverter.ToInt16(data, 2);
                bytesConsumed = BYTE_SIZE;
            }

            public int CompareTo(object obj)
            {
                if (obj is SectorObjectType)
                {
                    var sot = (SectorObjectType)obj;

                    if (MainType > sot.MainType)
                    {
                        return 1;
                    }

                    if (MainType < sot.MainType)
                    {
                        return -1;
                    }

                    if (SubType > sot.SubType)
                    {
                        return 1;
                    }

                    if (SubType < sot.SubType)
                    {
                        return -1;
                    }

                    return 0;
                }
                throw new ArgumentException("Object is not of same type.");
            }
        }
        public abstract bool IsValid { get; }

        #region Memory
        /// <summary>
        /// Next SectorObject in the list.
        /// Is null if object is invalid or non-existant.
        /// </summary>
        public abstract SectorObject Next { get; }
        /// <summary>
        /// Previous SectorObject in the list.
        /// Is null if object is invalid or non-existant.
        /// </summary>
        public abstract SectorObject Previous { get; }
        public abstract int ID { get; set; }
        public abstract MemoryString DefaultName { get; }
        public abstract int Speed { get; set; }
        public abstract int DesiredSpeed { get; set; }
        public SectorObjectType ObjectType;
        public abstract Vector3_32 EulerRotationCopy { get; set; }
        public abstract Vector3_32 LocalEulerRotationDelta { get; set; }
        public abstract Vector3_32 LocalAutopilotRotationDeltaTarget { get; set; }
        public abstract ushort RaceID { get; set; }
        public abstract BitField InteractionFlags { get; set; }
        public abstract Vector3_32 CopyPosition { get; set; }
        public abstract Vector3_32 PositionStrafeDelta { get; set; }
        public abstract RenderObject RenderObject { get; }
        public abstract ISectorObjectMeta Meta { get; }
        public abstract int ScriptInstanceID { get; set; }
        public abstract int ModelCollectionID { get; set; }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} | {1}", ID, ObjectType.ToString());
        }

        public int CompareTo(object obj)
        {
            if (obj is SectorObject)
            {
                var so = (SectorObject)obj;
                var typeResult = ObjectType.CompareTo(so.ObjectType);
                if (typeResult != 0)
                {
                    return typeResult;
                }

                if (RaceID > so.RaceID)
                {
                    return 1;
                }

                if (RaceID < so.RaceID)
                {
                    return -1;
                }

                return 0;
            }
            throw new ArgumentException("Object is not of same type.");
        }
    }
}
