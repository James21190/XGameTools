using System;
using System.Windows.Forms;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels;
using X3TCTools;
using X3TCTools.Bases;

using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Generics;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    public partial class EventObjectDisplay : Form
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
        }
        private EventObject m_EventObject;
        public EventObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(int ID)
        {
            StoryBase storyBase = GameHook.storyBase;
            HashTable<EventObject> EventObjectHashTable = storyBase.pEventObjectHashTable.obj;
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
        public void LoadObject(EventObject eventObject)
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
                case EventObject.EventObject_Type.Sector: typePanel = new IScriptMemoryObject_Sector_Panel(); break;
                case EventObject.EventObject_Type.Ship_Unknown_1:
                case EventObject.EventObject_Type.Ship_Unknown_2:
                case EventObject.EventObject_Type.Ship_Unknown_3:
                case EventObject.EventObject_Type.Ship_Unknown_4:
                case EventObject.EventObject_Type.Ship_Unknown_5:
                case EventObject.EventObject_Type.Ship_Unknown_6:
                case EventObject.EventObject_Type.Ship_Player: typePanel = new IScriptMemoryObject_Ship_Panel(); break;
                case EventObject.EventObject_Type.Station_Equipment:
                case EventObject.EventObject_Type.Station_Factory:
                case EventObject.EventObject_Type.Station_Shipyard:
                case EventObject.EventObject_Type.Station_Trading:
                case EventObject.EventObject_Type.Station_Unknown_3: typePanel = new IScriptMemoryObject_Station_Panel(); break;
                case EventObject.EventObject_Type.RaceData: typePanel = new IScriptMemoryObject_RaceData_Panel(); break;
                case EventObject.EventObject_Type.RaceData_Player: typePanel = new IScriptMemoryObject_RaceData_Player_Panel(); break;
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
    }
}
