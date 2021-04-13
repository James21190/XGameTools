using Common.Memory;
using System;
using System.Windows.Forms;
using X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Generics;
using X3Tools.RAM.Bases.Sector;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class SectorObjectDisplay : Form
    {
        private SectorObject m_SectorObject;
        public SectorObjectDisplay()
        {
            InitializeComponent();
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                ChildTypeSelectionBox.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }


        private void LoadTree(int autoLoadID = 0, SectorObject baseSectorObject = null)
        {
            // If base is null, assume it to be space.
            if (baseSectorObject == null)
            {
                baseSectorObject = GameHook.sectorObjectManager.GetSpace();
            }

            treeView1.Nodes.Clear();
            TreeNode selectedNode;
            treeView1.Nodes.Add(GenerateTreeNode(baseSectorObject, autoLoadID, out selectedNode));
            if (selectedNode != null)
            {
                treeView1.SelectedNode = selectedNode;
                selectedNode.Expand();
            }

        }
        private TreeNode GenerateTreeNode(SectorObject baseSectorObject, int selectedID, out TreeNode selectedNode)
        {
            string sectorObjectName;
            switch (baseSectorObject.ObjectType.MainTypeEnum)
            {
                /*case SectorObject.Main_Type.Gate:
                    IScriptMemoryObject_Gate gateScriptMemoryObject = baseSectorObject.ScriptInstance.GetMemoryInterfaceGate();
                    if (gateScriptMemoryObject == null) goto skip;
                    sectorObjectName = string.Format("{0} ({1})", baseSectorObject.GetSubTypeAsString(), GameHook.galaxyBase.GetSectorName(gateScriptMemoryObject.DestSectorX, gateScriptMemoryObject.DestSectorY));
                    break;*/
                default:
                    skip:
                    sectorObjectName = baseSectorObject.GetSubTypeAsString(); 
                    break;
            }

            TreeNode newNode = new TreeNode(sectorObjectName)
            {
                //Add tag
                Tag = baseSectorObject
            };

            // If sectorObject is selected object, set selectedNode
            selectedNode = (baseSectorObject.ID == selectedID) ? newNode : null;


            // Give node a color based on it's owning race.
            newNode.BackColor = GameHook.GetRaceColor(baseSectorObject.RaceID);

            // Append children to the tree.
            for (int mainType = 0; mainType < SectorObject.MAIN_TYPE_COUNT; mainType++)
            {
                SectorObject[] children = baseSectorObject.GetAllChildrenWithType(mainType);

                // Sort children
                Array.Sort(children);
                Array.Reverse(children);

                if (children.Length > 0) // Check if node will have contents, if so continue.
                {
                    TreeNode childNode = newNode.Nodes.Add(string.Format("Type {0} ({1})", ((SectorObject.Main_Type)mainType).ToString(), children.Length));

                    foreach (SectorObject child in children)
                    {
                        TreeNode childSelectedNode;
                        childNode.Nodes.Add(GenerateTreeNode(child, selectedID, out childSelectedNode));
                        if (childSelectedNode != null)
                        {
                            selectedNode = childSelectedNode;
                        }
                    }
                }
            }

            return newNode;
        }


        public void LoadObject(SectorObject sectorObject)
        {
            m_SectorObject = sectorObject;
            Reload();
        }

        public void Reload()
        {

            // Sector Info
            SectorObject sector = GameHook.sectorObjectManager.GetSpace();

            if(m_SectorObject != null && m_SectorObject.IsValid)
            {

                // Reload from memory to ensure it is up to date.
                m_SectorObject.ReloadFromMemory();

                // Load tree if not auto reloading
                if (!AutoReloadCheckBox.Checked)
                {
                    LoadTree(m_SectorObject.ID);
                }

                numericIDObjectControl1.LoadObject(m_SectorObject);

                txtDefaultName.Text = GameHook.storyBase.GetParsedText(GameHook.systemBase.Language, MemoryControl.ReadNullTerminatedString(GameHook.hProcess, m_SectorObject.pDefaultName.address));
                v3dPosition.Vector = m_SectorObject.Position_Copy;
                v3dPositionKm.X = ((decimal)m_SectorObject.Position_Copy.X) / 500000;
                v3dPositionKm.Y = ((decimal)m_SectorObject.Position_Copy.Y) / 500000;
                v3dPositionKm.Z = ((decimal)m_SectorObject.Position_Copy.Z) / 500000;
                v3dRotation.Vector = m_SectorObject.EulerRotationCopy;
                ScriptingObjectPannel1.ScriptingObject = m_SectorObject.ScriptInstance;
                txtType.Text = string.Format("{0} - {1} // {2} - {3}", m_SectorObject.ObjectType.MainTypeEnum.ToString(), m_SectorObject.GetSubTypeAsString(), (int)m_SectorObject.ObjectType.MainTypeEnum, m_SectorObject.ObjectType.SubType);

                SpeedBox.Value = m_SectorObject.Speed;
                TargetSpeedBox.Value = m_SectorObject.TargetSpeed;
                nudMass.Value = m_SectorObject.Mass;

                txtRace.Text = m_SectorObject.RaceID.ToString();

                ModelCollectionIDBox.Text = m_SectorObject.ModelCollectionID.ToString();


                // Object relation
                // If auto reloading, disable buttons
                btnGoNext.Enabled = m_SectorObject.pNext.IsValid && m_SectorObject.pNext.obj.IsValid && !AutoReloadCheckBox.Enabled;
                btnGoPrevious.Enabled = m_SectorObject.pPrevious.IsValid && m_SectorObject.pPrevious.obj.IsValid && !AutoReloadCheckBox.Enabled;
                btnGoParent.Enabled = m_SectorObject.pParent.IsValid && m_SectorObject.pParent.obj.IsValid && !AutoReloadCheckBox.Enabled;


                ReloadChildren();
            }
            // If invalid
            else
            {
                txtType.Text = "Invalid Object!";
            }

        }

        public void ReloadChildren()
        {
            if (ChildTypeSelectionBox.SelectedIndex < 0)
            {
                goto failed;
            }

            X3Tools.RAM.Bases.Sector.Meta.ISectorObjectMeta meta = m_SectorObject.GetMeta();
            if (meta == null || meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null || meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null)
            {
                goto failed;
            }

            FirstChildButton.Enabled = true;
            LastChildButton.Enabled = true;
            return;

        failed:
            FirstChildButton.Enabled = false;
            LastChildButton.Enabled = false;
            return;
        }

        private void AutoReloader_Tick(object sender, EventArgs e)
        {
            if (m_SectorObject.IsValid)
            {
                Reload();
            }
            else
            {
                m_SectorObject = null;
                AutoReloadCheckBox.Checked = false;
            }
        }

        private void AutoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoReloader.Enabled = AutoReloadCheckBox.Checked;
            treeView1.Enabled =
                groupBox6.Enabled =
                !AutoReloadCheckBox.Checked;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pPrevious.obj);
        }

        private void ParentButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pParent.obj);
        }

        private void ChildTypeSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadChildren();
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            X3Tools.RAM.Bases.Sector.Meta.ISectorObjectMeta meta = m_SectorObject.GetMeta();
            SectorObject child = meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if (child != null)
            {
                LoadObject(child);
            }
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            X3Tools.RAM.Bases.Sector.Meta.ISectorObjectMeta meta = m_SectorObject.GetMeta();
            SectorObject child = meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if (child != null)
            {
                LoadObject(child);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RenderObjectDisplay display = new RenderObjectDisplay();
            display.LoadObject(m_SectorObject.pRenderObject.obj);
            display.Show();
        }

        private void typeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDataDisplay display = new TypeDataDisplay();
            display.LoadTypeData((int)m_SectorObject.ObjectType.MainTypeEnum, m_SectorObject.ObjectType.SubType);
            display.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Tag == null)
            {
                return;
            }

            SectorObject newSO = (SectorObject)e.Node.Tag;
            if (m_SectorObject == newSO)
            {
                return;
            }

            LoadObject(newSO);
        }

        private void sectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadObject(GameHook.sectorObjectManager.GetSpace());
        }

        private void playerShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadObject(GameHook.sectorObjectManager.GetPlayerObject());
        }

        private void SectorObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void spawnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeSelectDialog selector = new TypeSelectDialog();
            selector.ShowDialog();
            if (selector.Done)
            {
                GameHook.gameCodeRunner.CreateSectorObject(selector.MainType, selector.SubType, GameHook.sectorObjectManager.GetSpace());
            }
        }

        private void btnLoadScriptingObject_Click(object sender, EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(m_SectorObject.ScriptInstanceID);
            display.Show();
        }

        private void numericIDObjectControl1_AddressLoad(object sender, int value)
        {
            LoadObject(GameHook.sectorObjectManager.GetSectorObject((IntPtr)value));
        }

        private void numericIDObjectControl1_IDLoad(object sender, int value)
        {
            LoadObject(GameHook.sectorObjectManager.GetSectorObject(value));
        }
    }
}
