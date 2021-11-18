using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Net.Sockets;

namespace CommonToolLib.Networking
{
    /// <summary>
    /// Basic object for sending data.
    /// </summary>
    public class Packet
    {
        public byte packetType;
        public int dataLength { get; private set; }
        public byte[] data { get; private set; }

        public void WriteToStream(NetworkStream stream)
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(packetType);
            collection.Append(data.Length);
            collection.Append(data);
            var bytes = collection.GetBytes();
            stream.Write(bytes, 0, bytes.Length);
        }

        public static Packet ReadPacketFromStream(NetworkStream stream)
        {
            var packet = new Packet();
            packet.packetType = (byte)stream.ReadByte();
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            packet.dataLength = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[packet.dataLength];
            stream.Read(buffer, 0, packet.dataLength);
            packet.data = buffer;
            return packet;
        }

        public IBinaryObject ToBinaryObject<T>() where T : IBinaryObject, new()
        {
            var result = new T();
            result.SetData(data);
            return result;
        }

        public void FromBinaryObject(IBinaryObject binaryObject)
        {
            data = binaryObject.GetBytes();
            dataLength = data.Length;
        }
    }
}
