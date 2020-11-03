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
using Common.Memory;

namespace X3TC_Tool.UI
{
    public partial class MemoryObjectDisplay : Form
    {
        public MemoryObjectDisplay(string title = null)
        {
            InitializeComponent();
            if(title != null)
                Text = title;
        }

        MemoryObject m_MemoryObject;

        public void LoadObject(MemoryObject memoryObject)
        {
            m_MemoryObject = memoryObject;
            Reload();
        }

        public void Reload()
        {
            txtAddress.Text = m_MemoryObject.pThis.ToString("X");
            textBox1.Text = m_MemoryObject.GetType().ToString();
        }

    }
}
