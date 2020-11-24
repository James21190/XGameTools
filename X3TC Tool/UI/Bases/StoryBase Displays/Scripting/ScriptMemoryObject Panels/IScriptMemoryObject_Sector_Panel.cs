using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Sector_Objects;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
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
        public void LoadObject(ScriptingObject ScriptingObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>(); break;
                case GameHook.GameVersions.X3TC: m_Data = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>(); break;
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
            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(m_Data.OwnerDataScriptingObjectID);
            display.Show();
        }
    }
}
