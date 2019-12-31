using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Common.Network
{
    /// <summary>
    /// The base class for a network manager.
    /// Handles connection requests and disconnection notices.
    /// Can send packets to all or select clients.
    /// </summary>
    public abstract class NetworkManager
    {
        /// <summary>
        /// Main delegate for recieving packets
        /// </summary>
        /// <param name="packet"></param>
        public delegate void PacketRecievedHandler(Packet packet);
        
        public Logger Log = new Logger();


        #region Private Fields
        private byte m_LastConnectionID = 1;
        private readonly int m_Port;
        private readonly Listener m_Listener;
        private readonly List<Client> m_Clients;
        #endregion
        public byte ConnectionID { private set; get; } = 0;
        public long BytesSent = 0;
        public long BytesRecieved = 0;
        public bool ConnectionIDIsLocked = false;

        #region Constructors and Destructors
        public NetworkManager(int port)
        {
            m_Port = port;
            m_Listener = new Listener(port);
            m_Clients = new List<Client>();
            m_Listener.OnObjectRecieved += ConnectionHandling;
            m_Listener.OnObjectRecieved += OnPacketRecieved;
        }

        ~NetworkManager()
        {
            Close();
        }
        #endregion


        #region Abstract Methods
        /// <summary>
        /// Called when a packet is recieved.
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="sender"></param>
        protected abstract void OnPacketRecieved(Packet packet, IPAddress sender);
        #endregion

        #region Private Methods
        private void ConnectionHandling(Packet packet, IPAddress sender)
        {
            BytesRecieved += packet.Length;

            if (packet.ConnectionID == 0)
            {
                switch (packet.DataType)
                {
                    case (byte)Packet.BaseType.ConnectionRequest:
                        Log.AppendMessage(string.Format("Recieved connection request from {0}.", sender.ToString()), Logger.MessageSeverity.Debug);
                        ReplyToConnectionRequest(sender);
                        break;
                    case (byte)Packet.BaseType.ConnectionRequestResponce:
                        if(ConnectionIDIsLocked)
                        {
                            Log.AppendMessage(string.Format("Recieved connection request response from {0}, but connectionID is locked.", sender.ToString()),Logger.MessageSeverity.Error);
                            break;
                        }
                        ConnectionID = packet.Data[0];
                        Log.AppendMessage(string.Format("Recieved connection request response from {0}, given connection id {1}.", sender.ToString(), ConnectionID), Logger.MessageSeverity.Debug);
                        ConnectionIDIsLocked = true;
                        break;
                    default: return;
                }
            }
            else
            {
                switch (packet.DataType)
                {
                    case (byte)Packet.BaseType.DisconnectionNotice:
                        break;
                    default: return;
                }
            }

            packet.Handled = true;
        }

        private Client LocalConnect(IPAddress iP, byte connectionID)
        {
            var client = new Client(iP.ToString(), m_Port, connectionID);
            return client;
        }

        private byte GetNextFreeConnectionID()
        {
            if (m_Clients.Count >= byte.MaxValue - 1)
                throw new Exception("Maximum number of clients reached.");
            foreach(var item in m_Clients)
            {
                if(item.ConnectionID == m_LastConnectionID)
                {
                    if (m_LastConnectionID == byte.MaxValue)
                        m_LastConnectionID = 1;
                    else
                        m_LastConnectionID++;
                    return GetNextFreeConnectionID();
                    
                }
            }
            return m_LastConnectionID;
        }

        /// <summary>
        /// Open a connection in respoce to a ConnectionRequestPacket.
        /// </summary>
        /// <param name="iP"></param>
        private void ReplyToConnectionRequest(IPAddress iP)
        {
            // Get next available connection ID
            byte connectionID = GetNextFreeConnectionID();
            var client = LocalConnect(iP, connectionID);
            var reply = Packet.GetConnectionRequestResponcePacket(connectionID);
            reply.Data[0] = connectionID;
            SendToClient(client, reply, true);
            m_Clients.Add(client);
        }

        #endregion

        #region Public Methods

        public void ResetData()
        {
            BytesSent = 0;
            BytesRecieved = 0;
        }

        public void Start(bool IsHosting)
        {
            ConnectionIDIsLocked = IsHosting;
            m_Listener.Start();
            Log.AppendMessage("Started listener.", Logger.MessageSeverity.Debug);
        }

        public void Close()
        {
            m_Listener.Close();
            foreach (var client in m_Clients)
            {
                client.Close();
            }
            Log.AppendMessage("Closed all clients.", Logger.MessageSeverity.Debug);
        }

        private void SendToClient(Client client, Packet packet, bool SendingProtectedType = false)
        {
            if (!SendingProtectedType)
            {
                if (packet.DataType < 3)
                    throw new Exception("Attempted to send protected packet type.");
            }
            BytesSent += packet.Length;
            client.SendData(packet);
        }

        public void SendPacketToAll(Packet packet)
        {
            foreach (var client in GetAllClients())
                SendToClient(client,packet);
        }
        
        private Client[] GetAllClients()
        {
            return m_Clients.ToArray();
        }

        /// <summary>
        /// Open a connection to an ip and send a connection request.
        /// </summary>
        /// <param name="iP"></param>

        public void ConnectTo(IPAddress iP)
        {
            Log.AppendMessage(string.Format("Connecting to {0}.", iP.ToString()), Logger.MessageSeverity.Message);
            var client = LocalConnect(iP, 0);
            SendToClient(client,Packet.GetConnectionRequestPacket(), true);
            m_Clients.Add(client);
        }


        public void Disconnect(byte ConnectionID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
