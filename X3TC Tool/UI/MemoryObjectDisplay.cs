using CommonToolLib.Memory;
using System.Windows.Forms;

namespace X3TC_RAM_Tool.UI
{
    public partial class MemoryObjectDisplay : Form
    {
        public MemoryObjectDisplay(string title = null)
        {
            InitializeComponent();
            if (title != null)
            {
                Text = title;
            }
        }

        private MemoryObject m_MemoryObject;

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
