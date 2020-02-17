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

namespace X3TC_Tool.UI.Displays
{
    public partial class TypeDataDisplay : Form
    {
        private GameHook m_GameHook;
        private TypeData m_TypeData;
        public TypeDataDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                comboBox1.Items.Add((SectorObject.Main_Type)i);
            }

        }

        public void LoadTypeData(int MainType, int SubType)
        {

            if (comboBox1.SelectedIndex != MainType) comboBox1.SelectedIndex = MainType;
            if (comboBox2.SelectedIndex != SubType) comboBox2.SelectedIndex = SubType;

            m_TypeData = m_GameHook.GetTypeData(MainType, SubType);
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_TypeData.pThis.ToString("X");
            MaxHullBox.Text = m_TypeData.MaxHull.ToString();
            OriginRaceBox.Text = m_TypeData.OriginRace.ToString();
            ClassBox.Text = m_TypeData.GetClassAsString((SectorObject.Main_Type)comboBox1.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = comboBox1.SelectedIndex >= 0;
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            for (int i = 0; i < SectorObject.GetMaxSubType((SectorObject.Main_Type)comboBox1.SelectedIndex); i++)
            {
                comboBox2.Items.Add(SectorObject.GetSubTypeAsString((SectorObject.Main_Type)comboBox1.SelectedIndex, i));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex < 0) return;
            LoadTypeData(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
        }
    }
}
