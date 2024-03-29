﻿using System;
using System.Windows.Forms;

using X3Tools.RAM;
using X3Tools.RAM.Bases.Sector;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class TypeDataDisplay : Form
    {
        private TypeData m_TypeData;
        private int m_TypeDataMainType;
        public TypeDataDisplay()
        {
            InitializeComponent();

            tabControl1.SelectedIndex = 0;
            comboBox2.SelectedIndex = -1;

            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                tabControl1.TabPages[i].Text = ((SectorObject.Main_Type)i).ToString();
            }

            ReloadSubTypes();
        }

        public void LoadTypeData(int MainType, int SubType)
        {
            Text = string.Format("TypeData - {0} - {1}", ((SectorObject.Main_Type)MainType).ToString(), SectorObject.GetSubTypeAsString((SectorObject.Main_Type)MainType, SubType));
            if (tabControl1.SelectedIndex != MainType)
            {
                tabControl1.SelectedIndex = MainType;
                ReloadSubTypes();
            }
            if (comboBox2.SelectedIndex != SubType)
            {
                comboBox2.SelectedIndex = SubType;
            }

            m_TypeDataMainType = MainType;
            m_TypeData = GameHook.GetTypeData(MainType, SubType);
            Reload();
        }

        public void ReloadSubTypes()
        {
            if (tabControl1.SelectedIndex == -1)
            {
                comboBox2.Enabled = false;

                return;
            }

            comboBox2.Enabled = true;
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            for (int i = 0; i < GameHook.GetTypeDataCount(tabControl1.SelectedIndex); i++)
            {
                comboBox2.Items.Add(i + " - " + SectorObject.GetSubTypeAsString((SectorObject.Main_Type)tabControl1.SelectedIndex, i));
            }

        }

        public void Reload()
        {

            txtAddress.Text = m_TypeData.pThis.ToString("X");

            txtClass.Text = m_TypeData.GetObjectClassAsString();
            txtTypeString.Text = m_TypeData.pTypeString.obj.Value;
            txtNameID.Text = m_TypeData.DefaultNameID.ToString();
            textBox1.Text = m_TypeData.DefaultName;
            v3dRotationSpeed.Vector = m_TypeData.RotationSpeed;

            int priceVariation = 0;
            if (m_TypeData.PriceRangePercentage != 0)
            {
                priceVariation = (int)(m_TypeData.RelVal / (float)m_TypeData.PriceRangePercentage / 100);
            }

            txtRelVal.Text = m_TypeData.RelVal.ToString();

            txtMaxPrice.Text = String.Format("{0:n}", m_TypeData.GetPrice(1));
            txtPrice.Text = String.Format("{0:n}", m_TypeData.GetPrice(0.5m));
            txtMinPrice.Text = String.Format("{0:n}", m_TypeData.GetPrice(0));

            txtBodyID.Text = m_TypeData.BodyID.ToString();

            switch ((SectorObject.Main_Type)m_TypeDataMainType)
            {
                case SectorObject.Main_Type.Bullet:
                    TypeData_Bullet bulletTypeData = (TypeData_Bullet)m_TypeData;
                    break;
                case SectorObject.Main_Type.Background:
                    TypeData_Background backgroundTypeData = (TypeData_Background)m_TypeData;
                    txtBackgroundName.Text = backgroundTypeData.pName.obj.Value;
                    break;
                case SectorObject.Main_Type.Sun:
                    TypeData_Sun sunTypeData = (TypeData_Sun)m_TypeData;
                    txtSunModelID.Text = sunTypeData.ModelID.ToString();
                    txtSunAppearenceID.Text = sunTypeData.AppearenceID.ToString();
                    break;
                case SectorObject.Main_Type.Ship:
                    TypeData_Ship shipTypeData = (TypeData_Ship)m_TypeData;


                    txtShipOriginRace.Text = shipTypeData.OriginRace.ToString();

                    txtMaxSpeed.Text = shipTypeData.MaxSpeed.ToString();

                    txtShipModeCollectionlID.Text = shipTypeData.ModelID.ToString();
                    txtHangarSize.Text = shipTypeData.HangarSize.ToString();

                    txtMinimumCargoSpace.Text = shipTypeData.MinimumCargoSpace.ToString();
                    txtMaximumCargoSpace.Text = shipTypeData.MaximumCargoSpace.ToString();

                    if (shipTypeData.MaxShieldClass >= 0)
                    {
                        txtShielding.Text = string.Format("{0} x {1}", shipTypeData.MaxShieldCount, SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Shield, shipTypeData.MaxShieldClass));
                    }
                    else
                    {
                        txtShielding.Text = "None";
                    }

                    txtShieldPowerGenerator.Text = shipTypeData.ShieldPowerGenerator.ToString();
                    txtShipMaxHull.Text = shipTypeData.MaxHull.ToString();

                    txtScriptingObjectID.Text = shipTypeData.ScriptingObjectID.ToString();
                    txtMaxWeaponClass.Text = shipTypeData.MaxWeaponClass.ToString();
                    LoadTurret(0);

                    // HQ Production
                    TimeSpan time = shipTypeData.GetProductionTime();
                    txtShipRETime.Text = string.Format("{0}-{1}:{2}:{3}", time.Days, time.Hours, time.Minutes, time.Seconds);
                    dataGridView1.Rows.Clear();
                    foreach (TypeData_Ship.ProductionMaterial item in shipTypeData.GetProductionMaterials())
                    {
                        dataGridView1.Rows.Add(item.WareType.ToString(), item.Count);
                    }
                    break;
                case SectorObject.Main_Type.Factory:
                    TypeData_Factory factoryTypeData = (TypeData_Factory)m_TypeData;

                    txtFactoryOriginRace.Text = factoryTypeData.OriginRace.ToString();

                    txtFactoryHullValue.Text = factoryTypeData.HullCargoValue.ToString();
                    txtFactoryMaxHull.Text = String.Format("{0:n}", factoryTypeData.MaxHull.ToString());
                    break;
                case SectorObject.Main_Type.Laser:
                    TypeData_Laser laserTypeData = (TypeData_Laser)m_TypeData;
                    break;
                case SectorObject.Main_Type.Shield:
                    TypeData_Shield shieldTypeData = (TypeData_Shield)m_TypeData;
                    break;
            }
        }

        public void LoadTurret(int turretIndex)
        {
            if (numericUpDown1.Value != turretIndex)
            {
                numericUpDown1.Value = turretIndex;
            }

            TypeData_Ship.TurretData turretData = ((TypeData_Ship)m_TypeData).TurretDatas[turretIndex];

            for (int i = 0; i < 32; i++)
            {
                cklTurretWeapons.SetItemChecked(i, turretData.WeaponCompatability.GetBit(i));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                return;
            }

            LoadTypeData(tabControl1.SelectedIndex, comboBox2.SelectedIndex);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = "TypeData";
            ReloadSubTypes();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadTurret((int)numericUpDown1.Value);
        }
    }
}
