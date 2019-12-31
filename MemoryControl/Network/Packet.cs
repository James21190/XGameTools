using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Common.Network
{
    /// <summary>
    /// The main packet class used for transmitting data over a network.
    /// Packet types 0, 1, and 2 are reserved.
    /// </summary>
    public class Packet
    {
        public static readonly byte[] Signature = new byte[] { 0x12, 0x34 , 0x17};
        public static readonly int PacketHeaderSize = 6 + Signature.Length;

        public enum BaseType : byte
        {
            ConnectionRequest = 0,
            ConnectionRequestResponce,
            DisconnectionNotice
        }


        /// <summary>
        /// The length of the attached data.
        /// </summary>
        public int Length;
        /// <summary>
        /// The ID of the sender
        /// </summary>
        public byte ConnectionID;
        /// <summary>
        /// The type of data being sent
        /// </summary>
        public byte DataType;
        /// <summary>
        /// The data to be sent.
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// A flag that can be used to inform subscribers to events that the data has been handled.
        /// </summary>
        public bool Handled = false;

        #region Constructors
        public Packet(byte ConnectionID)
        {
            this.ConnectionID = ConnectionID;
        }
        public Packet(byte ConnectionID, ITransmittable transmittable)
        {
            this.ConnectionID = ConnectionID;
            Data = transmittable.GetBytes();
            this.DataType = transmittable.GetDataType();
            Length = Data.Length;

            if (this.DataType == 0)
                Console.WriteLine();

        }
        #endregion

        /// <summary>
        /// Converts a byte array into a Packet object.
        /// </summary>
        /// <param name="Data"></param>
        public void FromByteArray(byte[] Data)
        {
            var collection = new Memory.ObjectByteList();


            collection.SetData(Data);
            byte[] sig = new byte[Packet.Signature.Length];
            collection.PopFirst(ref sig);
            if (!sig.SequenceEqual(Signature))
                throw new ArgumentException();
            collection.PopFirst(ref Length);
            collection.PopFirst(ref DataType);
            collection.PopFirst(ref ConnectionID);
            collection.PopRemaining(ref Data);
        }

        /// <summary>
        /// Converts the packet into a byte array for transmission.
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            var collection = new Memory.ObjectByteList();
            collection.Append(Signature);
            collection.Append(Length);
            collection.Append(DataType);
            collection.Append(ConnectionID);
            collection.Append(Data);
            return collection.GetBytes();
        }

        public void ToObject<T>(ref T obj ) where T : ITransmittable
        {
            obj.SetData(Data);
        }

        public static Packet GetConnectionRequestPacket()
        {
            return new Packet(0, new ConnectionRequestPacket());
        }

        public static Packet GetConnectionRequestResponcePacket(byte connectionID)
        {
            return new Packet(0, new ConnectionRequestResponcePacket(connectionID));
        }

        #region Packet Templates
        public class ConnectionRequestPacket : ITransmittable
        {
            public byte[] GetBytes()
            {
                return new byte[0];
            }

            public int GetByteSize()
            {
                return 0;
            }

            public byte GetDataType()
            {
                return (byte)Packet.BaseType.ConnectionRequest;
            }

            public void SetData(byte[] Memory)
            {
                throw new NotSupportedException();
            }
        }

        public class ConnectionRequestResponcePacket : ITransmittable
        {
            public byte ConnectionID;
            public ConnectionRequestResponcePacket(byte ConnectionID)
            {
                this.ConnectionID = ConnectionID;
            }
            public byte[] GetBytes()
            {
                return new byte[1] { ConnectionID }; 
            }

            public int GetByteSize()
            {
                return 1;
            }

            public byte GetDataType()
            {
                return (byte)Packet.BaseType.ConnectionRequestResponce;
            }

            public void SetData(byte[] Memory)
            {
                ConnectionID = Memory[0];
            }
        }
        #endregion
    }
}
