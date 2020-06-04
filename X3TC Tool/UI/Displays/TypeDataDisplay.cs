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
        private object m_TypeData;
        private int m_TypeDataMainType;
        public TypeDataDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;

            tabControl1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

        }

        public void LoadTypeData(int MainType, int SubType)
        {
            if (tabControl1.SelectedIndex != MainType)
            {
                tabControl1.SelectedIndex = MainType;
                ReloadSubTypes();
            }
            if (comboBox2.SelectedIndex != SubType) comboBox2.SelectedIndex = SubType;

            m_TypeDataMainType = MainType;
            m_TypeData = m_GameHook.GetShipTypeData(SubType);
            Reload();
        }

        public void ReloadSubTypes()
        {
            if(tabControl1.SelectedIndex == -1)
            {
                comboBox2.Enabled = false;
                return;
            }

            comboBox2.Enabled = true;
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            for (int i = 0; i < SectorObject.GetMaxSubType((SectorObject.Main_Type)tabControl1.SelectedIndex); i++)
            {
                comboBox2.Items.Add(SectorObject.GetSubTypeAsString((SectorObject.Main_Type)tabControl1.SelectedIndex, i));
            }

        }

        public void Reload()
        {
            switch (m_TypeDataMainType)
            {
                case 7:
                    var shipTypeData = (TypeData_Ship)m_TypeData;
                    AddressBox.Text = shipTypeData.pThis.ToString("X");
                    ShipMaxHullBox.Text = shipTypeData.MaxHull.ToString();
                    ShipOriginRaceBox.Text = shipTypeData.OriginRace.ToString();
                    ShipClassBox.Text = shipTypeData.ObjectClass.ToString();
                    break;
            }
        } 
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex < 0) return;
            LoadTypeData(tabControl1.SelectedIndex, comboBox2.SelectedIndex);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSubTypes();
        }
    }
}
