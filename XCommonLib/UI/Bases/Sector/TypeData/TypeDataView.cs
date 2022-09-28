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
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;

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

        Control subView = null;

        public void Reload()
        {
            nnudBodyID.Value = m_TypeData.BodyID;
            nnudClass.Value = m_TypeData.ObjectClass;
            nnudDefaultName.Value = m_TypeData.DefaultNameId;
            ntxtTypeName.Text = m_TypeData.pTypeName.obj.Value;

            // Load sub typedata views
            if(m_TypeData is TypeData_Ship)
            {
                TypeDataShipSubView shipSubView;
                if(subView == null)
                {
                    shipSubView = new TypeDataShipSubView();
                    groupBox1.Controls.Add(shipSubView);
                    shipSubView.Dock = DockStyle.Fill;
                    subView = shipSubView;
                }
                else
                    shipSubView = (TypeDataShipSubView)subView;

                shipSubView.LoadObject((TypeData_Ship)m_TypeData);
            }
            else
            {
                if(subView != null)
                {
                    groupBox1.Controls.Remove(subView);
                    subView = null;
                }
            }
        }

        private void TypeDataView_Load(object sender, EventArgs e)
        {

        }
    }
}
