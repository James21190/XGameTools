using System.Net;
using System.Net.Sockets;

namespace Common.Network
{
    /// <summary>
    /// Main interface for recieving packets over a network.
    /// </summary>
    public class Listener
    {
        private TcpListener m_Listener;
        private TcpClient[] m_Clients;
        private int m_Port;
        private int m_MaxConnections;
        private int m_NextAvailableID = 0;
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
            TcpClient newClient = m_Listener.AcceptTcpClient();
            int index = m_NextAvailableID++;
            m_Clients[index] = newClient;
            return index;
        }

        public void SendTo(int id, byte[] data)
        {
            TcpClient client = m_Clients[id];
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }
}
