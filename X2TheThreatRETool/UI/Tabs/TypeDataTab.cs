using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Tools;
using X2Tools.X2.TypeData;
using Common;
using Common.Memory;


namespace X2TheThreatRETool
{
    public partial class X2RETool : Form
    {
        #region TypeData Tab

        #region ShipTypeData Tab

        private ShipTypeData ShipTypeDataTab_ActiveShipTypeData;

        private void ShipTypeDataTab_Reload(object sender, EventArgs e)
        {
            ShipTypeDataTab_ActiveShipTypeData = m_GameHook.TypeDataArray.ShipTypeDataArray[comboBox1.SelectedIndex];

            textBox1.Text = (MemoryControl.CalculateArrayIndexAddress((int)m_GameHook.TypeDataArray.pTypeData_Ship, ShipTypeData.Length, comboBox1.SelectedIndex)).ToString("X");

            // Load subtype number
            numericUpDown40.Value = comboBox1.SelectedIndex;

            // Load ship class
            comboBox2.SelectedIndex = (int)ShipTypeDataTab_ActiveShipTypeData.Class;
            // Load max speed
            numericUpDown1.Value = ShipTypeDataTab_ActiveShipTypeData.MaxSpeed;
            // Load acceleration
            numericUpDown2.Value = ShipTypeDataTab_ActiveShipTypeData.Acceleration;
            // Load power generator
            numericUpDown3.Value = ShipTypeDataTab_ActiveShipTypeData.PowerGenerator;
            // Load object model ID
            numericUpDown4.Value = ShipTypeDataTab_ActiveShipTypeData.ObjectModelID;
            // Load cargo class
            comboBox3.SelectedIndex = (int)ShipTypeDataTab_ActiveShipTypeData.CargoClass;
            // Load minimum cargobay
            numericUpDown6.Value = ShipTypeDataTab_ActiveShipTypeData.MinimumCargoBay;
            // Load maximum cargobay
            numericUpDown7.Value = ShipTypeDataTab_ActiveShipTypeData.MaximumCargoBay;
            // Load hangar size
            numericUpDown5.Value = ShipTypeDataTab_ActiveShipTypeData.HangarSize;
            // Load cockpit model ID
            numericUpDown8.Value = ShipTypeDataTab_ActiveShipTypeData.CockpitModelID;
            // Load max hull
            numericUpDown9.Value = ShipTypeDataTab_ActiveShipTypeData.MaxHull;
            // Load shield class
            comboBox4.SelectedIndex = (int)ShipTypeDataTab_ActiveShipTypeData.ShieldClass;
            // Load max shield count
            numericUpDown10.Value = ShipTypeDataTab_ActiveShipTypeData.MaxShieldCount;
            // Load origin race
            comboBox5.SelectedIndex = (int)ShipTypeDataTab_ActiveShipTypeData.OriginRace;
        }

        #endregion

        #region ProjectileTypeData Tab

        private void ProjectileTypeDataTab_Reload(object sender, EventArgs e)
        {
        }

        #endregion

        #endregion
    }
}
