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
    public class NetworkListener : ClientBase
    {
        private struct ClientData
        {
            public int ID { get; private set; }
            public NetworkClient Client;

            public ClientData(int id, NetworkClient client, DataRecievedHandler dataRecivedCallback)
            {
                ID = id;
                Client = client;
                _OnDataRecieved = dataRecivedCallback;
                Client.OnDataRecieved += _DataRecieved;
            }

            private DataRecievedHandler _OnDataRecieved;

            private void _DataRecieved(int sender, Packet packet)
            {
                _OnDataRecieved(ID, packet);
            }
        }

        // Thread to listen for new connections
        private Thread _ListeningThread;
        // The listener to accept connections.
        private TcpListener _Listener;
        // List of all connected clients.
        private List<ClientData> _Clients = new List<ClientData>();
        // The port that is opened to communicate.
        private int _Port;
        // The next ID to give to a client.
        private int _NextAvailableID = 1;

        public NetworkListener(int port)
        {
            _Port = port;
            _Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), _Port);
            _Listener.Start();
            _StartAcceptingClients();
        }

        public void Close()
        {
            _StopAcceptingClients();
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
                        _Clients.Add(new ClientData(_NextAvailableID++, new NetworkClient(newClient), InvokeOnDataRecieved));
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
        public void TCPSendToAll(Packet packet)
        {
            _ValidatePacket(packet);
            for (int i = 0; i < _Clients.Count; i++)
            {
                _Clients[i].Client.TCPSendData(packet);
            }
        }
        /// <summary>
        /// Send a byte array the client with the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public void TCPSendTo(int id, Packet packet)
        {
            _ValidatePacket(packet);
            var clientData = _GetClient(id);
            clientData.Client.TCPSendData(packet);
        }
        #endregion
    }
}
