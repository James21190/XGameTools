using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network
{
    /// <summary>
    /// Main interface for sending packets over a network.
    /// </summary>
    public class Client
    {
        private TcpClient m_client;
        private NetworkStream m_networkStream;

        public readonly byte ConnectionID;
        public Client(string IP, int Port, byte ConnectionID)
        {
            m_client = new TcpClient(IP, Port);
            m_networkStream = m_client.GetStream();
            this.ConnectionID = ConnectionID;
        }

        /// <summary>
        /// Send a packet to the connected IP.
        /// </summary>
        /// <param name="packet"></param>
        public void SendData(Packet packet)
        {
            var s = packet.ToByteArray();
            m_networkStream.Write(s.ToArray(),0,(int)s.Length);
            m_networkStream.Flush();
        }

        public void Close()
        {
            m_client.Close();
        }
    }
}
