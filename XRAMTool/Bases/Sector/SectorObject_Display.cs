using System;
using System.Drawing;
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
            sectorObjectView1.LoadObject(obj);
            RepopulateTree();
        }

        public void Reload()
        {
            RepopulateTree();
        }

        public void RepopulateTree()
        {
            treeView1.Nodes.Clear();
            TreeNodeCollection nodeCollection = treeView1.Nodes;
            foreach (SectorObject sectorObject in Program.GameHook.SectorBase.GetSectorObjects())
            {
                TreeNode currentSelection;
                nodeCollection.Add(GetSectorObjectTreeNode(sectorObject, out currentSelection));
                if (currentSelection != null)
                {
                    treeView1.SelectedNode = currentSelection;
                    currentSelection.Expand();
                }
            }
        }

        private TreeNode GetSectorObjectTreeNode(SectorObject sectorObject, out TreeNode currentSelection)
        {
            TreeNode node = new TreeNode
            {
                //Text = Program.GameHook.StoryBase.GetParsedText(44,sectorObject.DefaultName.Value),
                Text = Program.GameHook.DataFileManager.GetSectorObjectTypeName(sectorObject.ObjectType),
                Tag = sectorObject,
                BackColor = GetRaceColor(sectorObject.RaceID)
            };

            if (m_SectorObject.ID == sectorObject.ID)
                currentSelection = node;
            else
                currentSelection = null;

            // Check getting meta
            if (sectorObject.Meta != null)
            {
                // For every MainType
                for (int i = 0; i < GameHook.MainTypeCount; i++)
                {
                    // Get children with MainType
                    SectorObject[] children = sectorObject.Meta.GetChildren(i);
                    Array.Sort(children);
                    if (children != null && children.Length > 0)
                    {
                        // If there are children with the given MainType, append it and it's children.
                        TreeNode childrenNode = new TreeNode(string.Format("{0} ({1})",Program.GameHook.GetMainTypeName(i), children.Length));
                        foreach (SectorObject child in children)
                        {
                            TreeNode tempNode;
                            childrenNode.Nodes.Add(GetSectorObjectTreeNode(child, out tempNode));
                            if (tempNode != null)
                                currentSelection = tempNode;
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

        private static Color GetRaceColor(ushort raceID)
        {
            switch (Program.GameHook.GetRaceIDName(raceID))
            {
                case "Argon": return Color.Aqua;
                case "Boron": return Color.SeaGreen;
                case "Split": return Color.Orange;
                case "Teladi": return Color.GreenYellow;
                case "Paranid": return Color.YellowGreen;
                case "Gonor": return Color.Chartreuse;
                case "Khaak": return Color.Purple;
                case "Xenon": return Color.IndianRed;
                case "Player": return Color.LawnGreen;
                case "Unowned": return Color.Gray;
                default: return Color.White;
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
    }
}
