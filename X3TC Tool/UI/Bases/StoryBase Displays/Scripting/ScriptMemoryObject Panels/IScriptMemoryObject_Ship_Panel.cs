using System.Windows.Forms;
using X3Tools;

using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Sector_Objects;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
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

        public void LoadObject(ScriptingObject ScriptingObject)
        {
            m_Data = ScriptingObject.GetMemoryInterfaceShip();
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
            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(m_Data.CurrentSectorScriptingObject);
            display.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(m_Data.PreviousSectorScriptingObject);
            display.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(m_Data.OwnerDataScriptingObjectID);
            display.Show();
        }

        private void IScriptMemoryObject_Ship_Panel_Load(object sender, System.EventArgs e)
        {

        }
    }
}
