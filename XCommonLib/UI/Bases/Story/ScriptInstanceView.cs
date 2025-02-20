﻿using System;
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

            // Display type name
            string typeName = m_ScriptInstance.Class.ToString();
            if (ReferenceGameHook != null)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(m_ScriptInstance.Class);
                if (typeData != null)
                {
                    if (typeData.ParentType != null)
                    {
                        typeName = string.Format("{0} : {1}", typeData.Name, typeData.ParentType.Name);
                    }
                    else
                    {
                        typeName = typeData.Name;
                    }
                }
            }
            namedTextBox1.Text = typeName;

            listBox1.Items.Clear();
            foreach(var c in m_ScriptInstance.Classes)
            {
                var data = ReferenceGameHook.DataFileManager.GetScriptInstanceType(c);
                if (data != null)
                    listBox1.Items.Add(data.Name);
                else
                    listBox1.Items.Add(c.ToString());
            }

            var functions = m_ScriptInstance.Functions;
            listBox2.Items.Clear();


            foreach(var func in functions)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(func.Class);
                if(typeData != null)
                {
                    typeName = typeData.Name;
                }
                else
                {
                    typeName = func.Class.ToString();
                }
                listBox2.Items.Add(typeName + ":" + ReferenceGameHook.StoryBase.GetStringFromArray(func.Function.StringOffset).Value);
            }

            // Reload memory table
            ReloadMemoryTable();
        }

        public void ReloadMemoryTable()
        {
            var arrValues = m_ScriptInstance.pScriptVariableArr.ToArray(m_ScriptInstance.ScriptVariableCount);

            // Load variables if available
            if(ReferenceGameHook != null)
            {
                var typeData = ReferenceGameHook.DataFileManager.GetScriptInstanceType(m_ScriptInstance.Class);
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
