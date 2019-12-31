using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Memory;

namespace X2Tools.X2.SectorObjects.Meta
{
    class ProjectileMeta : IMemoryObject
    {
        public const int ByteSize = 116;

        public int Unknown_1;
        public IntPtr pParentShip;
        public int Unknown_2;
        public int Unknown_3;
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6;
        public int Unknown_7;
        public int Unknown_8;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public int Unknown_12;
        public int Unknown_13;
        public int Unknown_14;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public int Unknown_19;
        public int Unknown_20;
        public int Unknown_21;
        public IntPtr pParentGun;
        public int Unknown_22;
        public int Unknown_23;
        public int Unknown_24;
        public int Unknown_25;
        public int Unknown_26;
        public int Unknown_27;

        public ProjectileMeta(IntPtr hProcess, IntPtr Address)
        {
            SetData(MemoryControl.Read(hProcess, Address, ByteSize));
        }

        public ProjectileMeta(byte[] Memory)
        {
            SetData(Memory);
        }

        public void SetData(byte[] Memory)
        {
            Unknown_1 = BitConverter.ToInt32(Memory,0);
            pParentShip = (IntPtr)BitConverter.ToInt32(Memory,4);
            Unknown_2 = BitConverter.ToInt32(Memory,8);
            Unknown_3 = BitConverter.ToInt32(Memory,12);
            Unknown_4 = BitConverter.ToInt32(Memory,16);
            Unknown_5 = BitConverter.ToInt32(Memory,20);
            Unknown_6 = BitConverter.ToInt32(Memory,24);
            Unknown_7 = BitConverter.ToInt32(Memory,28);
            Unknown_8 = BitConverter.ToInt32(Memory,32);
            Unknown_9 = BitConverter.ToInt32(Memory,36);
            Unknown_10 = BitConverter.ToInt32(Memory,40);
            Unknown_11 = BitConverter.ToInt32(Memory,44);
            Unknown_12 = BitConverter.ToInt32(Memory,48);
            Unknown_13 = BitConverter.ToInt32(Memory,52);
            Unknown_14 = BitConverter.ToInt32(Memory,56);
            Unknown_15 = BitConverter.ToInt32(Memory,60);
            Unknown_16 = BitConverter.ToInt32(Memory,64);
            Unknown_17 = BitConverter.ToInt32(Memory,68);
            Unknown_18 = BitConverter.ToInt32(Memory,72);
            Unknown_19 = BitConverter.ToInt32(Memory,76);
            Unknown_20 = BitConverter.ToInt32(Memory,80);
            Unknown_21 = BitConverter.ToInt32(Memory,84);
            pParentGun = (IntPtr)BitConverter.ToInt32(Memory,88);
            Unknown_22 = BitConverter.ToInt32(Memory,92);
            Unknown_23 = BitConverter.ToInt32(Memory,96);
            Unknown_24 = BitConverter.ToInt32(Memory,100);
            Unknown_25 = BitConverter.ToInt32(Memory,104);
            Unknown_26 = BitConverter.ToInt32(Memory,108);
            Unknown_27 = BitConverter.ToInt32(Memory,112);
        }

        public byte[] GetBytes()
        {
            byte[] arr = new byte[ByteSize];

            Array.Copy(BitConverter.GetBytes(Unknown_1), 0, arr,0, 4);
            Array.Copy(BitConverter.GetBytes((int)pParentShip),0,arr,4, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_2),0,arr,8, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_3),0,arr,12, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_4),0,arr,16, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_5),0,arr,20, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_6),0,arr,24,4);
            Array.Copy(BitConverter.GetBytes(Unknown_7),0,arr,28,4);
            Array.Copy(BitConverter.GetBytes(Unknown_8),0,arr,32,4);
            Array.Copy(BitConverter.GetBytes(Unknown_9),0,arr,36, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_10),0,arr,40,4);
            Array.Copy(BitConverter.GetBytes(Unknown_11),0,arr,44,4);
            Array.Copy(BitConverter.GetBytes(Unknown_12),0,arr,48,4);
            Array.Copy(BitConverter.GetBytes(Unknown_13),0,arr,52,4);
            Array.Copy(BitConverter.GetBytes(Unknown_14),0,arr,56,4);
            Array.Copy(BitConverter.GetBytes(Unknown_15),0,arr,60,4);
            Array.Copy(BitConverter.GetBytes(Unknown_16),0,arr,64,4);
            Array.Copy(BitConverter.GetBytes(Unknown_17),0,arr,68,4);
            Array.Copy(BitConverter.GetBytes(Unknown_18),0,arr,72,4);
            Array.Copy(BitConverter.GetBytes(Unknown_19),0,arr,76,4);
            Array.Copy(BitConverter.GetBytes(Unknown_20),0,arr,80,4);
            Array.Copy(BitConverter.GetBytes(Unknown_21),0,arr,84, 4);
            Array.Copy(BitConverter.GetBytes((int)pParentGun),0,arr,88, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_22),0,arr,92, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_23),0,arr,96, 4);
            Array.Copy(BitConverter.GetBytes(Unknown_24),0,arr,100,4);
            Array.Copy(BitConverter.GetBytes(Unknown_25),0,arr,104,4);
            Array.Copy(BitConverter.GetBytes(Unknown_26),0,arr,108,4);
            Array.Copy(BitConverter.GetBytes(Unknown_27),0,arr,112, 4);


            return arr;
        }

        public int GetByteSize()
        {
            return ByteSize;
        }
    }
}
