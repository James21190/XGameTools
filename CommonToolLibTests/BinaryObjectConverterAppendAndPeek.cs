using CommonToolLib.Generics.BinaryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLibTests
{
    [TestClass]
    public class BinaryObjectConverterAppendAndPeek
    {
        [TestMethod]
        public void ByteTest()
        {
            byte value = 0xb2;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekByte() == value);
        }
        //[TestMethod]
        //public void UShortTest()
        //{
        //    ushort value = 0x7215;
        //    var boc = new BinaryObjectConverter();
        //    boc.Append(value);
        //    Assert.IsTrue(boc.PeekUShort() == value);
        //}
        [TestMethod]
        public void UIntTest()
        {
            uint value = 0x51246312;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekUInt() == value);
        }
        [TestMethod]
        public void ULongTest()
        {
            ulong value = 0x6a513564_ac528b21;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekULong() == value);
        }

        //[TestMethod]
        //public void ShortTest()
        //{
        //    short value = 0x7215;
        //    var boc = new BinaryObjectConverter();
        //    boc.Append(value);
        //    Assert.IsTrue(boc.PeekShort() == value);
        //}
        [TestMethod]
        public void IntTest()
        {
            int value = 0x51246312;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekInt() == value);
        }
        [TestMethod]
        public void LongTest()
        {
            long value = 0x6a513564_ac528b21;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekLong() == value);
        }

        [TestMethod]
        public void FloatTest()
        {
            float value = 5212.523f;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekFloat() == value);
        }
        [TestMethod]
        public void DoubleTest()
        {
            double value = 642.12541d;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekDouble() == value);
        }
        [TestMethod]
        public void DecimalTest()
        {
            decimal value = 521.25124m;
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            Assert.IsTrue(boc.PeekDecimal() == value);
        }

        [TestMethod]
        public void ByteArrayTest()
        {
            byte[] value = { 0x51, 0x12 };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekBytes(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }
        //[TestMethod]
        //public void UShortTest()
        //{
        //    ushort value = 0x7215;
        //    var boc = new BinaryObjectConverter();
        //    boc.Append(value);
        //    Assert.IsTrue(boc.PeekUShort() == value);
        //}
        [TestMethod]
        public void UIntArrayTest()
        {
            uint[] value = { 0x51246312, 0x56546312 };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekInts(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }
        [TestMethod]
        public void ULongArrayTest()
        {
            ulong[] value = { 0x51246312_51246312, 0x51246312_51246312 };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekULongs(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }

        //[TestMethod]
        //public void ShortTest()
        //{
        //    short value = 0x7215;
        //    var boc = new BinaryObjectConverter();
        //    boc.Append(value);
        //    Assert.IsTrue(boc.PeekShort() == value);
        //}
        [TestMethod]
        public void IntArrayTest()
        {
            int[] value = { 0x51246312, 0x51246312 };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekInts(value.Length);
            for(int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }
        [TestMethod]
        public void LongArrayTest()
        {
            long[] value = { 0x51246312_51246312, 0x51246312_51246312 };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekLongs(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }

        [TestMethod]
        public void FloatArrayTest()
        {
            float[] value = { 0.5123f, 1512.251f };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekFloats(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }
        [TestMethod]
        public void DoubleArrayTest()
        {
            double[] value = { 1512.3512d, 0.5123d };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekDoubles(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }
        [TestMethod]
        public void DecimalArrayTest()
        {
            decimal[] value = { 1.5214123m, 521321.21451m };
            var boc = new BinaryObjectConverter();
            boc.Append(value);
            var arr = boc.PeekDecimals(value.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] == value[i]);
            }
        }
    }
}
