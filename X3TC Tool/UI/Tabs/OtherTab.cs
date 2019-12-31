using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;

namespace X3TC_Tool
{
    public partial class X3TCToolForm
    {
        public const int Seperation = 2000000;
        public const int Delay = 20;

        public void ReloadOtherTabUI()
        {
            comboBox2.Items.Clear();

            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                comboBox2.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadAll((SectorObject.Main_Type)comboBox2.SelectedIndex);
        }

        public void LoadAll(SectorObject.Main_Type main_Type)
        {
            var sepMult = 1;
            int SubCount = 1;
            switch (main_Type)
            {
                case SectorObject.Main_Type.Dock: // 5
                    SubCount = SectorObject.DOCK_SUB_TYPE_COUNT;
                    sepMult = 2;
                    break;
                case SectorObject.Main_Type.Factory: // 6
                    SubCount = SectorObject.FACTORY_SUB_TYPE_COUNT;
                    sepMult = 2;
                    break;
                case SectorObject.Main_Type.Ship: // 7
                    SubCount = SectorObject.SHIP_SUB_TYPE_COUNT;
                    break;
            }

            for(int i = 0; i < SubCount; i++)
            {
                var newSectorObject = m_GameHook.GameCodeRunner.CreateSectorObject(main_Type, i, m_GameHook.SectorObjectManager.GetSpace());
                var data = newSectorObject.GetData();
                data.Position = new Common.Vector.Vector3((int)main_Type * Seperation * sepMult, 0, i * Seperation * sepMult);
                data.Save(newSectorObject.pData);
                Thread.Sleep(Delay);
            }
        }
    }
}
