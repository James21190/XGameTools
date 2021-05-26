using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Sector;

namespace XCommonLib.UI
{
    public partial class SectorObjectView : UserControl
    {

        private SectorObject m_SectorObject;

        public SectorObjectView()
        {
            InitializeComponent();
        }

        public void LoadObject(SectorObject obj)
        {
            m_SectorObject = obj;
            Reload();
        }

        public void Reload()
        {
            numericIDObjectControl1.LoadObject(m_SectorObject);

            nnudSpeed.Value = m_SectorObject.Speed;
            nnudDesiredSpeed.Value = m_SectorObject.DesiredSpeed;

            vec3EulerRotation.Vector = m_SectorObject.EulerRotation;
            vec3LocalEulerRotationDelta.Vector = m_SectorObject.LocalEulerRotationDelta;
            vec3AutopilotRotationDeltaTarget.Vector = m_SectorObject.LocalAutopilotRotationDeltaTarget;
            vec3Position.Vector = m_SectorObject.Position;
            vec3PositionStrafeDelta.Vector = m_SectorObject.PositionStrafeDelta;
        }
    }
}
