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
    public partial class ScriptingObjectDisplay : Form
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
        private ScriptingObject m_EventObject;
        public ScriptingObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(int ID)
        {
            StoryBase storyBase = GameHook.storyBase;
            HashTable<ScriptingObject> EventObjectHashTable = storyBase.pEventObjectHashTable.obj;
            int value = ID < 0 ? -ID - 1 : ID;
            try
            {
                LoadObject(EventObjectHashTable.GetObject(value));
            }
            catch (Exception)
            {
                m_EventObject = null;
            }
        }
        public void LoadObject(ScriptingObject eventObject)
        {
            m_EventObject = eventObject;
            eventObjectPannel1.EventObject = eventObject;
            Reload();
        }

        private IScriptMemoryObject_Panel typePanel;



        public void Reload()
        {
            scriptMemoryObject_Raw_Panel1.LoadObject(m_EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject>());

            #region Reload Type Panel
            if (typePanel != null)
            {
                UserControl panel = (UserControl)typePanel;
                panel.Dispose();
            }

            switch (m_EventObject.ObjectType)
            {
                case ScriptingObject.EventObject_Type.Sector:
                    typePanel = new IScriptMemoryObject_Sector_Panel(); break;
                case ScriptingObject.EventObject_Type.Ship_M1:
                case ScriptingObject.EventObject_Type.Ship_M2:
                case ScriptingObject.EventObject_Type.Ship_M3:
                case ScriptingObject.EventObject_Type.Ship_M4:
                case ScriptingObject.EventObject_Type.Ship_M5:
                case ScriptingObject.EventObject_Type.Ship_M6:
                case ScriptingObject.EventObject_Type.Ship_M7:
                case ScriptingObject.EventObject_Type.Ship_TS:
                    typePanel = new IScriptMemoryObject_Ship_Panel(); break;
                case ScriptingObject.EventObject_Type.Station_Factory:
                    typePanel = new IScriptMemoryObject_Station_Panel(); break;
                case ScriptingObject.EventObject_Type.Headquarters:
                    typePanel = new IScriptMemoryObject_Headquarters_Panel(); break;
                case ScriptingObject.EventObject_Type.RaceData_0:
                case ScriptingObject.EventObject_Type.RaceData_1:
                case ScriptingObject.EventObject_Type.RaceData_2:
                case ScriptingObject.EventObject_Type.RaceData_3:
                case ScriptingObject.EventObject_Type.RaceData_4:
                case ScriptingObject.EventObject_Type.RaceData_5:
                    typePanel = new IScriptMemoryObject_RaceData_Panel(); break;
                case ScriptingObject.EventObject_Type.RaceData_Player:
                    typePanel = new IScriptMemoryObject_RaceData_Player_Panel(); break;
                default: return;
            }


            UserControl ucTypePanel = (UserControl)typePanel;
            typeBackPanel.Controls.Add(ucTypePanel);
            ucTypePanel.Location = new System.Drawing.Point(1, 1);
            ucTypePanel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            ucTypePanel.Size = new System.Drawing.Size(typeBackPanel.Width - 2, typeBackPanel.Height - 2);
            #endregion

            if (typePanel != null)
            {
                typePanel.LoadObject(m_EventObject);
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

        private void EventObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void eventObjectPannel1_EventObjectLoaded(object sender, EventArgs e)
        {
            m_EventObject = eventObjectPannel1.EventObject;
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
