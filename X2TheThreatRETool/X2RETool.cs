using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Tools;
using X2Tools.X2;
using X2Tools.X2.TypeData;
using X2Tools.X2.SectorObjects;
using System.Diagnostics;
using System.IO;
using X2Tools.Network.Packet;
using Common.Vector;
using X2Tools.Network;

namespace X2TheThreatRETool
{
    public partial class X2RETool : Form
    {
        #region Private Fields
        GameHook m_GameHook;
        #endregion
        public X2RETool()
        {
            InitializeComponent();
        }
        private void X2RETool_Load(object sender, EventArgs e)
        {
            // Hook into the game memory
            var process = Process.GetProcessesByName("X2").FirstOrDefault();
            while(process == null)
            {
                var result = MessageBox.Show("X2 is not currently running!\nPlease launch X2 and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    Close();
                    return;
                }
                process = Process.GetProcessesByName("X2").FirstOrDefault();
            }
            m_GameHook = new GameHook(process);
            m_GNM = new GameNetworkManager(m_GameHook,25565);
            ReloadUI();
            ReloadSubscriptionTable();

            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.ChartAreas[0].AxisX.Maximum = MaxChartX;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
        }

        private void ReloadUI()
        {
            // TypeData Tab
            comboBox1.Items.Clear();
            for(int i = 0; i < SectorObject.SHIP_SUBTYPE_COUNT; i++)
            {
                comboBox1.Items.Add(((SectorObject.Ship_Sub_Type)i).ToString());
            }

            comboBox2.Items.Clear();
            for(int i = 0; i < ShipTypeData.SHIP_CLASS_COUNT; i++)
            {
                comboBox2.Items.Add(((ShipTypeData.ShipClass)i).ToString());
            }

            comboBox3.Items.Clear();
            for (int i = 0; i < ShipTypeData.CONTAINER_SIZE_COUNT; i++)
            {
                comboBox3.Items.Add(((ShipTypeData.ContainerSize)i).ToString());
            }

            comboBox4.Items.Clear();
            for (int i = 0; i < SectorObject.SHIELD_SUBTYPE_COUNT; i++)
            {
                comboBox4.Items.Add(((SectorObject.Shield_Sub_Type)i).ToString());
            }

            comboBox5.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                comboBox5.Items.Add(((Race.RaceID)i).ToString());
            }

            comboBox6.Items.Clear();
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                comboBox6.Items.Add(((SectorObject.Main_Type)i).ToString());
            }

            // Sector Object Tab


            comboBox7.Items.Clear();
            for (int i = 0; i < Race.RACE_COUNT; i++)
            {
                comboBox7.Items.Add(((Race.RaceID)i).ToString());
            }
        }

        private void X2RETool_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_GNM != null)
                m_GNM.Close();
        }
    }
}
