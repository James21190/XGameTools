using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class Vector2Display: UserControl
    {
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get
            {
                return numericUpDown1.ReadOnly;
            }
            set
            {
                numericUpDown1.ReadOnly = value;
                numericUpDown2.ReadOnly = value;
            }
        }
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
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal X
        {
            get
            {
                return numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Y
        {
            get
            {
                return numericUpDown2.Value;
            }
            set
            {
                numericUpDown2.Value = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Minimum
        {
            get
            {
                return numericUpDown1.Minimum;
            }
            set
            {
                numericUpDown1.Minimum = value;
                numericUpDown2.Minimum = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Maximum
        {
            get
            {
                return numericUpDown1.Maximum;
            }
            set
            {
                numericUpDown1.Maximum = value;
                numericUpDown2.Maximum = value;
            }
        }

        public Common.Vector.Vector2 Vector
        {
            get
            {
                return new Common.Vector.Vector2(Convert.ToInt32(X),Convert.ToInt32(Y));
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2Display()
        {
            InitializeComponent();
        }

        private void Vector3Display_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
