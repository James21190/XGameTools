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
            txtCargo.Text = string.Join("\n", cargo);
            cmbSubType.SelectedIndex = m_Object.SubType;
        }

        private void ScriptMemory_Ship_Display_Load(object sender, EventArgs e)
        {

        }
    }
}
