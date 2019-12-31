using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Tools.X2.SectorObjects;

namespace X2TheThreatRETool.UI
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

            
            switch ((SectorObject.Main_Type)comboBox1.SelectedIndex)
            {
                default:
                    return;
                // Type 0 and 8
                case SectorObject.Main_Type.Projectile:
                case SectorObject.Main_Type.ShipGun:
                    for (int i = 0; i < SectorObject.WEAPON_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Weapon_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Asteroid:
                    for (int i = 0; i < SectorObject.ASTEROID_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Asteroid_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Ware_Processed:
                    for (int i = 0; i < SectorObject.WARE_PROCESSED_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Ware_Processed_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Ware_Mission:
                    for(int i = 0; i < SectorObject.WARE_MISSION_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Ware_Mission_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Miscellaneous:
                    for (int i = 0; i < SectorObject.MISCELLANEOUS_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Miscellaneous_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Dock:
                    for (int i = 0; i < SectorObject.DOCK_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Dock_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Factory:
                    for (int i = 0; i < SectorObject.FACTORY_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Factory_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Gate:
                    for (int i = 0; i < SectorObject.GATE_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Gate_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Missile:
                    for (int i = 0; i < SectorObject.MISSILE_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Missile_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Nebula:
                    for (int i = 0; i < SectorObject.NEBULA_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Nebula_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Planet:
                    for (int i = 0; i < SectorObject.PLANET_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Planet_Sub_Type)i).ToString());
                    break;
                case SectorObject.Main_Type.Shield:
                    for (int i = 0; i < SectorObject.SHIELD_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Shield_Sub_Type)i).ToString());
                    break;
                // Type 7
                case SectorObject.Main_Type.Ship:
                    for (int i = 0; i < SectorObject.SHIP_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Ship_Sub_Type)i).ToString());
                    break;
                // Type 15
                case SectorObject.Main_Type.Ware_Ores:
                    for (int i = 0; i < SectorObject.WARE_ORES_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Ware_Ores_Sub_Type)i).ToString());
                    break;
                // Type 16
                case SectorObject.Main_Type.Ware_Technology:
                    for (int i = 0; i < SectorObject.WARE_TECHNOLOGY_SUBTYPE_COUNT; i++)
                        comboBox2.Items.Add(((SectorObject.Ware_Technology_Sub_Type)i).ToString());
                    break;
            }
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
