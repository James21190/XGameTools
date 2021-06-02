using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.B3D;
using X3Tools.RAM.Generics;

namespace X3TC_RAM_Tool.UI.Bases.CameraBase_Displays
{
    public partial class BodyDataDisplay : Form
    {
        public BodyDataDisplay()
        {
            InitializeComponent();
        }

        private BodyData m_BodyData;
        public void LoadBodyData(BodyData bodyData)
        {
            m_BodyData = bodyData;
            Reload();
        }
        public void LoadBodyData(int id)
        {
            try
            {
                LoadBodyData(GameHook.b3DBase.GetBodyData(id));
            }
            catch (HashTableElementNotFoundException)
            {

            }
        }
        public void Reload()
        {
            m_BodyData.ReloadFromMemory();

            numericIDObjectControl1.LoadObject(m_BodyData);

        }
    }
}
