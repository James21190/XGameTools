using System.Windows.Forms;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3TCTools;

using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Sector_Objects;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels
{
    public partial class IScriptMemoryObject_Station_Panel : UserControl, IScriptMemoryObject_Panel
    {
        public IScriptMemoryObject_Station_Panel()
        {
            InitializeComponent();
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                cmbMainType.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }

        private IScriptMemoryObject_Station m_Data;
        public void LoadObject(ScriptingObject eventObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Station>(); break;
                case GameHook.GameVersions.X3TC: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Station>(); break;
            }
            Reload();
        }

        private void ReloadSubTypes()
        {
            cmbSubType.Items.Clear();
            for (int i = 0; i < GameHook.GetTypeDataCount(cmbMainType.SelectedIndex); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString((SectorObject.Main_Type)cmbMainType.SelectedIndex, i));
            }
        }

        public void Reload()
        {
            cmbMainType.SelectedIndex = m_Data.MainType;
            ReloadSubTypes();
            cmbSubType.SelectedIndex = m_Data.SubType;
            cargo_Panel1.Cargo = m_Data.CargoEntries;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //var display = new EventObjectDisplay();
            //display.LoadObject(m_Data.OwnerDataEventObjectID);
            //display.Show();
        }
    }
}
