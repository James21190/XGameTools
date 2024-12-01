using System;
using System.Net.Sockets;

namespace CommonToolLib.Networking
{
    public abstract class ClientBase
    {
        public const int MAX_PACKET_TYPE = 250;

        public delegate void DataRecievedHandler(int sender, Packet packet);
        public event DataRecievedHandler OnDataRecieved;
        public event UnhandledExceptionEventHandler OnUnhandledException;
        protected void InvokeOnDataRecieved(int sender, Packet packet)
        {
            if (OnDataRecieved != null)
            {
                OnDataRecieved(sender, packet);
            }
        }
        protected void InvokeOnUnhandledException(Exception e)
        {
            if (OnUnhandledException != null)
            {
                OnUnhandledException(this, new UnhandledExceptionEventArgs(e, true));
            }
        }

        protected void _ValidatePacket(Packet packet)
        {
            if(packet.PacketType > MAX_PACKET_TYPE)
            {
                throw new Exception("PacketTypes above " + MAX_PACKET_TYPE + " are reserved.");
            }
        }

        /// <summary>
        /// Returns the next packet in the network stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>The next packet, or null</returns>
        protected static Packet _GetPacketFromStream(NetworkStream stream)
        {
            if(stream.DataAvailable)
                return Packet.ReadFromStream(stream);
            else
            {
                return null;
            }
        }
    }
}
