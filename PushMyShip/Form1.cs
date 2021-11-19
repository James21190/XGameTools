﻿using CommonToolLib.Generics;
using CommonToolLib.Networking;
using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using XCommonLib.RAM;
using XWrapperLib;
using PushMyShip.Packets;
using System.Security.Cryptography;
using System.IO;

namespace PushMyShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private GameHook _GameHook;
        private NetworkClient _NetworkClient;
        private NetworkListener _NetworkListener;

        private bool _IsHost = false;

        private const int _Port = 25565;

        private List<string> _Log = new List<string>();

        private void Log(string txt)
        {
            _Log.Add(txt);
            while (_Log.Count > 100)
                _Log.RemoveAt(0);
        }

        private void DisplayLogs()
        {
            var logs = _Log.ToArray();
            richTextBox1.Text = string.Join("\n", logs.Reverse());
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            btnHost.Enabled = btnConnect.Enabled = txtIP.Enabled = false;
            _NetworkListener = new NetworkListener(_Port);
            _NetworkListener.OnDataRecieved += OnDataRecieved;
            _GameHook = XGameHookFactory.GetGameHook();
            _IsHost = true;
            Log("Hosting on port " + _Port + ".");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _NetworkClient = new NetworkClient();
            if (_NetworkClient.ConnectTo(txtIP.Text, _Port))
            {
                btnHost.Enabled = btnConnect.Enabled = txtIP.Enabled = false;
                btnSend.Enabled = true;
                RequestUpdateTimer.Enabled = true;
                _NetworkClient.OnDataRecieved += OnDataRecieved;
                Log("Connected to " + txtIP.Text + ":" + _Port + ".");
            }
            else
            {
                Log("Failed to connect to " + txtIP.Text + ":" + _Port + ".");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayLogs();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Log("Sending ShipDataPacket...");
            var packet = new DetailedObjectDataPacket();
            packet.Speed = (int)nnudSpeed.Value;
            packet.DesiredSpeed = (int)nnudDesiredSpeed.Value;
            packet.Position = vector3Display1.Vector;
            _NetworkClient.SendData(packet);
        }

        public void OnDataRecieved(Packet packet)
        {
            Log("Recieved packet of type " + (PacketType)packet.PacketType + ".");
            if (_IsHost)
            {
                switch ((PacketType)packet.PacketType)
                {
                    case PacketType.DataRequest:
                        var sectorDataPacket = new SectorDataPacket();
                        var children = _GameHook.SectorBase.GetFirstObjectOfMainType(_GameHook.GetMainTypeID(GameHook.GeneralMainType.Sector)).Meta.GetChildren();
                        sectorDataPacket.SectorObjects = new SectorDataPacket.SectorObjectData[children.Length];
                        for(int i = 0; i < children.Length; i++)
                        {
                            sectorDataPacket.SectorObjects[i] = new SectorDataPacket.SectorObjectData()
                            {
                                ID = children[i].ID,
                                Position = children[i].Position,
                                Race = _GameHook.GetRaceByID(children[i].RaceID)
                            };
                        }
                        _NetworkListener.SendToAll(sectorDataPacket);
                        break;
                    case PacketType.DetailedObjectData:
                        var shipDataPacket = packet.ConvertToPacketType<DetailedObjectDataPacket>();

                        var playerShip = _GameHook.SectorBase.Player;

                        playerShip.Speed = shipDataPacket.Speed;
                        playerShip.DesiredSpeed = shipDataPacket.DesiredSpeed;
                        playerShip.Position = shipDataPacket.Position;

                        playerShip.WriteSafeToMemory();
                        break;
                    default:
                        Log("Recieved unhandled data packet of type " + packet.PacketType + ".");
                        break;
                }
            }
            else
            {
                switch ((PacketType)packet.PacketType)
                {
                    case PacketType.SectorData:
                        sectorMapView1.SectorObjects.Clear();
                        var sectorDataPacket = packet.ConvertToPacketType<SectorDataPacket>();
                        foreach(var item in sectorDataPacket.SectorObjects)
                        {
                            sectorMapView1.SectorObjects.Add
                                (
                                new XCommonLib.UI.Bases.Sector.SectorMapView.SectorObjectPoint()
                                {
                                    X = item.Position.X,
                                    Y = item.Position.Z,
                                    Race = item.Race,
                                    ObjectType = 0
                                }
                                );
                        }
                        sectorMapView1.Draw();
                        break;
                    default:
                        Log("Recieved unhandled data packet of type " + packet.PacketType + ".");
                        break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(_NetworkClient != null)
                _NetworkClient.Close();
            if(_NetworkListener != null)
                _NetworkListener.Close();
        }

        private void RequestUpdateTimer_Tick(object sender, EventArgs e)
        {
            _NetworkClient.SendData(new DataRequestPacket());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var md5 = MD5.Create())
                Text += " Hash:" + String.Join("",md5.ComputeHash(File.ReadAllBytes("./PushMyShip.exe")));
        }
    }
}