using CommonToolLib.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLibTests
{
    [TestClass]
    public class NetworkingTests
    {
        private const string ADDRESS = "localhost";
        private const int SERVER_PORT = 9876;

        [TestMethod]
        public void TestConnect()
        {
            Packet packetToSend = new Packet(5);
            packetToSend.Data = new byte[] { 0, 1, 2, 3, 4, 5 };

            bool recievedData = false;
            var server = new NetworkListener(SERVER_PORT);
            server.OnDataRecieved += (int sender, Packet packet) =>
            {
                if (packetToSend.PacketType == packet.PacketType)
                {
                    if (packetToSend.Data.Length == packet.Data.Length)
                    {
                        for (int i = 0; i < packetToSend.Data.Length; i++)
                        {
                            if (packetToSend.Data[i] != packet.Data[i])
                            {
                                return;
                            }
                        }
                        recievedData = true;
                    }
                }
            };
            var client = NetworkClient.ConnectTo(ADDRESS, SERVER_PORT);
            client.TCPSendData(packetToSend);

            Thread.Sleep(1000);

            client.Close();
            server.Close();


            Assert.IsTrue(recievedData);
        }
    }
}
