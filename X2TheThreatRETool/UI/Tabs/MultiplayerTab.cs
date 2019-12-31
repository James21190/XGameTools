using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Tools;
using X2Tools.X2.TypeData;
using X2Tools.Network;
using System.ComponentModel;
using X2Tools.X2.SectorObjects;
using System.IO;
using System.Net;
using System.Threading;
using Common.Vector;
using X2Tools.Network.Packet;
using System.Runtime.Serialization.Formatters.Binary;

namespace X2TheThreatRETool
{
    public partial class X2RETool : Form
    {
        private GameNetworkManager m_GNM;
        private void button34_Click(object sender, EventArgs e)
        {
            m_GNM.Start();
            MultiplayerUpdateSender.RunWorkerAsync();
            MultiplayerLogUpdater.Enabled = true;
            PacketSizeSampleReload.Enabled = true;
            button34.Enabled = false;
            button33.Enabled = false;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "")
            {
                richTextBox2.AppendText("Please enter a valid IP.\n");
                return;
            }
            IPAddress address;
            if (IPAddress.TryParse(textBox6.Text, out address))
            {
                m_GNM.Start();
                m_GNM.ConnectTo(IPAddress.Parse(textBox6.Text));
                richTextBox2.Clear();
                MultiplayerUpdateSender.RunWorkerAsync();
                MultiplayerLogUpdater.Enabled = true;
                PacketSizeSampleReload.Enabled = true;
                button34.Enabled = false;
                button33.Enabled = false;
            }
            else
            {
                richTextBox2.AppendText(string.Format("\"{0}\" is not a valid IP!\n", textBox6.Text));
            }
        }

        private void MultiplayerUpdateSender_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(GameNetworkManager.RefreshRate);
                m_GNM.SendUpdate();
            }
        }

        private void MultiplayerLogUpdater_Tick(object sender, EventArgs e)
        {
            richTextBox2.Lines = m_GNM.Log.GetMessages(Common.Logger.MessageSeverity.Debug).Reverse().ToArray();
        }

        const int MaxChartX = 60;
        private void PacketSizeSampleReload_Tick(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Add(m_GNM.BytesSent);
            chart1.Series[1].Points.Add(m_GNM.BytesRecieved);

            double max = 10;
            foreach (var point in chart1.Series[0].Points)
                if (point.YValues[0] > max)
                    max = point.YValues[0];
            foreach (var point in chart1.Series[1].Points)
                if (point.YValues[0] > max)
                    max = point.YValues[0];
            chart1.ChartAreas[0].AxisY.Maximum = max + max/2;

            while (chart1.Series[0].Points.Count > MaxChartX + 1)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
            while (chart1.Series[1].Points.Count > MaxChartX + 1)
            {
                chart1.Series[1].Points.RemoveAt(0);
            }
            m_GNM.ResetData();
        }
    }
}
