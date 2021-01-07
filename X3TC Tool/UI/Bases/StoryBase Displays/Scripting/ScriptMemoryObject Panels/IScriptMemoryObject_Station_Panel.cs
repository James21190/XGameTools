using System.Windows.Forms;
using X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3Tools;

using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Bases.SectorBase_Objects;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels
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
        public void LoadObject(ScriptingObject ScriptingObject)
        {
            m_Data = ScriptingObject.GetMemoryInterfaceStation();
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
            //var display = new ScriptingObjectDisplay();
            //display.LoadObject(m_Data.OwnerDataScriptingObjectID);
            //display.Show();
        }
    }
}
