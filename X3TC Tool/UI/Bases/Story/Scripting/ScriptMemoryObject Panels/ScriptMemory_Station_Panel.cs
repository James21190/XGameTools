using System.Windows.Forms;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3Tools.RAM;

using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;


using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Bases.Sector;
using System;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels
{
    public partial class ScriptMemory_Station_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set { m_MessengerFunction = value; } }
        public ScriptMemory_Station_Panel()
        {
            InitializeComponent();
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                cmbMainType.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }

        ScriptInstance m_ScriptInstance;

        public void LoadObject(ScriptInstance ScriptInstance, bool reload = true)
        {
            if (!ScriptInstance.ScriptInstanceType.InheritsFrom("Station"))
                throw new NotSupportedException("Object doesn't inherit from Station");
            m_ScriptInstance = ScriptInstance;
            if(reload) Reload();
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
            cmbMainType.SelectedIndex = m_ScriptInstance.GetVariableByName("MainType").Value;
            cmbSubType.SelectedIndex = m_ScriptInstance.GetVariableByName("SubType").Value;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(m_ScriptInstance.GetVariableByName("OwningRaceDataScriptingObjectID").Value);
            display.Show();
        }

        private void cmbMainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSubTypes();
        }
    }
}
