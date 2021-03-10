using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases.Story.Scripting;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    public partial class ScriptMemorySearcher : Form
    {
        public ScriptMemorySearcher()
        {
            InitializeComponent();
        }

        private DynamicValue m_SearchValue;

        public void Search(DynamicValue value)
        {
            m_SearchValue = value;
            bwScriptInstance.RunWorkerAsync();
            bwScriptArray.RunWorkerAsync();
        }

        private void ScriptInstanceSearcher_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var storyBase = GameHook.storyBase;
            int counter = 0;
            int count = storyBase.pHashTable_ScriptInstance.obj.Count;
            foreach(var obj in storyBase.pHashTable_ScriptInstance.obj.GetAllContents())
            {
                if (obj != null)
                    for (int addr = 0; addr < obj.pSub.obj.ScriptVariableCount; addr++)
                    {
                        if(obj.pScriptVariableArr.GetObjInArrayAsType<DynamicValue>(addr) == m_SearchValue)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lstScriptInstance.Items.Add(obj.NegativeID);
                            }));
                            break;
                        }
                    }
                bwScriptInstance.ReportProgress((++counter * 100)/count);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbScriptInstance.Value = e.ProgressPercentage;
        }

        private void bwScriptArray_DoWork(object sender, DoWorkEventArgs e)
        {
            var storyBase = GameHook.storyBase;
            int counter = 0;
            int count = storyBase.pHashTable_ScriptArrayObject.obj.Count;
            var arrays = storyBase.pHashTable_ScriptArrayObject.obj.GetAllContents();
            foreach (var obj in arrays)
            {
                if(obj != null)
                    for(int i = 0; i < obj.Length; i++)
                    {
                        if (obj.pDynamicValueArr[i] == m_SearchValue)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lstScriptArray.Items.Add(obj.ID);
                            }));
                            break;
                        }
                    }

                bwScriptArray.ReportProgress((++counter * 100) / count);
            }
        }

        private void bwScriptArray_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbScriptArray.Value = e.ProgressPercentage;
        }
    }
}
