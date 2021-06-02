using CommonToolLib.Memory;
using CommonToolLib.Vector;
using System;
using XCommonLib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Sector.Meta;
using XCommonLib.RAM.Generics;

namespace XCommonLib.RAM.Bases.Sector
{
    public abstract class SectorObject : MemoryObject, IValidateable, INumericIDObject
    {
        public struct SectorObjectType : IMemoryObject
        {
            public short MainType;
            public short SubType;

            public IntPtr pThis { get; set; }
            public IntPtr hProcess { get; set; }

            public int ByteSize => 4;

            public byte[] GetBytes()
            {
                byte[] arr = new byte[4];
                Array.Copy(BitConverter.GetBytes(MainType), 0, arr, 0, 2);
                Array.Copy(BitConverter.GetBytes(SubType), 0, arr, 2, 2);
                return arr;
            }

            public void ReloadFromMemory()
            {
                throw new NotImplementedException();
            }

            public void SetData(byte[] Memory)
            {
                MainType = BitConverter.ToInt16(Memory, 0);
                SubType = BitConverter.ToInt16(Memory, 2);
            }

            public void SetLocation(IntPtr hProcess, IntPtr address)
            {
                this.hProcess = hProcess;
                pThis = address;
            }
        }
        public abstract bool IsValid { get; }

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
        public abstract Vector3 EulerRotation { get; set; }
        public abstract Vector3 LocalEulerRotationDelta { get; set; }
        public abstract Vector3 LocalAutopilotRotationDeltaTarget { get; set; }
        public abstract ushort RaceID { get; set; }
        public abstract Vector3 Position { get; set; }
        public abstract Vector3 PositionStrafeDelta { get; set; }
        public abstract RenderObject RenderObject { get; }
        public abstract ISectorObjectMeta Meta { get; }
    }
}
