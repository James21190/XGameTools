using System;
using System.Windows.Forms;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels;
using X3Tools.RAM;

using X3Tools.RAM.Bases.Story;
using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Generics;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    public partial class ScriptInstanceDisplay : Form
    {
        private ScriptInstance m_ScriptInstance;
        public ScriptInstanceDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(int ID)
        {
            StoryBase storyBase = GameHook.storyBase;
            HashTable<ScriptInstance> ScriptingObjectHashTable = storyBase.pHashTable_ScriptInstance.obj;
            int value = ID < 0 ? -ID - 1 : ID;
            try
            {
                LoadObject(ScriptingObjectHashTable.GetObject(value));
            }
            catch (Exception)
            {
                m_ScriptInstance = null;
            }
        }
        public void LoadObject(ScriptInstance ScriptingObject)
        {
            m_ScriptInstance = ScriptingObject;
            ScriptingObjectPannel1.ScriptingObject = ScriptingObject;
            RecreatePanel();
            Reload();
        }

        private IScriptMemoryObject_Panel typePanel;

        private void RecreatePanel()
        {
            if (typePanel != null)
            {
                UserControl panel = (UserControl)typePanel;
                panel.Dispose();
                typePanel = null;
            }

            if (m_ScriptInstance.ScriptInstanceType != null)
            {
                foreach (string type in m_ScriptInstance.ScriptInstanceType.InheritanceStack)
                {
                    switch (type)
                    {
                        case "Ship":
                            typePanel = new ScriptMemory_Ship_Panel();
                            break;
                        case "Station":
                            typePanel = new ScriptMemory_Station_Panel();
                            break;
                        case "Station_Headquarters":
                            typePanel = new ScriptMemoryt_Headquarters_Panel();
                            break;
                        case "RaceData":
                            typePanel = new ScriptMemory_RaceData_Panel();
                            break;
                        case "RaceData_Player":
                            typePanel = new ScriptMemory_RaceData_Player_Panel();
                            break;
                        case "Sector":
                            typePanel = new ScriptMemory_Sector_Panel();
                            break;
                    }
                    if (typePanel != null)
                    {
                        break;
                    }
                }
            }

            if (typePanel == null)
            {
                return;
            }

            typePanel.MessengerFunction = OnMessageFromPanel;
            UserControl ucTypePanel = (UserControl)typePanel;
            typeBackPanel.Controls.Add(ucTypePanel);
            ucTypePanel.Location = new System.Drawing.Point(1, 1);
            ucTypePanel.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            typePanel.LoadObject(m_ScriptInstance, false);
        }


        public void Reload()
        {
            scriptMemoryObject_Raw_Panel1.LoadObject(m_ScriptInstance);

            if (typePanel != null)
            {
                typePanel.LoadObject(m_ScriptInstance);
            }
        }

        private void OnMessageFromPanel(string Message)
        {
            statusStrip1.Items.Add(Message);
        }
        private void ScriptingObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void ScriptingObjectPannel1_ScriptingObjectLoaded(object sender, EventArgs e)
        {
            LoadObject(ScriptingObjectPannel1.ScriptingObject);
        }

        private void scriptMemoryObject_Raw_Panel1_Load(object sender, EventArgs e)
        {

        }

        private void tmrAutoReload_Tick(object sender, EventArgs e)
        {
            scriptMemoryObject_Raw_Panel1.Reload();
        }
    }
}
