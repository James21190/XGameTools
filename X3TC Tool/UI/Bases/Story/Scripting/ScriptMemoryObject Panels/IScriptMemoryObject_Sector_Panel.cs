using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.AP;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.TC;
using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Bases.Sector;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
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
        public void LoadObject(ScriptInstance ScriptingObject)
        {
            m_Data = ScriptingObject.GetMemoryInterfaceSector();
            Reload();
        }

        public struct stringObj
        {
            public string text;
            public object obj;

            public override string ToString()
            {
                return text;
            }
        }
        public void Reload()
        {
            vector2Display1.X = m_Data.SectorX;
            vector2Display1.Y = m_Data.SectorY;
            textBox1.Text = GameHook.galaxyBase.GetSectorName(m_Data.SectorX, m_Data.SectorY);
            comboBox1.SelectedIndex = m_Data.BackgroundID;

            #region Load Objects

            var storyBase = GameHook.storyBase;

            ScriptInstance so;

            lstShips.Items.Clear();
            foreach(var id in m_Data.ShipScriptingObjectHashTableObject.hashTable.ScanContents())
            {
                so = storyBase.GetScriptingObject(id.Value);
                IScriptMemoryObject_Ship ship = so.GetMemoryInterfaceShip();
                lstShips.Items.Add(new stringObj(){ text = ship.ToString(), obj = so });
            }

            #endregion
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(m_Data.OwnerDataScriptingObjectID);
            display.Show();
        }
    }
}
