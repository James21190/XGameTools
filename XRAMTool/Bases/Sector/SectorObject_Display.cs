using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector;
using XRAMTool.Bases.B3D;
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

        // Load a SectorObject
        public void LoadObject(SectorObject obj)
        {
            m_SectorObject = obj;
            Reload();
        }

        /// <summary>
        /// Reload all elements of the GUI
        /// </summary>
        public void Reload()
        {
            m_SectorObject.ReloadFromMemory();
            sectorObjectView1.LoadObject(m_SectorObject);

            Text = "SectorObject - " + Program.GameHook.DataFileManager.GetSectorObjectTypeName(m_SectorObject.ObjectType);

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
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is SectorObject)
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

        /// <summary>
        /// A threaded method that generates the tree view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwTreeReloader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bgwTreeReloader.ReportProgress(50);
            // Get list of
            List<TreeNode> nodeCollection = new List<TreeNode>();

            TreeNode currentSelection = null;
            TreeNode selectedNode = null;
            foreach (SectorObject sectorObject in Program.GameHook.SectorBase.GetSectorObjects(true))
            {
                nodeCollection.Add(GetSectorObjectTreeNode(sectorObject, out currentSelection));
                // Generate tree node, and if the current SectorObject was generated within the node, select it.
                if (selectedNode == null && currentSelection != null)                {
                    selectedNode = currentSelection;
                }
            }

            treeView1.Invoke(new Action(() =>
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.AddRange(nodeCollection.ToArray());
                treeView1.SelectedNode = selectedNode;
                if(selectedNode != null)
                    selectedNode.Expand();
            }));

            bgwTreeReloader.ReportProgress(100);
        }

        private void bgwTreeReloader_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pgbTreeLoading.Value = e.ProgressPercentage;
        }

        private void bgwTreeReloader_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                throw e.Error;
            }
        }

        private void btnLoadRenderObject_Click(object sender, EventArgs e)
        {
            var renderObjectDisplay = new RenderObject_Display();
            renderObjectDisplay.LoadObject(m_SectorObject.RenderObject);
            renderObjectDisplay.Show();
        }

        private void SectorObject_Display_Load_1(object sender, EventArgs e)
        {
            btnLoadScriptInstance.Enabled = Program.GameHook.StoryBaseAvailable;
        }
    }
}
