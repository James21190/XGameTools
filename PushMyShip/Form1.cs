using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using XCommonLib.RAM;
using XWrapperLib;

namespace PushMyShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private struct ShipData : IBinaryObject
        {
            public int Speed;
            public int DesiredSpeed;

            public int ByteSize => 8;

            public void SetData(byte[] Memory)
            {
                var collection = new ObjectByteList(Memory);
                Speed = collection.PopInt();
                DesiredSpeed = collection.PopInt();
            }

            public byte[] GetBytes()
            {
                var collection = new ObjectByteList();
                collection.Append(Speed);
                collection.Append(DesiredSpeed);
                return collection.GetBytes();
            }

            public override string ToString()
            {
                return string.Format(
                    "Speed: {0}\n" +
                    "DesiredSpeed: {1}"
                    , Speed, DesiredSpeed);
            }
        }

        private GameHook _GameHook;
        private TcpClient _ClientConnector;

        private bool _ShouldClose = false;

        private const int _Port = 25565;

        private List<string> _Log = new List<string>();

        private void Log(string txt)
        {
            _Log.Add(txt);
        }

        private void DisplayLogs()
        {
            var logs = _Log.ToArray();
            logs.Reverse();
            richTextBox1.Text = string.Join("\n", logs);
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = btnHost.Enabled = false;
            _GameHook = GameHookFactory.GetGameHook();
            var listener = new TcpListener(_Port);
            Log("Hosting on port " + _Port + ".");
            listener.Start();
            _ClientConnector = listener.AcceptTcpClient();
            bgwHostProcess.RunWorkerAsync();
            var stream = _ClientConnector.GetStream();
            byte[] data = new byte[5] { 4, 3, 2, 1, 0 };
            stream.Write(data, 0, 5);
        }

        private void bgwHostProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            Log("Client connected.");
            var stream = _ClientConnector.GetStream();

            while (!_ShouldClose)
            {
                if (stream.DataAvailable)
                {
                    var data = new ShipData();
                    byte[] buffer = new byte[data.ByteSize];
                    stream.Read(buffer, 0, buffer.Length);
                    data.SetData(buffer);
                    Log("Recieved data:\n" + data);

                    var playership = _GameHook.SectorBase.Player;
                    playership.Speed = data.Speed;
                    playership.DesiredSpeed = data.DesiredSpeed;

                    playership.WriteSafeToMemory();
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = btnHost.Enabled = false;
            Log("Connecting to " + txtIP.Text + ":" + _Port + ".");
            _ClientConnector = new TcpClient(txtIP.Text, _Port);
            bgwHostProcess.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayLogs();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var stream = _ClientConnector.GetStream();
            var data = new ShipData()
            {
                Speed = (int)nnudSpeed.Value,
                DesiredSpeed = (int)nnudDesiredSpeed.Value
            };
            stream.Write(data.GetBytes(), 0, data.ByteSize);
        }
    }
}
