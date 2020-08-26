using System.Windows.Forms;
using X3TCTools;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.Scripting.ScriptingMemory.TC;
using X3TCTools.SectorObjects;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class IScriptMemoryObject_Sector_Panel : UserControl, IScriptMemoryObject_Panel
    {
        public IScriptMemoryObject_Sector_Panel()
        {
            InitializeComponent();
            for (int i = 0; i < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Background); i++)
            {
                comboBox1.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Background, i));
            }
        }

        private IScriptMemoryObject_Sector m_Data;
        public void LoadObject(EventObject eventObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>(); break;
                case GameHook.GameVersions.X3TC: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>(); break;
            }
            Reload();
        }

        public void Reload()
        {
            vector2Display1.X = m_Data.SectorX;
            vector2Display1.Y = m_Data.SectorY;
            textBox1.Text = GameHook.gateSystemObject.GetSectorName(m_Data.SectorX, m_Data.SectorY);
            comboBox1.SelectedIndex = m_Data.BackgroundID;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            EventObjectDisplay display = new EventObjectDisplay();
            display.LoadObject(m_Data.OwnerDataEventObjectID);
            display.Show();
        }
    }
}
