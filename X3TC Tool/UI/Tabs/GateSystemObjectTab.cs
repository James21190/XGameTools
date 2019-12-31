using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X3TC_Tool
{
    partial class X3TCToolForm
    {
        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex >= 1 && e.RowIndex >=0)
                LoadSector((short)(e.ColumnIndex-1), (short)e.RowIndex);
        }

        public void LoadSector(short X, short Y)
        {
            var sector = m_GameHook.gateSystemObject.GetSector(X, Y);
            textBox22.Text = m_GameHook.gateSystemObject.GetSectorName(X, Y);
            textBox23.Text = string.Format("({0},{1})", X, Y);

            textBox13.Text = sector.owner.ToString();
            textBox14.Text = sector.unknown_1.ToString();
            textBox15.Text = sector.unknown_2.ToString();
            textBox16.Text = sector.unknown_3.ToString();
            textBox17.Text = sector.unknown_4.ToString();
            textBox18.Text = sector.unknown_5.ToString();
            textBox19.Text = sector.unknown_6.ToString();
            textBox20.Text = sector.unknown_7.ToString();
            textBox21.Text = sector.unknown_8.ToString();

            var gates = sector.gateData;

            dataGridView4.Rows.Clear();
            int i = 0;
            foreach(var gate in gates)
            {
                dataGridView4.Rows.Add(((X3TCTools.SectorObjects.SectorObject.Gate_Sub_Type)i++).ToString(), m_GameHook.gateSystemObject.GetSectorName(gate.DstSecX, gate.DstSecY), ((X3TCTools.SectorObjects.SectorObject.Gate_Sub_Type)gate.DstGateID).ToString(), gate.Unknown_1, gate.Unknown_2, gate.Unknown_3, gate.Position, gate.Unknown_4);
            }
        }
    }
}
