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
        private int m_TypeDataMainType;
        public TypeDataDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;

            tabControl1.SelectedIndex = 0;
            comboBox2.SelectedIndex = -1;

            ReloadSubTypes();
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
            m_TypeData = m_GameHook.GetTypeData(MainType ,SubType);
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
            txtAddress.Text = m_TypeData.pThis.ToString("X");
            
            txtClass.Text = m_TypeData.GetObjectClassAsString();
            txtTypeString.Text = m_TypeData.pTypeString.obj.value;
            txtNameID.Text = m_TypeData.NameID.ToString();
            v3dRotationSpeed.Vector = m_TypeData.RotationSpeed;

            var priceVariation = (int)(m_TypeData.Price / (float)m_TypeData.PriceRangePercentage/100);

            txtMaxPrice.Text = (m_TypeData.Price + priceVariation).ToString();
            txtPrice.Text = m_TypeData.Price.ToString();
            txtMinPrice.Text = (m_TypeData.Price - priceVariation).ToString();

            switch ((SectorObject.Main_Type)m_TypeDataMainType)
            {
                case SectorObject.Main_Type.Bullet:
                    var bulletTypeData = (TypeData_Bullet)m_TypeData;
                    break;
                case SectorObject.Main_Type.Ship:
                    var shipTypeData = (TypeData_Ship)m_TypeData;


                    txtShipOriginRace.Text = shipTypeData.OriginRace.ToString();

                    txtMaxSpeed.Text = shipTypeData.MaxSpeed.ToString();

                    txtModelID.Text = shipTypeData.ModelID.ToString();
                    txtHangarSize.Text = shipTypeData.HangarSize.ToString();

                    txtMinimumCargoSpace.Text = shipTypeData.MinimumCargoSpace.ToString();
                    txtMaximumCargoSpace.Text = shipTypeData.MaximumCargoSpace.ToString();

                    txtShielding.Text = string.Format("{0} x {1}", shipTypeData.MaxShieldCount, shipTypeData.MaxShieldClass.ToString());
                    txtShieldPowerGenerator.Text = shipTypeData.ShieldPowerGenerator.ToString();
                    txtShipMaxHull.Text = shipTypeData.MaxHull.ToString();

                    txtEventObjectID.Text = shipTypeData.EventObjectID.ToString();
                    txtMaxWeaponClass.Text = shipTypeData.MaxWeaponClass.ToString();
                    LoadTurret(0);
                    break;
                case SectorObject.Main_Type.Laser:
                    var laserTypeData = (TypeData_Laser)m_TypeData;
                    break;
                case SectorObject.Main_Type.Shield:
                    var shieldTypeData = (TypeData_Shield)m_TypeData;
                    break;
            }
        }
        
        public void LoadTurret(int turretIndex)
        {
            if (numericUpDown1.Value != turretIndex) numericUpDown1.Value = turretIndex;
            var turretData = ((TypeData_Ship)m_TypeData).TurretDatas[turretIndex];

            for (int i = 0; i < 32; i++)
            {
                cklTurretWeapons.SetItemChecked(i, turretData.WeaponCompatability.GetBit(i));
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadTurret((int)numericUpDown1.Value);
        }
    }
}
