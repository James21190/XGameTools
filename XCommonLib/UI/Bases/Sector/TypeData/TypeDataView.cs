using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM;

namespace XCommonLib.UI.Bases.Sector.TypeData
{
    public partial class TypeDataView : UserControl
    {
        public GameHook ReferenceGameHook = null;
        public TypeDataView()
        {
            InitializeComponent();
        }

        private XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData m_TypeData;

        public void LoadObject(XCommonLib.RAM.Bases.Sector.SectorObject_TypeData.TypeData typeData)
        {
            m_TypeData = typeData;
            Reload();
        }

        public void Reload()
        {
            nnudBodyID.Value = m_TypeData.BodyID;
            nnudClass.Value = m_TypeData.ObjectClass;
            nnudDefaultName.Value = m_TypeData.DefaultNameId;
        }

        private void TypeDataView_Load(object sender, EventArgs e)
        {

        }
    }
}
