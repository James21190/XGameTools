using System;
using System.Net.Sockets;

namespace CommonToolLib.Networking
{
    public abstract class TCPClientBase
    {
        public delegate void DataRecievedHandler(Packet packet);
        public event DataRecievedHandler OnDataRecieved;
        public event UnhandledExceptionEventHandler OnUnhandledException;
        protected void InvokeOnDataRecieved(Packet packet)
        {
            if (OnDataRecieved != null)
            {
                OnDataRecieved(packet);
            }
        }

        protected void InvokeOnUnhandledException(Exception e)
        {
            if (OnUnhandledException != null)
            {
                OnUnhandledException(this, new UnhandledExceptionEventArgs(e, true));
            }
        }

        protected static Packet _GetPacketFromStream(NetworkStream stream)
        {
            _WaitForData(stream);
            var packetType = (byte)stream.ReadByte();
            var packet = new Packet(packetType);
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            var dataLength = BitConverter.ToInt32(buffer, 0);
            packet.Data = new byte[dataLength];
            buffer = new byte[1];
            for (int i = 0; i < dataLength; i++)
            {
                _WaitForData(stream);
                stream.Read(buffer, 0, 1);
                packet.Data[i] = buffer[0];
            }
            return packet;
        }

        private static void _WaitForData(NetworkStream stream)
        {
            while (!stream.DataAvailable)
            {
                ;
            }

            return;
        }
    }
}
