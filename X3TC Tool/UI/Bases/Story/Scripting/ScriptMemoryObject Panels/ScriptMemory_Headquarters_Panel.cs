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
            lstvBlueprints.Columns[0].Width = -2;
            lstvBlueprints.Columns[0].Width -= 1;
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

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //var display = new ScriptingObjectDisplay();
            //display.LoadObject(m_Data.OwnerDataScriptingObjectID);
            //display.Show();
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            SectorObject.SectorObjectType type = (SectorObject.SectorObjectType)lstvBlueprints.SelectedItems[0].Tag;
            var typeDataDisplay = new TypeDataDisplay();
            typeDataDisplay.LoadTypeData(type.MainType, type.SubType);
            typeDataDisplay.Show();
        }
    }
}
