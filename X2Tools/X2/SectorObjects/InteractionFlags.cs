using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Memory;

namespace X2Tools.X2.SectorObjects
{
    public class InteractionFlags : IMemoryObject
    {
        public const int ByteSize = 4;

        public bool Unknown1;
        public bool IsPlayerShip;
        public bool Unknown3;
        public bool Unknown4;
        public bool Unknown5;
        public bool IsShip;
        public bool Unknown7;
        public bool Unknown8;
        public bool Unknown9;
        public bool Unknown10;
        public bool Unknown11;
        public bool Unknown12;
        public bool BlockSeta;
        public bool CollisionWarning;
        public bool Unknown15;
        public bool Unknown16;
        public bool Unknown17;
        public bool Unknown18;
        public bool Unknown19;
        public bool IsAIControled;
        public bool Unknown21;
        public bool Unknown22;
        public bool Unknown23;
        public bool Unknown24;
        public bool Unknown25;
        public bool Unknown26;
        public bool Unknown27;
        public bool IsPendingDestruction;
        public bool Unknown29;
        public bool Unknown30;
        public bool Unknown31;
        public bool Unknown32;

        public InteractionFlags(byte[] Data)
        {
            SetData(Data);
        }

        public InteractionFlags(int Data)
        {
            SetData(Data);
        }

        public byte[] GetBytes()
        {

            uint Value = 0;
            if (Unknown1)  Value = Value | 0b1;
            if (IsPlayerShip)  Value = Value | 0b10;
            if (Unknown3)  Value = Value | 0b100;
            if (Unknown4)  Value = Value | 0b1000;
            if (Unknown5)  Value = Value | 0b10000;
            if (IsShip)  Value = Value | 0b100000;
            if (Unknown7)  Value = Value | 0b1000000;
            if (Unknown8)  Value = Value | 0b10000000;
            if (Unknown9)  Value = Value | 0b100000000;
            if (Unknown10) Value = Value | 0b1000000000;
            if (Unknown11) Value = Value | 0b10000000000;
            if (Unknown12) Value = Value | 0b100000000000;
            if (BlockSeta) Value = Value | 0b1000000000000;
            if (CollisionWarning) Value = Value | 0b10000000000000;
            if (Unknown15) Value = Value | 0b100000000000000;
            if (Unknown16) Value = Value | 0b1000000000000000;
            if (Unknown17) Value = Value | 0b10000000000000000;
            if (Unknown18) Value = Value | 0b100000000000000000;
            if (Unknown19) Value = Value | 0b1000000000000000000;
            if (IsAIControled) Value = Value | 0b10000000000000000000;
            if (Unknown21) Value = Value | 0b100000000000000000000;
            if (Unknown22) Value = Value | 0b1000000000000000000000;
            if (Unknown23) Value = Value | 0b10000000000000000000000;
            if (Unknown24) Value = Value | 0b100000000000000000000000;
            if (Unknown25) Value = Value | 0b1000000000000000000000000;
            if (Unknown26) Value = Value | 0b10000000000000000000000000;
            if (Unknown27) Value = Value | 0b100000000000000000000000000;
            if (IsPendingDestruction) Value = Value | 0b1000000000000000000000000000;
            if (Unknown29) Value = Value | 0b10000000000000000000000000000;
            if (Unknown30) Value = Value | 0b100000000000000000000000000000;
            if (Unknown31) Value = Value | 0b1000000000000000000000000000000;
            if (Unknown32) Value = Value | 0b10000000000000000000000000000000;
            return BitConverter.GetBytes(Value);
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            int value = BitConverter.ToInt32(Memory, 0);
            SetData(value);
        }

        public void SetData(int Value)
        {
            Unknown1 = (Value & 1) != 0;
            Value = Value >> 1;
            IsPlayerShip = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown3 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown4 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown5 = (Value & 1) != 0;
            Value = Value >> 1;
            IsShip = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown7 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown8 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown9 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown10 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown11 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown12 = (Value & 1) != 0;
            Value = Value >> 1;
            BlockSeta = (Value & 1) != 0;
            Value = Value >> 1;
            CollisionWarning = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown15 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown16 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown17 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown18 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown19 = (Value & 1) != 0;
            Value = Value >> 1;
            IsAIControled = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown21 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown22 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown23 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown24 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown25 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown26 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown27 = (Value & 1) != 0;
            Value = Value >> 1;
            IsPendingDestruction = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown29 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown30 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown31 = (Value & 1) != 0;
            Value = Value >> 1;
            Unknown32 = (Value & 1) != 0;
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }
    }
}
