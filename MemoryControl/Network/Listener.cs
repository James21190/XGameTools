using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Common.Network
{
    /// <summary>
    /// Main interface for recieving packets over a network.
    /// </summary>
    public class Listener
    {
        public delegate void ObjectRecieved(Packet packet, IPAddress SenderIP);
        public event ObjectRecieved OnObjectRecieved;
        private TcpListener m_Listener;
        private List<TcpClient> m_Listeners = new List<TcpClient>();
        private bool m_Stop;

        private Thread m_ListeningThread;

        public Listener(int Port)
        {
            m_Listener = new TcpListener(IPAddress.Parse("0.0.0.0"), Port);
        }

        public void Start()
        {
            m_Stop = false;
            m_Listener.Start();
            m_ListeningThread = new Thread(Check);
            m_ListeningThread.Start();
        }

        public void Close()
        {
            m_Stop = true;
            m_Listener.Stop();
            foreach (var item in m_Listeners)
                item.Close();
        }

        private void Check()
        {
            while (!m_Stop)
            {
                try
                {
                    var listener = m_Listener.AcceptTcpClient();
                    m_Listeners.Add(listener);
                    new Thread(() => HandleClient(listener)).Start();
                }
                catch (Exception)
                {

                }
            }
        }

        private void HandleClient(TcpClient listener)
        {
            NetworkStream stream = null;
            while (!m_Stop)
            {
                if (listener.Connected)
                {

                    if (stream == null)
                        stream = listener.GetStream();
                    var ip = (((IPEndPoint)listener.Client.RemoteEndPoint).Address);

                    if (stream.DataAvailable)
                    {
                        while (listener.Available == 0)
                        {
                            Thread.Sleep(10);
                        }
                        var packet = new Packet(0);
                        var collection = new Memory.ObjectByteList();

                        var header = new byte[Packet.PacketHeaderSize];

                        stream.Read(header, 0, Packet.PacketHeaderSize);
                        collection.Append(header);
                        byte[] sig = new byte[Packet.Signature.Length];
                        collection.PopFirst(ref sig);
                        if (sig.SequenceEqual(Packet.Signature))
                        {

                            collection.PopFirst(ref packet.Length);
                            collection.PopFirst(ref packet.DataType);
                            collection.PopFirst(ref packet.ConnectionID);

                            var data = new byte[packet.Length];
                            if (packet.Length > 0)
                                stream.Read(data, 0, packet.Length);
                            packet.Data = data;



                            if (OnObjectRecieved != null)
                                OnObjectRecieved(packet, ip);
                        }

                    }
                }
            }
        }
    }
}
