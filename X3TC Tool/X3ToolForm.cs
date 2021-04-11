using System;
using System.Windows.Forms;
using X3TC_RAM_Tool.UI;
using X3TC_RAM_Tool.UI.Bases.CameraBase_Displays;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3TC_RAM_Tool.UI.Displays;
using X3TC_RAM_Tool.UI.Bases.SystemBase_Displays;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Sector;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Bases.SystemBase_Objects;

namespace X3TC_RAM_Tool
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
                DialogResult result = MessageBox.Show("X3 is not currently running!\nPlease launch X3R nosteam, X3TC, or X3AP and retry.", "Game not running", MessageBoxButtons.RetryCancel);
                if (result != DialogResult.Retry)
                {
                    Close();
                    break;
                }
                GameHook = GameHook.DefaultHook();
            }

            Text += " - Game Version: " + GameHook.GameVersion;

            if (GameHook == null)
            {
                GameHookMenuStrip.Enabled = false;
                dLLInjectToolStripMenuItem.Enabled = false;
                GameHookPanel.Enabled = false;
                return;
            }

            // Post hook
            timer1.Enabled = true;

            for (int i = 0; i < 100; i++)
            {
                GameHook.Language currentLanguage = GameHook.systemBase.Language;
                if (((GameHook.Language)i).ToString() != i.ToString())
                {
                    int index = cbLanguage.Items.Add(((GameHook.Language)i));
                    if (((GameHook.Language)i) == currentLanguage)
                    {
                        cbLanguage.SelectedIndex = index;
                    }
                }
            }
        }

        private void X3TCToolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            while (Application.OpenForms.Count > 0)
            {
                Application.OpenForms[0].Close();
            }
        }

        #region Buttons

        #region Bases

        #region Story
        private StoryBaseDisplay m_StoryBaseDisplay;
        private void btnStoryBase_Click(object sender, EventArgs e)
        {
            if (m_StoryBaseDisplay == null)
            {
                m_StoryBaseDisplay = new StoryBaseDisplay();
                m_StoryBaseDisplay.FormClosed += OnStoryBaseDisplayClosed;
                m_StoryBaseDisplay.Show();
            }
        }
        private void OnStoryBaseDisplayClosed(object sender, EventArgs e)
        {
            m_StoryBaseDisplay = null;
        }
        #endregion

        #region Sector
        private SectorObjectManagerDisplay m_SectorObjectManagerDisplay;
        private void btnSectorObjectManager_Click(object sender, EventArgs e)
        {
            if (m_SectorObjectManagerDisplay == null)
            {
                m_SectorObjectManagerDisplay = new SectorObjectManagerDisplay(GameHook);
                m_SectorObjectManagerDisplay.FormClosed += OnSectorObjectManagerDisplayClosed;
                m_SectorObjectManagerDisplay.Show();
            }
        }
        private void OnSectorObjectManagerDisplayClosed(object sender, EventArgs e)
        {
            m_SectorObjectManagerDisplay = null;
        }
        #endregion

        #region System
        private SystemBaseDisplay m_SystemBaseDisplay = null;
        private void btnSystemBase_Click(object sender, EventArgs e)
        {
            if (m_SystemBaseDisplay == null)
            {
                m_SystemBaseDisplay = new SystemBaseDisplay();
                m_SystemBaseDisplay.FormClosed += OnSystemBaseDisplayClosed;
                m_SystemBaseDisplay.Show();
            }
        }
        private void OnSystemBaseDisplayClosed(object sender, EventArgs e)
        {
            m_SystemBaseDisplay = null;
        }
        #endregion

        #region Input
        private InputBaseDisplay m_InputBaseDisplay = null;

        public void OnInputBaseDisplayClosed(object sender, EventArgs e)
        {
            m_InputBaseDisplay = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_InputBaseDisplay == null)
            {
                m_InputBaseDisplay = new InputBaseDisplay();
                m_InputBaseDisplay.FormClosed += OnInputBaseDisplayClosed;
                m_InputBaseDisplay.Show();
            }
        }
        #endregion

        #region B3D
        private B3DBaseDisplay m_CameraBaseDisplay = null;

        public void OnCameraBaseDisplayClosed(object sender, EventArgs e)
        {
            m_CameraBaseDisplay = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_CameraBaseDisplay == null)
            {
                m_CameraBaseDisplay = new B3DBaseDisplay();
                m_CameraBaseDisplay.FormClosed += OnCameraBaseDisplayClosed;
                m_CameraBaseDisplay.Show();
            }
        }
        #endregion

        #region Galaxy
        private GalaxyBaseDisplay m_GalaxyBaseDisplay = null;
        public void OnGalaxyBaseDisplayClosed(object sender, EventArgs e)
        {
            m_GalaxyBaseDisplay = null;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (m_GalaxyBaseDisplay == null)
            {
                m_GalaxyBaseDisplay = new GalaxyBaseDisplay();
                m_GalaxyBaseDisplay.FormClosed += OnGalaxyBaseDisplayClosed;
                m_GalaxyBaseDisplay.Show();
            }
        }
        #endregion

        #endregion

        #region SectorObjects
        private void LoadPlayerShipButton_Click(object sender, EventArgs e)
        {
            SectorBase sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.pPlayerShip.obj);
            display.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SectorBase sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.GetSpace());
            display.Show();
        }

        #endregion

        #region ScriptInstances
        private void button5_Click(object sender, EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(GameHook.sectorObjectManager.GetPlayerObject().ScriptInstanceID);
            display.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            X3Tools.RAM.Bases.Story.Scripting.ScriptInstance obj = GameHook.sectorObjectManager.GetPlayerObject().ScriptInstance;
            IScriptMemoryObject_Ship ship = obj.GetMemoryInterfaceShip();
            display.LoadObject(ship.OwnerDataScriptingObjectID);
            display.Show();
        }
        #endregion

        #endregion

        #region Hacks
        #region SETA Override
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "SETA: x" + trackBar1.Value;
            SystemBase systembase = GameHook.systemBase;
            systembase.TimeWarpFactor.Value = trackBar1.Value;
            systembase.SaveSETA();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Maximum = checkBox1.Checked ? 20 : 10;
        }
        #endregion
        #endregion

        #region Tabs

        #region GameHook

        #region Bases

        #region Story

        #region Scripting
        private void ScriptingObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptInstanceDisplay().Show();
        }

        private void sciptInstanceSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptInstanceSubDisplay().Show();
        }

        private void scriptObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptTaskObjectDisplay().Show();
        }

        private void scriptingHashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptTableObjectDisplay().Show();
        }

        private void scriptingTextObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptStringObjectDisplay().Show();
        }

        private void scriptingArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptArrayObjectDisplay().Show();
        }

        private void scriptingDisassemblerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ScriptingDisassemblerDisplay().Show();
        }

        #endregion

        private void textPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TextPageDisplay().Show();
        }

        #endregion

        #region Sector
        private void sectorObjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new SectorObjectDisplay().Show();
        }

        private void typeDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new TypeDataDisplay().Show();
        }

        #endregion

        #region B3D
        private void cameraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CameraDisplay().Show();
        }

        private void bodyDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BodyDataDisplay().Show();
        }

        private void renderObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RenderObjectDisplay().Show();
        }
        #endregion

        #endregion

        private void hashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HashTableDisplay display = new HashTableDisplay();
            display.Show();
        }

        private void x86DisassemblerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new x86Disassembler().Show();
        }

        #endregion

        private void dLLInjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogue = new OpenFileDialog
            {
                Filter = "DLL|*.dll"
            };
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                GameHook.InjectDll(dialogue.FileName);
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Disable Anti-AFK by updating TimeOfLastInput.
            if (cbDisableAFK.Checked)
            {
                IScriptMemoryObject_RaceData_Player playerScriptObject = GameHook.storyBase.GetRaceData_Player();
                if (playerScriptObject != null)
                {
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            ((ScriptMemoryObject)playerScriptObject).SetVariableValueInMemory((int)TC_RaceData_Player_Variables.TimeOfLastInput, playerScriptObject.SecondsElapsed);
                            break;
                    }
                }
            }
        }
        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            SystemBase sb = GameHook.systemBase;
            sb.Language = (GameHook.Language)cbLanguage.SelectedItem;
            sb.SaveLanguage();
        }
    }
}
