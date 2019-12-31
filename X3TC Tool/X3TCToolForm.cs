using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3TCTools;
using X3TCTools.Network;

namespace X3TC_Tool
{
    public partial class X3TCToolForm : Form
    {
        private GameHook m_GameHook;
        private GameNetworkManager m_GNM;

        private static int Port = 25565;

        public X3TCToolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hook into the game memory
            var process = Process.GetProcessesByName("X3TC").FirstOrDefault();
            while (process == null)
            {
                var result = MessageBox.Show("X3TC is not currently running!\nPlease launch X3TC and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    Close();
                    return;
                }
                process = Process.GetProcessesByName("X3TC").FirstOrDefault();
            }
            m_GameHook = new GameHook(process);
            m_GNM = new GameNetworkManager(m_GameHook, Port);

            ReloadSectorObjectUI();
            ReloadSubscriptionTable();
            ReloadGeneralTab();
            ReloadOtherTabUI();
            LoadSector(0, 0);

            dataGridView3.Columns.Add("xy", "xy");
            dataGridView3.Columns[0].Width = 30;

            for (int i = 0; i < X3TCTools.Bases.GateSystemObject.width; i++)
            {
                dataGridView3.Columns.Add(i.ToString(), i.ToString());
                dataGridView3.Columns[i + 1].Width = 80;
            }

            for (short y = 0; y < X3TCTools.Bases.GateSystemObject.height; y++)
            {
                var races = new GameHook.RaceID[X3TCTools.Bases.GateSystemObject.width];
                var names = new string[X3TCTools.Bases.GateSystemObject.width + 1];
                names[0] = y.ToString();
                for (short x = 0; x < X3TCTools.Bases.GateSystemObject.width; x++)
                {
                    races[x] = m_GameHook.gateSystemObject.GetSector(x, y).owner;
                    var name = m_GameHook.gateSystemObject.GetSectorName(x, y);
                    names[x + 1] = name;
                }
                dataGridView3.Rows.Add(names);

                for (int i = 0; i < X3TCTools.Bases.GateSystemObject.width; i++)
                {
                    var colorStyle = new DataGridViewCellStyle();
                    switch (races[i])
                    {
                        case GameHook.RaceID.Argon: colorStyle.BackColor = Color.LightBlue; break;
                        case GameHook.RaceID.Boron: colorStyle.BackColor = Color.Aqua; break;
                        case GameHook.RaceID.Split: colorStyle.BackColor = Color.OrangeRed; break;
                        case GameHook.RaceID.Teladi: colorStyle.BackColor = Color.ForestGreen; break;
                        case GameHook.RaceID.Paranid: colorStyle.BackColor = Color.Orange; break;
                        case GameHook.RaceID.Terran: colorStyle.BackColor = Color.Aquamarine; break;
                        case GameHook.RaceID.Pirate: colorStyle.BackColor = Color.MediumVioletRed; break;
                        case GameHook.RaceID.Yaki: colorStyle.BackColor = Color.IndianRed; break;
                        case GameHook.RaceID.Khaak: colorStyle.BackColor = Color.MediumPurple; break;
                        case GameHook.RaceID.Xenon: colorStyle.BackColor = Color.Red; break;
                        case GameHook.RaceID.Unknown: colorStyle.BackColor = Color.LightGray; break;
                        case GameHook.RaceID.Gonor: colorStyle.BackColor = Color.Yellow; break;
                        case GameHook.RaceID.NA: colorStyle.BackColor = Color.Black; break;
                        default: colorStyle.BackColor = Color.White; break;
                    }
                    dataGridView3.Rows[y].Cells[i + 1].Style = colorStyle;
                }
            }

            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.ChartAreas[0].AxisX.Maximum = MaxChartX;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
        }

        private void X3TCToolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_GNM != null)
                m_GNM.Close();
        }

        
    }
}
