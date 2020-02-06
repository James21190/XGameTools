using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.Bases;

namespace X3TCTools
{
    public partial class DynamicValueDisplay : UserControl
    {
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return groupBox1.Text;
            }
            set
            {
                groupBox1.Text = value;
            }
        }

        private DynamicValue m_DynamicValue;
        
        public DynamicValue Value
        {
            get
            {
                return m_DynamicValue;
            }
            set
            {
                m_DynamicValue = value != null ? value : new DynamicValue();
                Reload();
            }
        }

        private void Reload()
        {
            TypeBox.Text = m_DynamicValue.Flag.ToString();
            ValueBox.Text = m_DynamicValue.Value.ToString();
        }

        public DynamicValueDisplay()
        {
            InitializeComponent();
        }
    }
}
