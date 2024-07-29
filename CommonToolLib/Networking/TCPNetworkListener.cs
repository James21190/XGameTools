using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommonToolLib.Networking
{
    /// <summary>
    /// Main interface for recieving packets over a network.
    /// </summary>
    public class TCPNetworkListener : TCPClientBase
    {
        private struct ClientData
        {
            public int ID { get; private set; }
            public TcpClient Client { get; private set; }
            public NetworkStream NetworkStream { get; private set; }

            public ClientData(int id, TcpClient client)
            {
                ID = id;
                Client = client;
                NetworkStream = Client.GetStream();
            }
        }

        // Thread to listen for new connections
        private Thread _ListeningThread;
        // Thread for recieving data
        private Thread _RecieveDataThread;
        // The listener to accept connections.
        private TcpListener _Listener;
        // List of all connected clients.
        private List<ClientData> _Clients = new List<ClientData>();
        // The port that is opened to communicate.
        private int _Port;
        // The next ID to give to a client.
        private int _NextAvailableID = 0;

        public TCPNetworkListener(int port)
        {
            _Port = port;
            _Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), _Port);
            _Listener.Start();
            _StartAcceptingClients();
            _StartAcceptingData();
        }

        public void Close()
        {
            _StopAcceptingClients();
            _StopAcceptingData();
        }

        #region Manage Connections
        /// <summary>
        /// Start a thread to listen for new connections.
        /// </summary>
        private void _StartAcceptingClients()
        {
            _ListeningThread = new Thread(_ListenForNew);
            _AcceptingClients = true;
            _ListeningThread.Start();
        }

        /// <summary>
        /// Terminate the thread that is listening for new connections.
        /// </summary>
        private void _StopAcceptingClients()
        {
            _AcceptingClients = false;
        }
        private volatile bool _AcceptingClients = false;

        private void _ListenForNew()
        {
            try
            {

                while (_AcceptingClients)
                {
                    if (_Listener.Pending())
                    {
                        TcpClient newClient = _Listener.AcceptTcpClient();
                        _Clients.Add(new ClientData(_NextAvailableID++, newClient));
                    }
                }
            }
            catch (Exception e)
            {
                InvokeOnUnhandledException(e);
            }
        }
        #endregion
        private ClientData _GetClient(int id)
        {
            foreach (ClientData client in _Clients)
            {
                if (client.ID == id)
                {
                    return client;
                }
            }

            throw new Exception("Client not found.");
        }

        #region Sending Data
        /// <summary>
        /// Send a packet
        /// </summary>
        /// <param name="data"></param>
        public void SendToAll(Packet packet)
        {
            for (int i = 0; i < _Clients.Count; i++)
            {
                packet.WriteToStream(_Clients[i].NetworkStream);
            }
        }
        /// <summary>
        /// Send a byte array the client with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public void SendTo(int id, Packet packet)
        {
            var clientData = _GetClient(id);
            packet.WriteToStream(clientData.NetworkStream);
        }
        #endregion

        #region Recieving Data
        private void _StartAcceptingData()
        {
            _RecieveDataThread = new Thread(_RecieveData);
            _AcceptingData = true;
            _RecieveDataThread.Start();
        }
        private volatile bool _AcceptingData = false;
        private void _StopAcceptingData()
        {
            _AcceptingData = false;
        }
        private void _RecieveData()
        {
            try
            {
                while (_AcceptingData)
                {
                    for (int i = 0; i < _Clients.Count; i++)
                    {
                        var client = _Clients[i];
                        var stream = client.NetworkStream;
                        if (stream.DataAvailable)
                        {
                            var packet = _GetPacketFromStream(stream);
                            InvokeOnDataRecieved(client.ID,packet);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                InvokeOnUnhandledException(e);
            }
        }
        #endregion
    }
}
