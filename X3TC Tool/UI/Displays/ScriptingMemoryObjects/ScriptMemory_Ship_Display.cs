using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.Scripting;

namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    public partial class ScriptMemory_Ship_Display : Form
    {
        private IScriptMemoryObject_Ship m_Object;
        public ScriptMemory_Ship_Display()
        {
            InitializeComponent();

            for (int i = 0; i < GameHook.GetTypeDataCount(7); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, i));
            } 

        }

        public void LoadObject(IScriptMemoryObject_Ship obj)
        {
            m_Object = obj;
            Reload();
        }

        public void Reload()
        {
            var cargo = m_Object.CargoEntries;
            Array.Sort(cargo);
            txtCargo.Text = string.Join("\n", cargo);
            cmbSubType.SelectedIndex = m_Object.SubType;
        }

        private void ScriptMemory_Ship_Display_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            display.LoadObject(m_Object.PreviousSectorEventObjectID, EventObjectDisplay.LoadAsItems.Sector);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            display.LoadObject(m_Object.CurrentSectorEventObjectID, EventObjectDisplay.LoadAsItems.Sector);
            display.Show();
        }
    }
}
