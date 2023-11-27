using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;

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
            TypeData typeData;
            switch (Program.GameHook.GetMainType(mainType))
            {
                case GameHook.GeneralMainType.Bullet:
                    typeData = Program.GameHook.GetTypeData_Bullet(subType);
                    break;
                case GameHook.GeneralMainType.Sector:
                    typeData = Program.GameHook.GetTypeData_Sector(subType);
                    break;
                case GameHook.GeneralMainType.Background:
                    typeData = Program.GameHook.GetTypeData_Background(subType);
                    break;
                case GameHook.GeneralMainType.Sun:
                    typeData = Program.GameHook.GetTypeData_Sun(subType);
                    break;
                case GameHook.GeneralMainType.Planet:
                    typeData = Program.GameHook.GetTypeData_Planet(subType);
                    break;
                case GameHook.GeneralMainType.Dock:
                    typeData = Program.GameHook.GetTypeData_Dock(subType);
                    break;
                case GameHook.GeneralMainType.Factory:
                    typeData = Program.GameHook.GetTypeData_Factory(subType);
                    break;
                case GameHook.GeneralMainType.Ship:
                    typeData = Program.GameHook.GetTypeData_Ship(subType);
                    break;
                case GameHook.GeneralMainType.Laser:
                    typeData = Program.GameHook.GetTypeData_Laser(subType);
                    break;
                default:
                    return;
            }
            namedTextBox1.Text = typeData.pThis.ToString("X");
            typeDataView1.LoadObject(typeData);
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
