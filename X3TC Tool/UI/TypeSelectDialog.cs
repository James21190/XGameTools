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
using X3TCTools.SectorObjects;

namespace X3TC_Tool.UI
{
    public partial class TypeSelectDialog : Form
    {

        public bool Done
        {
            get;
            private set;
        } = false;

        public SectorObject.Main_Type MainType
        {
            get;
            private set;
        }
        public int SubType
        {
            get;
            private set;
        }

        public int ParentID { private set; get; } = 0;

        public TypeSelectDialog()
        {
            InitializeComponent();
        }

        private void TypeSelectDialog_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
                comboBox1.Items.Add(((SectorObject.Main_Type)i).ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.SelectedIndex = -1;

            if(comboBox1.SelectedIndex == -1)
            {
                comboBox2.Enabled = false;
                return;
            }

            var typeCount = GameHook.GetTypeDataCount(comboBox1.SelectedIndex);
            
            for (int i = 0; i < typeCount; i++)
                comboBox2.Items.Add((SectorObject.GetSubTypeAsString((SectorObject.Main_Type)comboBox1.SelectedIndex,i)));
            comboBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainType = (SectorObject.Main_Type)comboBox1.SelectedIndex;
            SubType = comboBox2.SelectedIndex;
            ParentID = Convert.ToInt32(numericUpDown1.Value);
            Done = true;
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = (comboBox2.SelectedIndex > -1);
        }
    }
}
