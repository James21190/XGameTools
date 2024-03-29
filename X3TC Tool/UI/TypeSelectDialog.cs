﻿using System;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Sector;

namespace X3TC_RAM_Tool.UI
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
            {
                comboBox1.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.SelectedIndex = -1;

            if (comboBox1.SelectedIndex == -1)
            {
                comboBox2.Enabled = false;
                return;
            }

            int typeCount = GameHook.GetTypeDataCount(comboBox1.SelectedIndex);

            for (int i = 0; i < typeCount; i++)
            {
                comboBox2.Items.Add((SectorObject.GetSubTypeAsString((SectorObject.Main_Type)comboBox1.SelectedIndex, i)));
            }

            comboBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainType = (SectorObject.Main_Type)comboBox1.SelectedIndex;
            SubType = comboBox2.SelectedIndex;
            ParentID = Convert.ToInt32(numericUpDown1.Value);
            Done = true;
            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = (comboBox2.SelectedIndex > -1);
        }
    }
}
