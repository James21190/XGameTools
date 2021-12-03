using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector;
using XRAMTool.Bases.Story;

namespace XRAMTool.Bases.Sector
{
    public partial class SectorObject_Display : Form
    {
        public SectorObject_Display()
        {
            InitializeComponent();
            sectorObjectView1.ReferenceGameHook = Program.GameHook;
        }

        private SectorObject m_SectorObject;

        public void LoadObject(SectorObject obj)
        {
            m_SectorObject = obj;
            Reload();
        }

        public void Reload()
        {
            m_SectorObject.ReloadFromMemory();
            sectorObjectView1.LoadObject(m_SectorObject);
            if(!bgwTreeReloader.IsBusy)
                bgwTreeReloader.RunWorkerAsync();

            btnLoadScriptInstance.Text = String.Format("Load ScriptInstance ({0})", m_SectorObject.ScriptInstanceID);
        }

        private TreeNode GetSectorObjectTreeNode(SectorObject sectorObject, out TreeNode currentSelection)
        {
            TreeNode node = new TreeNode
            {
                //Text = Program.GameHook.StoryBase.GetParsedText(44,sectorObject.DefaultName.Value),
                Text = Program.GameHook.DataFileManager.GetSectorObjectTypeName(sectorObject.ObjectType),
                Tag = sectorObject,
                BackColor = Program.GameHook.GetRaceColor(sectorObject.RaceID)
            };

            if (m_SectorObject.ID == sectorObject.ID)
            {
                currentSelection = node;
            }
            else
            {
                currentSelection = null;
            }

            // Check getting meta
            if (sectorObject.Meta != null)
            {
                // For every MainType
                for (short i = 0; i < GameHook.MainTypeCount; i++)
                {
                    // Get children with MainType
                    SectorObject[] children = sectorObject.Meta.GetChildren(i);
                    Array.Sort(children);
                    if (children != null && children.Length > 0)
                    {
                        // If there are children with the given MainType, append it and it's children.
                        TreeNode childrenNode = new TreeNode(string.Format("{0} ({1})", Program.GameHook.GetMainTypeName(i), children.Length));
                        foreach (SectorObject child in children)
                        {
                            TreeNode tempNode;
                            childrenNode.Nodes.Add(GetSectorObjectTreeNode(child, out tempNode));
                            if (tempNode != null)
                            {
                                currentSelection = tempNode;
                            }
                        }
                        node.Nodes.Add(childrenNode);
                    }
                }
            }

            return node;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is SectorObject)
            {
                LoadObject((SectorObject)treeView1.SelectedNode.Tag);
            }
        }

        private void SectorObject_Display_Load(object sender, EventArgs e)
        {
        }

        private void btnLoadScriptInstance_Click(object sender, EventArgs e)
        {
            var display = new ScriptInstance_Display();
            display.LoadObject(Program.GameHook.StoryBase.GetScriptInstance(m_SectorObject.ScriptInstanceID));
            display.Show();
        }

        private void bgwTreeReloader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bgwTreeReloader.ReportProgress(99);
            List<TreeNode> nodeCollection = new List<TreeNode>();
            TreeNode currentSelection = null;
            foreach (SectorObject sectorObject in Program.GameHook.SectorBase.GetSectorObjects())
            {
                nodeCollection.Add(GetSectorObjectTreeNode(sectorObject, out currentSelection));
                if (currentSelection != null)
                {
                    treeView1.SelectedNode = currentSelection;
                    currentSelection.Expand();
                }
            }

            treeView1.Invoke(new Action(() =>
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.AddRange(nodeCollection.ToArray());
                treeView1.SelectedNode = currentSelection;
            }));

            bgwTreeReloader.ReportProgress(100);
        }

        private void bgwTreeReloader_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pgbTreeLoading.Value = e.ProgressPercentage;
        }
    }
}
