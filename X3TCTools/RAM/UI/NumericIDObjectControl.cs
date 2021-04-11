using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace X3Tools.RAM.UI
{
    public partial class NumericIDObjectControl : UserControl
    {
        private IntPtr m_address;
        private int m_ID;

        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EnableLoad
        {
            get
            {
                return btnLoadAddress.Enabled;
            }
            set
            {
                textBox1.ReadOnly = numericUpDown1.ReadOnly = !value;
                btnLoadAddress.Enabled = btnLoadID.Enabled = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IntPtr Address
        {
            get
            {
                return m_address;
            }
            set
            {
                m_address = value;
                Reload();
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
                Reload();
            }
        }

        private void Reload()
        {
            textBox1.Text = Address.ToString("X");
            numericUpDown1.Value = ID;
        }

        public NumericIDObjectControl()
        {
            InitializeComponent();
        }

        public void LoadObject(INumericIDObject obj)
        {
            Address = obj.pThis;
            ID = obj.ID;
        }
        public delegate void LoadEvent(object sender, int value);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event LoadEvent AddressLoad;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event LoadEvent IDLoad;

        private void btnLoadAddress_Click(object sender, EventArgs e)
        {
            if (AddressLoad != null) AddressLoad(sender, (int)Address);
        }

        private void btnLoadID_Click(object sender, EventArgs e)
        {
            if (IDLoad != null) IDLoad(sender, ID);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address = (IntPtr)int.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                Reload();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ID = (int)numericUpDown1.Value;
        }
    }
}
