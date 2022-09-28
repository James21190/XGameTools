using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Sector.SectorObject_TypeData;

namespace XCommonLib.UI.Bases.Sector.TypeData
{
    public partial class TypeDataShipSubView : UserControl
    {
        public TypeDataShipSubView()
        {
            InitializeComponent();
        }

        private TypeData_Ship _TypeData;

        public void LoadObject(TypeData_Ship obj)
        {
            _TypeData = obj;
            Reload();
        }

        public void Reload()
        {
            nnudExteriorModelID.Value = _TypeData.ExteriorModelID;
            nnudMaxSpeed.Value = _TypeData.MaxSpeed;
            nnudOriginRace.Value = _TypeData.OriginRace;
            nnudTurretCount.Value = _TypeData.TurretCount;

            cmbTurretSelect.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                if(i < _TypeData.TurretCount)
                {
                    var turretData = _TypeData.GetTurretData(i);

                    cmbTurretSelect.Items.Add(i.ToString() + " - ");
                }
                else
                {
                    cmbTurretSelect.Items.Add(i.ToString() + " - Uninitialized");
                }

            }
        }

        private void cmbTurretSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTurretSelect.SelectedIndex == -1 || cmbTurretSelect.SelectedIndex > _TypeData.TurretCount)
                return;
            var turretData = _TypeData.GetTurretData(cmbTurretSelect.SelectedIndex);

            nnudTurretWeaponCount.Value = turretData.WeaponCount;
        }
    }
}
