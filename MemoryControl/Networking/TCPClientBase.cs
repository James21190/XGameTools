using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonToolLib.Networking
{
    public abstract class TCPClientBase
    {
        public delegate void DataRecievedHandler(Packet packet);
        public event DataRecievedHandler OnDataRecieved;
        protected void InvokeOnDataRecieved(Packet packet)
        {
            OnDataRecieved(packet);
        }
    }
}
