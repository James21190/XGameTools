using System;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace CommonToolLib.Networking
{
    /// <summary>
    /// Main interface for sending packets over a network.
    /// </summary>
    public class NetworkClient : ClientBase
    {
        private TcpClient _TCPClient;
        private NetworkStream _TCPNetworkStream;
        private Thread _TCPRecieveDataThread;

        /// <summary>
        /// Creates and connects a TCP Client to the given address and port.
        /// Returns true if successful, false if failed or a connection already exists.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static NetworkClient ConnectTo(string address, int port)
        {

            try
            {
                var client = new NetworkClient(address, port);
                return client;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public NetworkClient(TcpClient tcpClient)
        {
            _TCPClient = tcpClient;
            _TCPNetworkStream = _TCPClient.GetStream();
            _StartAcceptingData();
        }

        private NetworkClient(string address, int port)
        {
            _TCPClient = new TcpClient(address, port);
            _TCPNetworkStream = _TCPClient.GetStream();
            _StartAcceptingData();
        }

        public void Close()
        {
            _StopAcceptingData();
        }

        #region Sending Data
        /// <summary>
        /// Sends a packet to the server.
        /// </summary>
        /// <param name="packet"></param>
        public void TCPSendData(Packet packet)
        {
            _ValidatePacket(packet);
            packet.WriteToStream(_TCPNetworkStream);
        }
        #endregion

        #region Recieving Data
        private void _StartAcceptingData()
        {
            _TCPRecieveDataThread = new Thread(_TCPRecieveData);
            _AcceptingData = true;
            _TCPRecieveDataThread.Start();
        }
        private volatile bool _AcceptingData = false;
        private void _StopAcceptingData()
        {
            _AcceptingData = false;
        }

        private void _TCPRecieveData()
        {
            try
            {
                while (_AcceptingData)
                {
                    var tcpPacket = _GetPacketFromStream(_TCPNetworkStream);
                    if(tcpPacket != null)
                    {
                        InvokeOnDataRecieved(0, tcpPacket);
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
