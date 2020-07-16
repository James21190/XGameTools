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
using X3TCTools.Bases.Scripting.ScriptingMemoryObject;

namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    public partial class ScriptMemory_Ship_Display : Form
    {
        private GameHook m_GameHook;
        private IShip_ScriptMemoryObject m_Object;
        public ScriptMemory_Ship_Display(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();

            for (int i = 0; i < m_GameHook.GetTypeDataCount(7); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, i));
            } 

        }

        public void LoadObject(IShip_ScriptMemoryObject obj)
        {
            m_Object = obj;
            Reload();
        }

        public void Reload()
        {
            var cargo = m_Object.GetCargo();
            txtCargo.Text = string.Join("\n", cargo);
            cmbSubType.SelectedIndex = m_Object.GetSubType();
        }
    }
}
