using System;
using System.ComponentModel;
using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases.StoryBase_Objects.Scripting;

namespace X3TCTool
{
    public partial class ScriptingObjectPannel : UserControl
    {
        private ScriptingObject m_ScriptingObject;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler ScriptingObjectLoaded;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get => IDNumericUpDown.ReadOnly;
            set
            {
                IDNumericUpDown.ReadOnly = value;
                LoadIDButton.Enabled = !value;
            }
        }

        public ScriptingObject ScriptingObject
        {
            get => m_ScriptingObject;
            set
            {
                m_ScriptingObject = value;
                Reload();
            }
        }
        public ScriptingObjectPannel()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            if (m_ScriptingObject == null)
            {
                return;
            }

            m_ScriptingObject.ReloadFromMemory();
            IDNumericUpDown.Value = m_ScriptingObject.NegativeID;
            AddressBox.Text = m_ScriptingObject.pThis.ToString("X");
            ScriptsOnStackBox.Text = m_ScriptingObject.ReferenceCount.ToString();

            ReloadSub();
        }

        private void ReloadSub()
        {
            ScriptingObjectSub sub = m_ScriptingObject.pSub.obj;
            txtSubAddress.Text = sub.pThis.ToString("X");
            txtSubTypeID.Text = sub.Class.ToString();
            txtSubLength.Text = sub.ScriptVariableCount.ToString();
            txtSubType.Text = m_ScriptingObject.ObjectType.ToString();
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptingObject = GameHook.storyBase.GetScriptingObject((int)IDNumericUpDown.Value);
                if (ScriptingObjectLoaded != null)
                {
                    ScriptingObjectLoaded(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            {
                AddressBox.Text = "Not found!";
            }
        }
    }
}
