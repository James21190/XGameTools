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
using X3TCTools.Bases;

namespace X3TC_Tool.UI.Displays
{
    public partial class DynamicValueObjectViewer : Form
    {
        private GameHook m_GameHook;
        private DynamicValueObject m_object;
        public DynamicValueObjectViewer(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadObject(DynamicValueObject dynamicValueObject)
        {
            m_object = dynamicValueObject;
            Reload();
        }

        public void Reload()
        {
            m_object.ReloadFromMemory();

            dataGridView1.Rows.Clear();

            for(int i = 0; i < m_object.variableCount; i++)
            {
                var value = m_object.GetVariable(i);
                dataGridView1.Rows.Add(m_object.GetVariableName(i), value.Flag, value.Value, value.Value.ToString("X"));
            }
        }
    }
}
