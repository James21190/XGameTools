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
using System.IO;

using X3TCTools;
using X3TCTools.Sector_Objects;

namespace ObjectPositionLogger
{
    public partial class Form1 : Form
    {
        private GameHook m_GameHook;
        public Form1()
        {
            InitializeComponent();
            // Hook into the game memory
            var processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            var processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            while (processX3TC == null && processX3AP == null)
            {
                var result = MessageBox.Show("X3TC/X3AP is not currently running!\nPlease launch the game and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    Close();
                    return;
                }
                processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
                processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            }


            if (processX3TC != null)
                m_GameHook = new GameHook(processX3TC, GameHook.GameVersions.X3TC);
            else if (processX3AP != null)
                m_GameHook = new GameHook(processX3AP, GameHook.GameVersions.X3AP);

            this.Text += " - Game Version: " + GameHook.GameVersion;
        }

        const string BaseOutputPath = "./Output/";

        public void LogSector()
        {
            var timeNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            var sector = GameHook.sectorObjectManager.GetSpace();

            var children = sector.GetAllChildren(false);

            foreach(var child in children)
            {
                var dir = BaseOutputPath + child.ObjectType.MainTypeEnum.ToString() + "/";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var text = string.Format("{0},{1},{2},{3}\n",timeNow,child.MetricPosition[0].ToString("F"), child.MetricPosition[1].ToString("F"), child.MetricPosition[2].ToString("F"));
                File.AppendAllText(dir + child.GetSubTypeAsString() + ".csv", text);
            }
            richTextBox1.Text += string.Format("{0}: Logged {1} objects\n", timeNow, children.Length);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogSector();
        }
    }
}
