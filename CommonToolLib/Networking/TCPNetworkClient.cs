using System;
using System.Net.Sockets;
using System.Threading;

namespace CommonToolLib.Networking
{
    /// <summary>
    /// Main interface for sending packets over a network.
    /// </summary>
    public class TCPNetworkClient : TCPClientBase
    {
        private TcpClient _Client;
        private NetworkStream _NetworkStream;
        private Thread _RecieveDataThread;

        /// <summary>
        /// Creates and connects a TCP Client to the given address and port.
        /// Returns true if successful, false if failed or a connection already exists.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool ConnectTo(string address, int port)
        {
            if (_Client != null)
            {
                return false;
            }

            try
            {
                _Client = new TcpClient(address, port);
                _NetworkStream = _Client.GetStream();
                _StartAcceptingData();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Close()
        {
            _StopAcceptingData();
        }

        #region Sending Data
        public void SendData(Packet packet)
        {
            packet.WriteToStream(_NetworkStream);
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
                    if (_NetworkStream.DataAvailable)
                    {
                        var packet = _GetPacketFromStream(_NetworkStream);
                        InvokeOnDataRecieved(0,packet);
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
