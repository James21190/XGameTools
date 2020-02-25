using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

using Common.Memory;

namespace Common.Network
{
    public class Packet
    {
        public byte packetType;
        public int dataLength { get; private set; }
        public byte[] data { get; private set; }

        public void SetData(byte[] data)
        {
            this.data = data;
            this.dataLength = data.Length;
        }

        public byte[] ToBytes()
        {
            var collection = new ObjectByteList();
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
