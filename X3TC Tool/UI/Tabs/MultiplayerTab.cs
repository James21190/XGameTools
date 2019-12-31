using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace X3TC_Tool
{
    public partial class X3TCToolForm
    {
        private void button33_Click(object sender, EventArgs e)
        {
            m_GNM.Start(false);
            m_GNM.ConnectTo(IPAddress.Parse(textBox6.Text));
            MultiplayerUpdater.Enabled = true;
            MultiplayerLogUpdater.Enabled = true;
            button33.Enabled = false;
            button34.Enabled = false;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            m_GNM.Start(true);
            IsHosting = true;
            MultiplayerUpdater.Enabled = true;
            MultiplayerLogUpdater.Enabled = true;
            button33.Enabled = false;
            button34.Enabled = false;
        }

        bool IsHosting = false;

        private void MultiplayerUpdater_Tick(object sender, EventArgs e)
        {
            if(IsHosting || m_GNM.ConnectionID != 0)
                m_GNM.SendData();
        }

        const int MaxChartX = 60;

        private void timer1_Tick(object sender, EventArgs e)
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
            chart1.ChartAreas[0].AxisY.Maximum = max + max / 2;

            while (chart1.Series[0].Points.Count > MaxChartX + 1)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
            while (chart1.Series[1].Points.Count > MaxChartX + 1)
            {
                chart1.Series[1].Points.RemoveAt(0);
            }
            m_GNM.ResetData();

            richTextBox2.Lines = m_GNM.Log.GetMessages( Common.Logger.MessageSeverity.Debug);
        }
    }
}
