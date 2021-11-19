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
        /// <summary>
        /// Numerical ID to describe the data.
        /// </summary>
        public readonly byte PacketType;
        public virtual byte[] Data { get; set; }

        public Packet(byte packetType)
        {
            PacketType = packetType;
        }

        public T ConvertToPacketType<T>() where T : Packet, new()
        {
            var newPacket = new T();
            newPacket.Data = Data;
            return newPacket;
        }

        public void WriteToStream(NetworkStream stream)
        {
            ObjectByteList collection = new ObjectByteList();
            var length = Data != null ? Data.Length : 0;
            var data = Data != null ? Data : new byte[0];
            collection.Append(PacketType);
            collection.Append(length);
            collection.Append(data);
            var bytes = collection.GetBytes();
            stream.Write(bytes, 0, bytes.Length);
        }

        public static Packet ReadPacketFromStream(NetworkStream stream)
        {
            var packetType = (byte)stream.ReadByte();
            var packet = new Packet(packetType);
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            var dataLength = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[dataLength];
            stream.Read(buffer, 0, dataLength);
            packet.Data = buffer;
            return packet;
        }

        public IBinaryObject ToBinaryObject<T>() where T : IBinaryObject, new()
        {
            var result = new T();
            result.SetData(Data);
            return result;
        }

        public void FromBinaryObject(IBinaryObject binaryObject)
        {
            Data = binaryObject.GetBytes();
        }
    }
}
