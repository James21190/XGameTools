using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Memory;
using X3TCTools;
using X3TCTools.Bases;
using X3TCTools.SectorObjects;

namespace X3TC_Tool.UI.Displays
{
    public partial class EventObjectVariableDisplay_Ship : Form
    {
        private GameHook m_GameHook;

        private DynamicValue[] m_Variables;
        public EventObjectVariableDisplay_Ship(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }


        public void LoadVariables(IntPtr address)
        {
            AddressBox.Text = address.ToString("X");
            m_Variables = new DynamicValue[EventObject.ShipVariableCount];

            for(int i = 0; i < EventObject.ShipVariableCount; i++)
            {
                var obj = new DynamicValue();
                obj.SetLocation(m_GameHook.hProcess, address + (i * DynamicValue.ByteSize));
                obj.ReloadFromMemory();
                m_Variables[i] = obj;
            }

            Reload();

        }

        public void Reload()
        {
            dynamicValueDisplay9.Value = m_Variables[0];
            dynamicValueDisplay1.Value = m_Variables[1];
            dynamicValueDisplay2.Value = m_Variables[2];
            dynamicValueDisplay3.Value = m_Variables[3];
            dynamicValueDisplay4.Value = m_Variables[4];
            dynamicValueDisplay8.Value = m_Variables[5];
            dynamicValueDisplay7.Value = m_Variables[6];
            dynamicValueDisplay6.Value = m_Variables[7];
            dynamicValueDisplay5.Value = m_Variables[8];
            dynamicValueDisplay12.Value = m_Variables[9];
            dynamicValueDisplay11.Value = m_Variables[10];
            dynamicValueDisplay10.Value = m_Variables[11];
            SubTypeDispaly.Value = m_Variables[(int)EventObject.ShipVariables.SubType];
            dynamicValueDisplay16.Value = m_Variables[13];
            dynamicValueDisplay15.Value = m_Variables[14];
            dynamicValueDisplay14.Value = m_Variables[15];
            dynamicValueDisplay13.Value = m_Variables[(int)EventObject.ShipVariables.CustomShipNameID];
            dynamicValueDisplay19.Value = m_Variables[17];
            dynamicValueDisplay18.Value = m_Variables[(int)EventObject.ShipVariables.Hull];
            dynamicValueDisplay17.Value = m_Variables[19];

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AutoReloader.Enabled = checkBox1.Checked;
        }

        private void AutoReloader_Tick(object sender, EventArgs e)
        {
            foreach (var item in m_Variables)
                item.ReloadFromMemory();
            Reload();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadVariables((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }
    }
}
