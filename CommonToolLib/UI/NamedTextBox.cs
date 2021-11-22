using System.ComponentModel;
using System.Windows.Forms;

namespace CommonToolLib.UI
{
    public partial class NamedTextBox : UserControl
    {
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get => textBox1.ReadOnly;
            set => textBox1.ReadOnly = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => groupBox1.Text;
            set => groupBox1.Text = value;
        }

        public NamedTextBox()
        {
            InitializeComponent();
        }
    }
}
