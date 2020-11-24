using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using X3_Tool.UI;
using X3_Tool.UI.Bases.CameraBase_Displays;
using X3_Tool.UI.Bases.StoryBase_Displays;
using X3_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3_Tool.UI.Displays;
using X3Tools;
using X3Tools.Bases.CameraBase_Objects;

namespace X3_Tool
{
    public partial class X3ToolForm : Form
    {
        private GameHook GameHook;

        public X3ToolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hook into the game memory
            GameHook = GameHook.DefaultHook();
            while (GameHook == null)
            {
                DialogResult result = MessageBox.Show("X3 is not currently running!\nPlease launch X3R, X3TC, or X3AP and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    //Close();
                    break;
                }
                GameHook = GameHook.DefaultHook();
            }

            Text += " - Game Version: " + GameHook.GameVersion;

            if(GameHook == null)
            {
                GameHookMenuStrip.Enabled = false;
                GameHookPanel.Enabled = false;
            }

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



        private void LoadPlayerShipButton_Click(object sender, EventArgs e)
        {
            X3Tools.Sector_Objects.SectorObjectManager sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.pPlayerShip.obj);
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
            HashTableDisplay display = new HashTableDisplay();
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
                m_CameraBaseDisplay = new CameraBaseDisplay();
                m_CameraBaseDisplay.FormClosed += OnCameraBaseDisplayClosed;
                m_CameraBaseDisplay.Show();
            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraDisplay display = new CameraDisplay();
            display.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "SETA: x" + trackBar1.Value;
            X3Tools.Bases.SystemBase systembase = GameHook.systemBase;
            systembase.SETAValue.Value = trackBar1.Value;
            systembase.SaveSETA();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Maximum = checkBox1.Checked ? 20 : 10;
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
            X3Tools.Sector_Objects.SectorObjectManager sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.GetSpace());
            display.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(GameHook.sectorObjectManager.GetPlayerObject().ScriptingObjectID);
            display.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new GateSystemObjectDisplay().Show();
        }

        private void bodyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BodyDataDisplay().Show();
        }

        private void x86DisassemblerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new x86Disassembler().Show();
        }

        private void ScriptingObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptingObjectDisplay().Show();
        }

        private void scriptObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptingTaskObjectDisplay().Show();
        }

        private void sectorObjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new SectorObjectDisplay().Show();
        }

        private void typeDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new TypeDataDisplay().Show();
        }

        private void scriptingHashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptingHashTableDisplay().Show();
        }

        private void scriptingTextObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptingTextObjectDisplay().Show();
        }

        private void scriptingArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DynamicValueDisplay().Show();
        }

        private void renderObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RenderObjectDisplay().Show();
        }

        private void cameraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CameraDisplay().Show();
        }

        private void bodyDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BodyDataDisplay().Show();
        }

        private void textPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TextPageDisplay().Show();
        }

        private void scriptingDisassemblerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptingDisassemblerDisplay().Show();
        }

        private void dLLInjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogue = new OpenFileDialog();
            dialogue.Filter = "DLL|*.dll";
            if (dialogue.ShowDialog() == DialogResult.OK)
                GameHook.InjectDll(dialogue.FileName);
        }
    }
}
