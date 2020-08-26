using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using X3TC_Tool.UI;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3TC_Tool.UI.Displays;
using X3TCTools;

namespace X3TC_Tool
{
    public partial class X3TCToolForm : Form
    {
        private GameHook GameHook;

        public X3TCToolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hook into the game memory
            Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            Process processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            while (processX3TC == null && processX3AP == null)
            {
                DialogResult result = MessageBox.Show("X3TC/X3AP is not currently running!\nPlease launch the game and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    Close();
                    return;
                }
                processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
                processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            }


            if (processX3TC != null)
            {
                GameHook = new GameHook(processX3TC, GameHook.GameVersions.X3TC);
            }
            else if (processX3AP != null)
            {
                GameHook = new GameHook(processX3AP, GameHook.GameVersions.X3AP);
            }

            Text += " - Game Version: " + GameHook.GameVersion;

            // Post hook
            timer1.Enabled = true;
        }

        private void X3TCToolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            while (Application.OpenForms.Count > 0)
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
            if (m_StoryBaseDisplay == null)
            {
                m_StoryBaseDisplay = new StoryBaseDisplay(GameHook);
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
                m_SectorObjectManagerDisplay = new SectorObjectManagerDisplay(GameHook);
                m_SectorObjectManagerDisplay.FormClosed += OnSectorObjectManagerDisplayClosed;
                m_SectorObjectManagerDisplay.Show();
            }
        }
        #endregion


        private void LoadEventObjectDisplay(object sender, EventArgs e)
        {
            EventObjectDisplay viewer = new EventObjectDisplay();
            viewer.Show();
        }


        private void LoadPlayerShipButton_Click(object sender, EventArgs e)
        {
            X3TCTools.SectorObjects.SectorObjectManager sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.pPlayerShip.obj);
            display.Show();
        }

        private void sectorObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.Show();
        }

        private void typeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDataDisplay display = new TypeDataDisplay();
            display.Show();
        }

        private InputBaseDisplay m_InputBaseDisplay = null;

        public void OnInputBaseDisplayClosed(object sender, EventArgs e)
        {
            m_InputBaseDisplay = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_InputBaseDisplay == null)
            {
                m_InputBaseDisplay = new InputBaseDisplay(GameHook);
                m_InputBaseDisplay.FormClosed += OnInputBaseDisplayClosed;
                m_InputBaseDisplay.Show();
            }
        }

        private void hashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay(GameHook);
            display.Show();
        }

        private CameraBaseDisplay m_CameraBaseDisplay = null;

        public void OnCameraBaseDisplayClosed(object sender, EventArgs e)
        {
            m_CameraBaseDisplay = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_CameraBaseDisplay == null)
            {
                m_CameraBaseDisplay = new CameraBaseDisplay(GameHook);
                m_CameraBaseDisplay.FormClosed += OnCameraBaseDisplayClosed;
                m_CameraBaseDisplay.Show();
            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraDisplay display = new CameraDisplay(GameHook);
            display.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "SETA: x" + trackBar1.Value;
            X3TCTools.Bases.SystemBase systembase = GameHook.systemBase;
            systembase.SETAValue.Value = trackBar1.Value;
            systembase.SaveSETA();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Maximum = checkBox1.Checked ? 20 : 10;
        }

        private void scriptObjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ScriptObjectDisplay display = new ScriptObjectDisplay();
            display.Show();
        }

        private void dynamicValueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DynamicValueArrayDisplay viewer = new DynamicValueArrayDisplay();
            viewer.Show();
        }

        private void scriptingHashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptingHashTableDisplay display = new ScriptingHashTableDisplay();
            display.Show();
        }

        private void scriptingArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dynamicValueObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            X3TCTools.SectorObjects.SectorObject.Main_Type main;
            int sub;
            X3TCTools.SectorObjects.SectorObject.FromFullType(int.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber), out main, out sub);
            string subname = X3TCTools.SectorObjects.SectorObject.GetSubTypeAsString(main, sub);
            textBox2.Text = main.ToString() + "-" + subname;

        }

        private void kCodeViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void textPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextPageDisplay display = new TextPageDisplay(GameHook);
            display.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //// Performance
            //const int max = 100;
            //var blocks = GameHook.pBlocksAllocated.obj.Value;
            //var bytes = GameHook.pBytesAllocated.obj.Value;
            //lblBlocksAllocated.Text = "Blocks Allocated: " + String.Format("{0:n0}", blocks);
            //lblBytesAllocated.Text = "Bytes Allocated: " + String.Format("{0:n0}", bytes);

            //chartPerformance.Series["Blocks Allocated"].Points.Add(blocks);
            //chartPerformance.Series["Bytes Allocated"].Points.Add(bytes);

            //if (chartPerformance.Series["Blocks Allocated"].Points.Count > max) { chartPerformance.Series["Blocks Allocated"].Points.RemoveAt(0); }
            //if(chartPerformance.Series["Bytes Allocated"].Points.Count > max) { chartPerformance.Series["Bytes Allocated"].Points.RemoveAt(0); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            X3TCTools.SectorObjects.SectorObjectManager sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.GetSpace());
            display.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EventObjectDisplay display = new EventObjectDisplay();
            display.LoadObject(GameHook.sectorObjectManager.GetPlayerObject().EventObjectID);
            display.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GateSystemObjectDisplay display = new GateSystemObjectDisplay();
            display.Show();
        }
    }
}
