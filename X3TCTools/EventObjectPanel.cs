using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3TCTools.Bases.Scripting;
using X3TCTools;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCsTool
{
    public partial class EventObjectPannel : UserControl
    {
        private EventObject m_EventObject;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler EventObjectLoaded;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly 
        {
            get
            {
                 return IDNumericUpDown.ReadOnly;
            }
            set
            {
                IDNumericUpDown.ReadOnly = value;
                LoadIDButton.Enabled = !value;
            }
        }

        public EventObject EventObject
        {
            get
            {
                return m_EventObject;
            }
            set
            {
                m_EventObject = value;
                Reload();
            }
        }
        public EventObjectPannel()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            if (m_EventObject == null) return;
            m_EventObject.ReloadFromMemory();
            IDNumericUpDown.Value = m_EventObject.NegativeID;
            AddressBox.Text = m_EventObject.pThis.ToString("X");
            ScriptsOnStackBox.Text = m_EventObject.ReferenceCount.ToString();

            ReloadSub();
        }

        private void ReloadSub()
        {
            var sub = m_EventObject.pSub.obj;
            txtSubAddress.Text = sub.pThis.ToString("X");
            txtSubTypeID.Text = sub.ID.ToString();
            txtSubLength.Text = sub.ScriptVariableCount.ToString();
            txtSubType.Text = m_EventObject.ObjectType.ToString();
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            try
            {
                EventObject = GameHook.storyBase.GetEventObject((int)IDNumericUpDown.Value);
                if(EventObjectLoaded != null)
                    EventObjectLoaded(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                AddressBox.Text = "Not found!";
            }
        }
    }
}
