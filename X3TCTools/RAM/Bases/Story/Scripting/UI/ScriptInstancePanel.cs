using System;
using System.ComponentModel;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3Tools.RAM
{
    public partial class ScriptingObjectPannel : UserControl
    {
        private ScriptInstance m_ScriptingObject;

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

        public ScriptInstance ScriptingObject
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
            ScriptInstanceSub sub = m_ScriptingObject.pSub.obj;
            txtSubAddress.Text = sub.pThis.ToString("X");
            txtSubTypeID.Text = sub.Class.ToString();
            txtSubLength.Text = sub.ScriptVariableCount.ToString();
            if (m_ScriptingObject.ScriptInstanceType != null)
                txtSubType.Text = m_ScriptingObject.ScriptInstanceType.ToString();
            else
                txtSubType.Text = "Undefined";
            #region Functions
            txtFunctionCount1.Text = sub.FunctionCount_1.ToString();
            lstbxFunctions.Items.Clear();
            for(int i = 0; i < sub.FunctionCount_1; i++)
            {
                lstbxFunctions.Items.Add(sub.pFunctions[i].str);
            }
            #endregion
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
