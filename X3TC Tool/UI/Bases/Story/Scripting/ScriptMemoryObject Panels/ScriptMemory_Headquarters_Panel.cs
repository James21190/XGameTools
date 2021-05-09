using System.Windows.Forms;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3Tools.RAM;

using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Bases.Sector;
using System.Drawing;
using X3TC_RAM_Tool.UI.Displays;
using System;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels
{
    public partial class ScriptMemoryt_Headquarters_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set { m_MessengerFunction = value; } }
        public ScriptMemoryt_Headquarters_Panel()
        {
            InitializeComponent();
            lstBlueprints.Columns[0].Width = -2;
            lstBlueprints.Columns[0].Width -= 1;
        }

        private ScriptInstance m_ScriptInstance;
        public void LoadObject(ScriptInstance ScriptInstance, bool reload = true)
        {
            if (!ScriptInstance.ScriptInstanceType.InheritsFrom("Station_Headquarters"))
                throw new NotSupportedException("Object doesn't inherit from Headquarters");
            m_ScriptInstance = ScriptInstance;
            if(reload) Reload();
        }

        public void Reload()
        {
            iScriptMemoryObject_Station_Panel1.LoadObject(m_ScriptInstance);
            var table = m_ScriptInstance.GetVariableByName("AvailableBlueprintHashTable").GetAsHashTableObject();
            int count = 0;
            for(int i = 0; i < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship); i++)
            {
                var type = new SectorObject.SectorObjectType(SectorObject.Main_Type.Ship, i);
                var name = SectorObject.GetSubTypeAsString(type.MainTypeEnum,type.SubType);

                var lstEntry = lstBlueprints.Items.Add(name);

                if (table.hashTable.ContainsObject(new DynamicValue() { Flag = DynamicValue.FlagType.Int, Value = type.ToInt() }))
                {
                    count++;
                    lstEntry.BackColor = Color.Green;
                }
                else
                {
                    lstEntry.BackColor = Color.Red;
                }
            }
            lblBlueprintCount.Text = string.Format("{0}/{1}", count, GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship));
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            SectorObject.SectorObjectType type = (SectorObject.SectorObjectType)lstBlueprints.SelectedItems[0].Tag;
            var typeDataDisplay = new TypeDataDisplay();
            typeDataDisplay.LoadTypeData(type.MainType, type.SubType);
            typeDataDisplay.Show();
        }
    }
}
