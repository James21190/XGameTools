using System.Windows.Forms;
using X3TCTools;

using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Sector_Objects;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class IScriptMemoryObject_Ship_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private IScriptMemoryObject_Ship m_Data;
        public IScriptMemoryObject_Ship_Panel()
        {
            InitializeComponent();

            for (int i = 0; i < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, i));
            }
        }

        public void LoadObject(EventObject eventObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>(); break;
                case GameHook.GameVersions.X3TC: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Ship>(); break;
            }
            Reload();
        }

        public void Reload()
        {
            if (m_Data == null)
            {
                return;
            }

            cmbSubType.SelectedIndex = m_Data.SubType;
            cargo_Panel1.Cargo = m_Data.CargoEntries;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            EventObjectDisplay display = new EventObjectDisplay();
            display.LoadObject(m_Data.CurrentSectorEventObject);
            display.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            EventObjectDisplay display = new EventObjectDisplay();
            display.LoadObject(m_Data.PreviousSectorEventObject);
            display.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            EventObjectDisplay display = new EventObjectDisplay();
            display.LoadObject(m_Data.OwnerDataEventObjectID);
            display.Show();
        }

        private void IScriptMemoryObject_Ship_Panel_Load(object sender, System.EventArgs e)
        {

        }
    }
}
