﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.SectorObjects;

using Common.Memory;

namespace X3TC_Tool.UI.Displays
{
    public partial class SectorObjectDisplay : Form
    {
        private GameHook m_GameHook;
        private SectorObject m_SectorObject;
        public SectorObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                ChildTypeSelectionBox.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }

        private void LoadTree(int AutoLoadID = 0, bool clear = true, SectorObject baseSectorObject = null, TreeNode baseNode = null)
        {
            if(clear)
                treeView1.Nodes.Clear();
            if(baseSectorObject == null)
                baseSectorObject = m_GameHook.sectorObjectManager.GetSpace();


            var children = baseSectorObject.GetAllChildren(false);

            if (children.Count() == 0)
                return;

            Queue<TreeNode> ToRemove = new Queue<TreeNode>();

            if(baseNode == null)
            {
                
                IsLoadingTree = true;
                for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
                    treeView1.Nodes.Add("Type " + ((SectorObject.Main_Type)i).ToString());
                treeView1.Nodes.Add("Invalid MainType");

                foreach(var child in children)
                {
                    var a = new TreeNode(child.GetSubTypeAsString());
                    a.Tag = child;
                    a.BackColor = GameHook.GetRaceColor(child.RaceID);
                    if ((int)child.MainType < SectorObject.MAIN_TYPE_COUNT)
                    {
                        treeView1.Nodes[(int)child.MainType].Nodes.Add(a);
                        if(child.ObjectID == AutoLoadID)
                        {
                            treeView1.SelectedNode = a;
                        }
                        LoadTree(AutoLoadID, false, child, a);
                    }
                    else
                        treeView1.Nodes[SectorObject.MAIN_TYPE_COUNT].Nodes.Add(a);
                }
                // Remove empty nodes.
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Nodes.Count == 0)
                        ToRemove.Enqueue(node);
                }
                IsLoadingTree = false;
            }
            else
            {
                for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
                    baseNode.Nodes.Add("Type " + ((SectorObject.Main_Type)i).ToString());
                baseNode.Nodes.Add("Invalid MainType");

                foreach (var child in children)
                {
                    var a = new TreeNode(child.GetSubTypeAsString());
                    a.Tag = child;
                    a.BackColor = GameHook.GetRaceColor(child.RaceID);
                    if ((int)child.MainType < SectorObject.MAIN_TYPE_COUNT)
                    {
                        baseNode.Nodes[(int)child.MainType].Nodes.Add(a);
                        if (child.ObjectID == AutoLoadID)
                        {
                            treeView1.SelectedNode = a;
                        }
                        LoadTree(AutoLoadID, false, child, a);
                    }
                    else
                        baseNode.Nodes[SectorObject.MAIN_TYPE_COUNT].Nodes.Add(a);

                }

                // Remove empty nodes.
                foreach (TreeNode node in baseNode.Nodes)
                {
                    if (node.Nodes.Count == 0)
                        ToRemove.Enqueue(node);
                }
            }

            while(ToRemove.Count > 0)
            {
                treeView1.Nodes.Remove(ToRemove.Dequeue());

            }


        }
        public void LoadObject(int ID)
        {
            var sectorObjectManager = m_GameHook.sectorObjectManager;
            var hashtable = sectorObjectManager.pObjectHashTable.obj;
            SectorObject obj;
            try
            {
                obj = hashtable.GetObject(ID);
            }
            catch (Exception)
            {
                AddressBox.Text = "Not Found!";
                return;
            }
            LoadObject(obj);
        }

        public void LoadObject(SectorObject sectorObject)
        {
            m_SectorObject = sectorObject;
            Reload();
        }

        public void Reload()
        {

            m_SectorObject.ReloadFromMemory();
            LoadTree(m_SectorObject.ObjectID);
            AddressBox.Text = m_SectorObject.pThis.ToString("X");
            DefaultNameBox.Text = MemoryControl.ReadNullTerminatedString(m_GameHook.hProcess, m_SectorObject.pDefaultName);
            IDNumericUpDown.Value = m_SectorObject.ObjectID;
            PositionVectorDisplay.Vector = m_SectorObject.Position_Copy;
            PositionKmVectorDisplay.X = ((decimal)m_SectorObject.Position_Copy.X)/500000;
            PositionKmVectorDisplay.Y = ((decimal)m_SectorObject.Position_Copy.Y)/500000;
            PositionKmVectorDisplay.Z = ((decimal)m_SectorObject.Position_Copy.Z)/500000;
            RotationVectorDisplay.Vector = m_SectorObject.EulerRotationCopy;
            EventObjectIDBox.Text = m_SectorObject.EventObjectID.ToString();
            TypeBox.Text = string.Format("{0} - {1} // {2} - {3}", m_SectorObject.MainType.ToString(), m_SectorObject.GetSubTypeAsString(), (int)m_SectorObject.MainType, m_SectorObject.SubType);

            SpeedBox.Value = m_SectorObject.Speed;
            TargetSpeedBox.Value = m_SectorObject.TargetSpeed;

            RaceBox.Text = m_SectorObject.RaceID.ToString();

            ModelCollectionIDBox.Text = m_SectorObject.ModelCollectionID.ToString();

            // Unknowns
            UnknownsListBox.Items.Clear();
            int i = 4;
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_4.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_5));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_6));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_7));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_8));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_9.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_10.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_11));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_12));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_13));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1} {2} {3}", i++, m_SectorObject.Unknown_14_0, m_SectorObject.Unknown_14_1, m_SectorObject.Unknown_14_2));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_16));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_17));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_18));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_19.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_20));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_21.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_22));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_23));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_24.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_25));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_26));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_27));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_28));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_29));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_30));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_31));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_32));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_33));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_34));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_35));


            // Object relation
            NextButton.Enabled = m_SectorObject.pNext.IsValid && m_SectorObject.pNext.obj.IsValid;
            PreviousButton.Enabled = m_SectorObject.pPrevious.IsValid && m_SectorObject.pPrevious.obj.IsValid;
            ParentButton.Enabled = m_SectorObject.pParent.IsValid && m_SectorObject.pParent.obj.IsValid;

            ReloadChildren();
        
        }

        public void ReloadChildren()
        {
            if (ChildTypeSelectionBox.SelectedIndex < 0) goto failed;
            var meta = m_SectorObject.GetMeta();
            if (meta == null || meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null || meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null) goto failed;

            FirstChildButton.Enabled = true;
            LastChildButton.Enabled = true;
            return;

            failed:
                FirstChildButton.Enabled = false;
                LastChildButton.Enabled = false;
            return;
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            LoadObject(Convert.ToInt32(IDNumericUpDown.Value));
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
                AddressBox.Text = "Object Destroyed.";
                AutoReloadCheckBox.Enabled = false;
                AutoReloader.Enabled = false;
            }
        }

        private void AutoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoReloader.Enabled = AutoReloadCheckBox.Checked;
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

        private void EventObjectIDLoadButton_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay(m_GameHook);
            display.LoadObject(m_SectorObject.EventObjectID);
            display.Show();
        }

        private void ChildTypeSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadChildren();
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            var meta = m_SectorObject.GetMeta();
            var child = meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if(child != null)
                LoadObject(child);
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            var meta = m_SectorObject.GetMeta();
            var child = meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if (child != null)
                LoadObject(child);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new SectorObjectDataDisplay(m_GameHook);
            display.LoadData(m_SectorObject.pData.obj);
            display.Show();
        }

        private void typeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var display = new TypeDataDisplay(m_GameHook);
            display.LoadTypeData((int)m_SectorObject.MainType, m_SectorObject.SubType);
            display.Show();
        }

        bool IsLoadingTree = false;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (IsLoadingTree)
                return;
            if(e.Node.Tag != null)
                LoadObject((SectorObject)e.Node.Tag);
        }

        private void sectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadObject(m_GameHook.sectorObjectManager.GetSpace());
        }

        private void playerShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadObject(m_GameHook.sectorObjectManager.GetPlayerObject());
        }

        private void SectorObjectDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
