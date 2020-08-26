using System;
using System.Windows.Forms;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class Cargo_Panel : UserControl, IReloadableDisplay
    {
        private CargoEntry[] m_Cargo;
        private bool IsSorted = false;
        public CargoEntry[] Cargo
        {
            get => m_Cargo;
            set
            {
                m_Cargo = value;
                IsSorted = false;
                Reload();
            }
        }
        public Cargo_Panel()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            if (m_Cargo == null)
            {
                txtCargo.Text = "";
                return;
            }
            if (!IsSorted)
            {
                IsSorted = true;
                Array.Sort(m_Cargo);
                Array.Reverse(m_Cargo);
            }
            txtCargo.Text = string.Join("\n", m_Cargo);
        }
    }
}
