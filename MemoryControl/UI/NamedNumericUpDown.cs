using System.ComponentModel;
using System.Windows.Forms;

namespace CommonToolLib.UI
{
    public partial class NamedNumericUpDown : UserControl
    {
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get => numericUpDown1.ReadOnly;
            set => numericUpDown1.ReadOnly = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => groupBox1.Text;
            set => groupBox1.Text = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Minimum
        {
            get => numericUpDown1.Minimum;
            set => numericUpDown1.Minimum = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Maximum
        {
            get => numericUpDown1.Maximum;
            set => numericUpDown1.Maximum = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Value
        {
            get => numericUpDown1.Value;
            set => numericUpDown1.Value = value;
        }

        public NamedNumericUpDown()
        {
            InitializeComponent();
        }
    }
}
