using CommonToolLib.Memory;
using System;
using System.IO;

namespace CommonToolLib.Network
{
    public class Packet
    {
        public byte packetType;
        public int dataLength { get; private set; }
        public byte[] data { get; private set; }

        public void SetData(byte[] data)
        {
            this.data = data;
            dataLength = data.Length;
        }

        public byte[] ToBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(packetType);
            collection.Append(data.Length);
            collection.Append(data);
            return collection.GetBytes();
        }

        public void FromStream(Stream stream)
        {
            packetType = (byte)stream.ReadByte();
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            dataLength = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[dataLength];
            stream.Read(buffer, 0, dataLength);
            data = buffer;
        }
    }
}
