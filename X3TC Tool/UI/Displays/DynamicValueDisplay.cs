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
    public partial class DynamicValueArrayDisplay : Form
    {
        private GameHook m_GameHook;
        private IntPtr m_Address;
        private int m_Depth, m_Height;
        public DynamicValueArrayDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadFrom(IntPtr address, int ArrayDepth, int ArrayHeight)
        {
            m_Address = address;
            m_Depth = ArrayDepth;
            m_Height = ArrayHeight;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_Address.ToString("X");
            numericUpDown1.Value = m_Height;
            numericUpDown2.Value = m_Depth;
            dataGridView1.Rows.Clear();
            int index = -m_Depth;
            foreach(var item in GetAllValues())
            {
                dataGridView1.Rows.Add(index++, item.pThis.ToString("X"), item.Flag.ToString(), item.Value.ToString("X"), item.Value);
            }
        }

        private DynamicValue GetDynamicAtIndex(int index)
        {
            var value = new DynamicValue();
            value.SetLocation(m_GameHook.hProcess, m_Address + (5 * index));
            value.ReloadFromMemory();
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_Address = (IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber);
            m_Height = Convert.ToInt32(numericUpDown1.Value);
            m_Depth =  Convert.ToInt32(numericUpDown2.Value);
            Reload();
        }

        private DynamicValue[] GetAllValues()
        {
            List<DynamicValue> values = new List<DynamicValue>();
            for(int i = -m_Depth; i <= m_Height; i++)
            {
                values.Add(GetDynamicAtIndex(i));
            }
            return values.ToArray();
        }
    }
}
