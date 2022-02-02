using System.Windows.Forms;
using XCommonLib.RAM;

namespace XRAMTool.Bases.Sector
{
    public partial class TypeData_Display : Form
    {
        public TypeData_Display()
        {
            InitializeComponent();
        }

        private void LoadSubTypes(short mainType)
        {
            cmbSubType.Items.Clear();
            for(short i = 0; i < Program.GameHook.TypeData_Counts[mainType]; i++)
            {
                cmbSubType.Items.Add(Program.GameHook.DataFileManager.GetSectorObjectTypeName(mainType, i));
            }
        }

        private void LoadSubType(short mainType, short subType)
        {
            switch (Program.GameHook.GetMainType(mainType))
            {
                case GameHook.GeneralMainType.Ship:
                    var shipTypeData = Program.GameHook.GetTypeData_Ship(subType);
                    typeDataView1.LoadObject(shipTypeData);
                    break;
            }
        }

        private void cmbMainType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadSubTypes((short)cmbMainType.SelectedIndex);
        }

        private void TypeData_Display_Load(object sender, System.EventArgs e)
        {
            for(short i = 0; i < GameHook.MainTypeCount; i++)
            {
                cmbMainType.Items.Add(Program.GameHook.GetMainTypeName(i));
            }
        }

        private void cmbSubType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadSubType((short)cmbMainType.SelectedIndex, (short)cmbSubType.SelectedIndex);
        }
    }
}
