using System.Windows.Forms;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3TCTools;

using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Sector_Objects;
using System.Drawing;
using X3TC_Tool.UI.Displays;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels
{
    public partial class IScriptMemoryObject_Headquarters_Panel : UserControl, IScriptMemoryObject_Panel
    {
        public IScriptMemoryObject_Headquarters_Panel()
        {
            InitializeComponent();
            lstvBlueprints.Columns[0].Width = -2;
            lstvBlueprints.Columns[0].Width -= 1;
        }

        private IScriptMemoryObject_Headquarters m_Data;
        private ScriptingObject m_EventObject;
        public void LoadObject(ScriptingObject eventObject)
        {
            m_EventObject = eventObject;
            switch (GameHook.GameVersion)
            {
                //case GameHook.GameVersions.X3AP: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Headquarters>(); break;
                case GameHook.GameVersions.X3TC: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Headquarters>(); break;
            }
            Reload();
        }

        public void Reload()
        {
            iScriptMemoryObject_Station_Panel1.LoadObject(m_EventObject);

            lstvBlueprints.Items.Clear();

            int count = 0;

            foreach(var shipType in SectorObject.SectorObjectType.GetAllOfMainType(SectorObject.Main_Type.Ship))
            {
                bool IsAvailable = (m_Data.AvailableBlueprintHashTable.hashTable.ContainsObject(new DynamicValue()
                {
                    Flag = DynamicValue.FlagType.Int,
                    Value = shipType.ToInt()
                }));
                var ListItem = lstvBlueprints.Items.Add(shipType.ToString());
                ListItem.Tag = shipType;
                ListItem.BackColor = IsAvailable ? Color.Green : Color.Red;
                if (IsAvailable) count++;
            }
            lblBlueprintCount.Text = string.Format("{0}/{1} Available", count, GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship));
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //var display = new EventObjectDisplay();
            //display.LoadObject(m_Data.OwnerDataEventObjectID);
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
