using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector;

namespace XCommonLib.UI
{
    public partial class SectorObjectView : UserControl
    {

        private SectorObject m_SectorObject;

        public GameHook ReferenceGameHook = null;

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

            vec3EulerRotation.Vector = m_SectorObject.EulerRotationCopy;
            vec3LocalEulerRotationDelta.Vector = m_SectorObject.LocalEulerRotationDelta;
            vec3AutopilotRotationDeltaTarget.Vector = m_SectorObject.LocalAutopilotRotationDeltaTarget;
            vec3Position.Vector = m_SectorObject.CopyPosition;
            vec3PositionStrafeDelta.Vector = m_SectorObject.PositionStrafeDelta;

            ntxtDefaultName.Text = m_SectorObject.DefaultName.Value;
            ntxtDefaultNameParsed.Text = ReferenceGameHook.StoryBase.GetParsedText(44, m_SectorObject.DefaultName.Value);

            ntxtType.Text = m_SectorObject.ObjectType.ToString();

            //bitFieldDisplay1.Value = m_SectorObject.InteractionFlags;

            if (ReferenceGameHook != null)
            {
                ntxtRace.Text = string.Format("{0} - {1}", m_SectorObject.RaceID, ReferenceGameHook.GetRaceIDName(m_SectorObject.RaceID));
            }
            else
            {
                ntxtRace.Text = m_SectorObject.RaceID.ToString();
            }
        }
    }
}
