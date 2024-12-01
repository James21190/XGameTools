using CommonToolLib.Generics.BinaryObjects;
using CommonToolLib.ProcessHooking;
using System;
using System.Net.Sockets;

namespace CommonToolLib.Networking
{
    /// <summary>
    /// Basic object for sending identifiable data.
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

        /// <summary>
        /// Method to write data to a network stream
        /// </summary>
        /// <param name="stream"></param>
        internal void WriteToStream(NetworkStream stream)
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

        internal static Packet ReadFromStream(NetworkStream stream)
        {
            var packetType = (byte)stream.ReadByte();
            var packet = new Packet(packetType);
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            var dataLength = BitConverter.ToInt32(buffer, 0);
            packet.Data = new byte[dataLength];
            buffer = new byte[1];
            for (int i = 0; i < dataLength; i++)
            {
                stream.Read(buffer, 0, 1);
                packet.Data[i] = buffer[0];
            }

            return packet;
        }

        public IBinaryObject ToBinaryObject<T>() where T : IBinaryObject, new()
        {
            var result = new T();
            int bytesConsumed;
            result.SetData(Data, out bytesConsumed);
            return result;
        }

        public void FromBinaryObject(IBinaryObject binaryObject)
        {
            Data = binaryObject.GetBytes();
        }
    }
}
