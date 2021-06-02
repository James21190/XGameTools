using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace CommonToolLib.Network
{
    /// <summary>
    /// Main interface for recieving packets over a network.
    /// </summary>
    public class Listener
    {

        private struct ClientData
        {
            public TcpClient client;
            public int id;
        }
        private TcpListener m_Listener;
        private List<ClientData> m_Clients = new List<ClientData>();
        private int m_Port;
        private int m_NextAvailableID = 0;

        private ClientData GetClient(int id)
        {
            foreach (ClientData client in m_Clients)
            {
                if (client.id == id)
                {
                    return client;
                }
            }

            throw new System.Exception("Client not found.");
        }
        public Listener(int port)
        {
            m_Port = port;
            m_Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), m_Port);
            m_Listener.Start();
        }

        public int ListenForNew()
        {
            TcpClient newClient = m_Listener.AcceptTcpClient();
            m_Clients.Add(new ClientData()
            {
                client = newClient,
                id = m_NextAvailableID++
            });
            return m_NextAvailableID - 1;
        }

        public void SendTo(int id, byte[] data)
        {
            TcpClient client = GetClient(id).client;
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }
}
