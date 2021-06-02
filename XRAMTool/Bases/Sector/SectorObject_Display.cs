using System;
using System.Drawing;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector;

namespace XRAMTool.Bases.Sector
{
    public partial class SectorObject_Display : Form
    {
        public SectorObject_Display()
        {
            InitializeComponent();
            sectorObjectView1.ReferenceGameHook = Program.GameHook;
        }

        public void LoadObject(SectorObject obj)
        {
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
                nodeCollection.Add(GetSectorObjectTreeNode(sectorObject));
            }
        }

        private TreeNode GetSectorObjectTreeNode(SectorObject sectorObject)
        {
            TreeNode node = new TreeNode
            {
                Text = sectorObject.DefaultName.Value,
                Tag = sectorObject,
                BackColor = GetRaceColor(sectorObject.RaceID)
            };

            // Check getting meta
            if (sectorObject.Meta != null)
            {
                // For every MainType
                for (int i = 0; i < GameHook.MainTypeCount; i++)
                {
                    // Get children with MainType
                    SectorObject[] children = sectorObject.Meta.GetChildren(i);
                    if (children != null && children.Length > 0)
                    {
                        // If there are children with the given MainType, append it and it's children.
                        TreeNode childrenNode = new TreeNode(Program.GameHook.GetMainTypeName(i));
                        foreach (SectorObject child in children)
                        {
                            childrenNode.Nodes.Add(GetSectorObjectTreeNode(child));
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
                case "Unowned": return Color.Gray;
                default: return Color.White;
            }
        }

        private void SectorObject_Display_Load(object sender, EventArgs e)
        {
        }
    }
}
