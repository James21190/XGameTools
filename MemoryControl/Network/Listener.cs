using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Common.Network
{
    /// <summary>
    /// Main interface for recieving packets over a network.
    /// </summary>
    public class Listener
    {
        TcpListener m_Listener;
        TcpClient[] m_Clients;
        int m_Port;
        int m_MaxConnections;
        int m_NextAvailableID = 0;
        public Listener(int port, int maxConnections)
        {
            m_Port = port;
            m_MaxConnections = maxConnections;
            m_Clients = new TcpClient[maxConnections];


            m_Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), m_Port);
            m_Listener.Start();
        }

        public int ListenForNew()
        {
            var newClient = m_Listener.AcceptTcpClient();
            var index = m_NextAvailableID++;
            m_Clients[index] = newClient;
            return index;
        }

        public void SendTo(int id, byte[] data)
        {
            var client = m_Clients[id];
            var stream = client.GetStream();
            stream.Write(data,0, data.Length);
        }
    }
}
