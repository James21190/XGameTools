using CommonToolLib.Generics.BinaryObjects;
using CommonToolLib.ProcessHooking;

namespace CommonToolLibTests
{
    [TestClass]
    public class BinaryObjectConverterAppendAndPop
    {
        [TestMethod]
        public void ByteTest()
        {
            byte TestValue = 222;
            byte[] TestArray = new byte[] { 123, 213 };
            var boc = new BinaryObjectConverter();

            boc.Append(TestValue);
            boc.Append(TestArray);

            var ReturnedValue = boc.PopByte();
            var ReturnedArray = boc.PopBytes(TestArray.Length);

            Assert.IsTrue(TestValue == ReturnedValue);
            for (int i = 0; i < TestArray.Length; i++)
            {
                Assert.IsTrue(TestArray[i] == ReturnedArray[i]);
            }
        }

        [TestMethod]
        public void ShortTest()
        {
            short TestValue = 222;
            short[] TestArray = new short[] { 123, 213 };
            var boc = new BinaryObjectConverter();

            boc.Append(TestValue);
            boc.Append(TestArray);

            var ReturnedValue = boc.PopShort();
            var ReturnedArray = boc.PopShorts(TestArray.Length);

            Assert.IsTrue(TestValue == ReturnedValue);
            for (int i = 0; i < TestArray.Length; i++)
            {
                Assert.IsTrue(TestArray[i] == ReturnedArray[i]);
            }
        }
        [TestMethod]
        public void IntTest()
        {
            int TestValue = 222;
            int[] TestArray = new int[] { 123, 213 };
            var boc = new BinaryObjectConverter();

            boc.Append(TestValue);
            boc.Append(TestArray);

            var ReturnedValue = boc.PopInt();
            var ReturnedArray = boc.PopInts(TestArray.Length);

            Assert.IsTrue(TestValue == ReturnedValue);
            for (int i = 0; i < TestArray.Length; i++)
            {
                Assert.IsTrue(TestArray[i] == ReturnedArray[i]);
            }
        }
        [TestMethod]
        public void LongTest()
        {
            long TestValue = 222;
            long[] TestArray = new long[] { 123, 213 };
            var boc = new BinaryObjectConverter();

            boc.Append(TestValue);
            boc.Append(TestArray);

            var ReturnedValue = boc.PopLong();
            var ReturnedArray = boc.PopLongs(TestArray.Length);

            Assert.IsTrue(TestValue == ReturnedValue);
            for (int i = 0; i < TestArray.Length; i++)
            {
                Assert.IsTrue(TestArray[i] == ReturnedArray[i]);
            }
        }

        [TestMethod]
        public void TestVariableLengthObjects()
        {
            var TestValue = new MemoryString();
            TestValue.Value = "TEST";
            var TestArray = new MemoryString[2];
            TestArray[0] = new MemoryString();
            TestArray[1] = new MemoryString();

            TestArray[0].Value = "String 1";
            TestArray[1].Value = "Variable Length";

            var boc = new BinaryObjectConverter();
            boc.Append(TestValue);
            boc.Append(TestArray);

            var ReturnedValue = boc.PopIBinaryObject<MemoryString>();
            var ReturnedArray = boc.PopIBinaryObjects<MemoryString>(TestArray.Length);

            Assert.IsTrue(TestValue.Value == ReturnedValue.Value);
            for (int i = 0; i < TestArray.Length; i++)
            {
                Assert.IsTrue(TestArray[i].Value == ReturnedArray[i].Value);
            }
        }
    }
}