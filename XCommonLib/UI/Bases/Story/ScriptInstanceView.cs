using System;
using System.ComponentModel;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.UI.Bases.Story
{
    public partial class ScriptInstanceView : UserControl
    {
        private ScriptInstance m_ScriptInstance;
        public GameHook ReferenceGameHook = null;
        public ScriptInstanceView()
        {
            InitializeComponent();
        }

        public void LoadObject(ScriptInstance obj)
        {
            m_ScriptInstance = obj;
            Reload();
        }
        public void Reload()
        {
            numericIDObjectControl1.LoadObject(m_ScriptInstance);
            nnudReferenceCount.Value = m_ScriptInstance.ReferenceCount;
            ntxtMemoryAddress.Text = m_ScriptInstance.pScriptVariableArr.PointedAddress.ToString("X");

            lstClassStructure.Items.Clear();
            foreach(var c in m_ScriptInstance.GetClassStructure())
            {
                var data = ReferenceGameHook.DataFileManager.GetScriptInstanceType(c);
                if (data != null)
                    lstClassStructure.Items.Add(data.Name);
                else
                    lstClassStructure.Items.Add(c.ToString());
            }

            var functions = m_ScriptInstance.GetAllFunctions();
            lstFunctions.Items.Clear();


            foreach(var func in functions)
            {
                string typeName;
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(func.Class);
                if(typeData != null)
                {
                    typeName = typeData.Name;
                }
                else
                {
                    typeName = func.Class.ToString();
                }
                lstFunctions.Items.Add(typeName + "." + ReferenceGameHook.StoryBase.GetStringFromArray(func.Function.StringOffset).Value);
            }

            // Reload memory table
            ReloadMemoryTable();
        }

        public void ReloadMemoryTable()
        {
            var arrValues = m_ScriptInstance.pScriptVariableArr.ToArray(m_ScriptInstance.TypeDef.ScriptMemoryLength);

            // Load variables if available
            if(ReferenceGameHook != null)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(m_ScriptInstance.TypeDef.Class);
                if(typeData != null)
                    scriptVariableArrayView1.Variables = typeData.Variables;
            }

            scriptVariableArrayView1.DynamicValues = arrValues;
        }

        private void numericIDObjectControl1_AddressLoad(object sender, int value)
        {
            if(ReferenceGameHook != null)
            {
                m_ScriptInstance = ReferenceGameHook.StoryBase.GetScriptInstance((IntPtr)value);
                Reload();
            }
        }

        private void numericIDObjectControl1_IDLoad(object sender, int value)
        {
            if (ReferenceGameHook != null)
            {
                m_ScriptInstance = ReferenceGameHook.StoryBase.GetScriptInstance(value);
                Reload();
            }
        }

        public event ScriptVariableArrayView.RequestViewHandler RequestVariableView;

        private void scriptVariableArrayView1_RequestView(object sender, ScriptInstanceType.VariableType type, int variableValue, object additional)
        {
            if(RequestVariableView != null)
                RequestVariableView(this, type, variableValue, additional);
        }
    }
}
