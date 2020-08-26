using System;
using System.Net.Sockets;

namespace Common.Network
{
    /// <summary>
    /// Main interface for sending packets over a network.
    /// </summary>
    public class Client
    {
        private TcpClient m_Client;
        /// <summary>
        /// Creates and connects a TCP Client to the given address and port.
        /// Returns true if successful, false if failed or a connection already exists.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool ConnectTo(string address, int port)
        {
            if (m_Client != null)
            {
                return false;
            }

            try
            {
                m_Client = new TcpClient(address, port);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
