using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.IO;
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
            MemoryObjectConverter collection = new MemoryObjectConverter();
            var length = Data != null ? Data.Length : 0;
            var data = Data != null ? Data : new byte[0];
            collection.Append(PacketType);
            collection.Append(length);
            collection.Append(data);
            var bytes = collection.GetBytes();
            stream.Write(bytes, 0, bytes.Length);
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
