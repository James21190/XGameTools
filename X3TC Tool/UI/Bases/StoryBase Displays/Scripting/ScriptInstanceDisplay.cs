using System;
using System.Windows.Forms;
using X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels;
using X3Tools;
using X3Tools.Bases;

using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.StoryBase_Objects;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Generics;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    public partial class ScriptInstanceDisplay : Form
    {
        public enum LoadAsItems
        {
            Blank,
            Ship,
            Sector,
            Station,
            Gate,
            Ware,
            RaceData,
            RaceData_Player,
            Headquarters,
        }
        private ScriptInstance m_ScriptingObject;
        public ScriptInstanceDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(int ID)
        {
            StoryBase storyBase = GameHook.storyBase;
            HashTable<ScriptInstance> ScriptingObjectHashTable = storyBase.pHashTable_ScriptInstance.obj;
            int value = ID < 0 ? -ID - 1 : ID;
            try
            {
                LoadObject(ScriptingObjectHashTable.GetObject(value));
            }
            catch (Exception)
            {
                m_ScriptingObject = null;
            }
        }
        public void LoadObject(ScriptInstance ScriptingObject)
        {
            m_ScriptingObject = ScriptingObject;
            ScriptingObjectPannel1.ScriptingObject = ScriptingObject;
            Reload();
        }

        private IScriptMemoryObject_Panel typePanel;



        public void Reload()
        {
            scriptMemoryObject_Raw_Panel1.LoadObject(m_ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject>());

            #region Reload Type Panel
            if (typePanel != null)
            {
                UserControl panel = (UserControl)typePanel;
                panel.Dispose();
            }

            switch (m_ScriptingObject.ObjectType)
            {
                case ScriptInstance.ScriptingObject_Type.Sector:
                    typePanel = new IScriptMemoryObject_Sector_Panel(); break;
                case ScriptInstance.ScriptingObject_Type.Ship_M1:
                case ScriptInstance.ScriptingObject_Type.Ship_M2:
                case ScriptInstance.ScriptingObject_Type.Ship_M3:
                case ScriptInstance.ScriptingObject_Type.Ship_M4:
                case ScriptInstance.ScriptingObject_Type.Ship_M5:
                case ScriptInstance.ScriptingObject_Type.Ship_M6:
                case ScriptInstance.ScriptingObject_Type.Ship_M7:
                case ScriptInstance.ScriptingObject_Type.Ship_TS:
                    typePanel = new IScriptMemoryObject_Ship_Panel(); break;
                case ScriptInstance.ScriptingObject_Type.Station_Factory:
                    typePanel = new IScriptMemoryObject_Station_Panel(); break;
                case ScriptInstance.ScriptingObject_Type.Headquarters:
                    typePanel = new IScriptMemoryObject_Headquarters_Panel(); break;
                case ScriptInstance.ScriptingObject_Type.RaceData_0:
                case ScriptInstance.ScriptingObject_Type.RaceData_1:
                case ScriptInstance.ScriptingObject_Type.RaceData_Pirate:
                case ScriptInstance.ScriptingObject_Type.RaceData_Gonor:
                case ScriptInstance.ScriptingObject_Type.RaceData_Khaak:
                case ScriptInstance.ScriptingObject_Type.RaceData_5:
                    typePanel = new IScriptMemoryObject_RaceData_Panel(); break;
                case ScriptInstance.ScriptingObject_Type.RaceData_Player:
                    typePanel = new IScriptMemoryObject_RaceData_Player_Panel(); break;
                default: return;
            }


            UserControl ucTypePanel = (UserControl)typePanel;
            typeBackPanel.Controls.Add(ucTypePanel);
            ucTypePanel.Location = new System.Drawing.Point(1, 1);
            ucTypePanel.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            //ucTypePanel.Size = new System.Drawing.Size(typeBackPanel.Width - 2, typeBackPanel.Height - 2);
            #endregion

            if (typePanel != null)
            {
                typePanel.LoadObject(m_ScriptingObject);
            }
        }


        public static ScriptMemoryObject GetScriptMemoryObjectType(LoadAsItems type)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    switch (type)
                    {
                        case LoadAsItems.Sector: return new ScriptMemoryObject_TC_Sector();
                        case LoadAsItems.Ship: return new ScriptMemoryObject_TC_Ship();
                        case LoadAsItems.Gate: return new ScriptMemoryObject_TC_Gate();
                        case LoadAsItems.Station: return new ScriptMemoryObject_TC_Station();
                        case LoadAsItems.RaceData: return new ScriptMemoryObject_TC_RaceData();
                        case LoadAsItems.RaceData_Player: return new ScriptMemoryObject_TC_RaceData_Player();
                        case LoadAsItems.Headquarters: return new ScriptMemoryObject_TC_Headquarters();
                    }
                    break;
                case GameHook.GameVersions.X3AP:
                    switch (type)
                    {
                        case LoadAsItems.Sector: return new ScriptMemoryObject_AP_Sector();
                        case LoadAsItems.Ship: return new ScriptMemoryObject_AP_Ship();
                        case LoadAsItems.Gate: return new ScriptMemoryObject_AP_Gate();
                        case LoadAsItems.Station: return new ScriptMemoryObject_AP_Station();
                        case LoadAsItems.RaceData: return new ScriptMemoryObject_AP_RaceData();
                        case LoadAsItems.RaceData_Player: return new ScriptMemoryObject_AP_RaceData_Player();
                    }
                    break;
            }
            return new ScriptMemoryObject();
        }

        private void ScriptingObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void ScriptingObjectPannel1_ScriptingObjectLoaded(object sender, EventArgs e)
        {
            m_ScriptingObject = ScriptingObjectPannel1.ScriptingObject;
            Reload();
        }

        private void scriptMemoryObject_Raw_Panel1_Load(object sender, EventArgs e)
        {

        }

        private void tmrAutoReload_Tick(object sender, EventArgs e)
        {
            scriptMemoryObject_Raw_Panel1.Reload();
        }
    }
}
