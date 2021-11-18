using System;
using System.Net.Sockets;
using System.Threading;

namespace CommonToolLib.Networking
{
    /// <summary>
    /// Main interface for sending packets over a network.
    /// </summary>
    public class NetworkClient : TCPClientBase
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Sending Data
        public void SendData(Packet packet)
        {
            packet.WriteToStream(_NetworkStream);
        }
        #endregion

        #region Recieving Data
        public void StartAcceptingData()
        {
            _RecieveDataThread = new Thread(_RecieveData);
            _RecieveDataThread.Start();
        }
        public void StopAcceptingData()
        {
            _RecieveDataThread.Abort();
        }
        private void _RecieveData()
        {
            while (_RecieveDataThread.ThreadState != ThreadState.Aborted)
            {
                if (_NetworkStream.DataAvailable)
                {
                    var packet = Packet.ReadPacketFromStream(_NetworkStream);
                    InvokeOnDataRecieved(packet);
                }
            }
        }
        #endregion
    }
}
