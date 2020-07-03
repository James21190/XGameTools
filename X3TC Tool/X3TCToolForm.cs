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

using X3TC_Tool.UI.Displays;
using X3TC_Tool.UI;

namespace X3TC_Tool
{
    public partial class X3TCToolForm : Form
    {
        private GameHook m_GameHook;

        public X3TCToolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hook into the game memory
            var processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            //var processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            while (processX3TC == null)
            {
                var result = MessageBox.Show("X3TC is not currently running!\nPlease launch X3TC and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    Close();
                    return;
                }
                processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
                //processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            }


            if (processX3TC != null)
                m_GameHook = new GameHook(processX3TC, GameHook.GameVersion.X3TC);
            //else if (processX3AP != null)
            //    m_GameHook = new GameHook(processX3AP, GameHook.GameVersion.X3AP);

            //this.Text += " - Game Version: " + m_GameHook.gameVersion;
        }

        private void X3TCToolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            while(Application.OpenForms.Count > 0)
            {
                Application.OpenForms[0].Close();
            }
        }

        #region Base Viewers
        private StoryBaseDisplay m_StoryBaseDisplay;
        private void OnStoryBaseDisplayClosed(object sender, EventArgs e)
        {
            m_StoryBaseDisplay = null;
        }
        private void LoadStoryBaseDisplay(object sender, EventArgs e)
        {
            if(m_StoryBaseDisplay == null)
            {
                m_StoryBaseDisplay = new StoryBaseDisplay(m_GameHook);
                m_StoryBaseDisplay.FormClosed += OnStoryBaseDisplayClosed;
                m_StoryBaseDisplay.Show();
            }
        }

        private SectorObjectManagerDisplay m_SectorObjectManagerDisplay;
        private void OnSectorObjectManagerDisplayClosed(object sender, EventArgs e)
        {
            m_SectorObjectManagerDisplay = null;
        }
        private void LoadSectorObjectManagerDisplay(object sender, EventArgs e)
        {
            if (m_SectorObjectManagerDisplay == null)
            {
                m_SectorObjectManagerDisplay = new SectorObjectManagerDisplay(m_GameHook);
                m_SectorObjectManagerDisplay.FormClosed += OnSectorObjectManagerDisplayClosed;
                m_SectorObjectManagerDisplay.Show();
            }
        }
        #endregion


        private void LoadEventObjectDisplay(object sender, EventArgs e)
        {
            var viewer = new EventObjectDisplay(m_GameHook);
            viewer.Show();
        }


        private void LoadPlayerShipButton_Click(object sender, EventArgs e)
        {
            var sectorObjectManager = m_GameHook.sectorObjectManager;
            var display = new SectorObjectDisplay(m_GameHook);
            display.LoadObject(sectorObjectManager.pPlayerShip.obj);
            display.Show();
        }

        private void sectorObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new SectorObjectDisplay(m_GameHook);
            display.Show();
        }

        private void typeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new TypeDataDisplay(m_GameHook);
            display.Show();
        }

        InputBaseDisplay m_InputBaseDisplay = null;

        public void OnInputBaseDisplayClosed(object sender, EventArgs e)
        {
            m_InputBaseDisplay = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_InputBaseDisplay == null)
            {
                m_InputBaseDisplay = new InputBaseDisplay(m_GameHook);
                m_InputBaseDisplay.FormClosed += OnInputBaseDisplayClosed;
                m_InputBaseDisplay.Show();
            }
        }

        private void hashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new HashTableDisplay(m_GameHook);
            display.Show();
        }

        CameraBaseDisplay m_CameraBaseDisplay = null;

        public void OnCameraBaseDisplayClosed(object sender, EventArgs e)
        {
            m_CameraBaseDisplay = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_CameraBaseDisplay == null)
            {
                m_CameraBaseDisplay = new CameraBaseDisplay(m_GameHook);
                m_CameraBaseDisplay.FormClosed += OnCameraBaseDisplayClosed;
                m_CameraBaseDisplay.Show();
            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new CameraDisplay(m_GameHook);
            display.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "SETA: x" + trackBar1.Value;
            var systembase = m_GameHook.systemBase;
            systembase.SETAValue.Value = trackBar1.Value;
            systembase.SaveSETA();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Maximum = checkBox1.Checked ? 20 : 10;
        }

        private void scriptObjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var display = new ScriptObjectDisplay(m_GameHook);
            display.Show();
        }

        private void dynamicValueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var viewer = new DynamicValueArrayDisplay(m_GameHook);
            viewer.Show();
        }

        private void scriptingHashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new ScriptingHashTableDisplay(m_GameHook);
            display.Show();
        }

        private void scriptingArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dynamicValueObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new DynamicValueObjectDisplay(m_GameHook);
            display.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            X3TCTools.SectorObjects.SectorObject.Main_Type main;
            int sub;
            X3TCTools.SectorObjects.SectorObject.FromFullType(int.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber),out main, out sub);
            var subname = X3TCTools.SectorObjects.SectorObject.GetSubTypeAsString(main, sub);
            textBox2.Text = main.ToString() + "-" + subname;

        }

        private void kCodeViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new KCodeViewer(m_GameHook);
            display.Show();
        }

        private void textPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new TextPageDisplay(m_GameHook);
            display.Show();
        }
    }
}
