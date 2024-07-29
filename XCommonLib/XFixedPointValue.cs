using CommonToolLib.Generics;
using CommonToolLib.Generics.BinaryObjects;
using CommonToolLib.ProcessHooking;
using System;

namespace XCommonLib
{
    public struct XFixedPointValue : IBinaryObject
    {
        public int FixedPointValue;

        public decimal Decimal
        {
            get => (decimal)FixedPointValue / FixedPointUnit;
            set => FixedPointValue = (int)(value * FixedPointUnit);
        }

        public double Double
        {
            get => (double)Decimal;
            set => Decimal = (decimal)value;
        }

        public static decimal ConvertFromInt(int value)
        {
            return value / FixedPointUnit;
        }

        public static int ConvertToInt(decimal value)
        {
            return Convert.ToInt32(value * FixedPointUnit);
        }

        public const int FixedPointUnit = 0x00010000;
        public override string ToString()
        {
            return FixedPointValue.ToString() + " (" + Decimal.ToString() + ")";
        }

        public static XFixedPointValue operator * (XFixedPointValue a, XFixedPointValue b)
        {
            a.Decimal *= b.Decimal;
            return a;
        }

        public static XFixedPointValue operator + (XFixedPointValue a, XFixedPointValue b)
        {
            a.Decimal += b.Decimal;
            return a;
        }

        #region IBinaryObject
        public byte[] GetBytes()
        {
            return BitConverter.GetBytes(FixedPointValue);
        }

        public const int BYTE_SIZE = 4;
        public int ByteSize => BYTE_SIZE;

        public void SetData(byte[] data, out int bytesConsumed)
        {
            FixedPointValue = BitConverter.ToInt32(data, 0);
            bytesConsumed = BYTE_SIZE;
        }
        #endregion


        #region Pre defined values
        public static XFixedPointValue Zero
        {
            get
            {
                var val = new XFixedPointValue();
                val.FixedPointValue = 0;
                return val;
            }
        }
        #endregion
    }
}
