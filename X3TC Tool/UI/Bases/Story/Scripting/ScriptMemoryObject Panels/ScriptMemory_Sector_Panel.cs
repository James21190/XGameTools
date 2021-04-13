using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Bases.Sector;
using System;
using System.Collections.Generic;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class ScriptMemory_Sector_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private struct ListItem
        {
            public object obj;
            public string txt;

            public override string ToString()
            {
                return txt;
            }
        }
        private struct ShipData : IComparable
        {
            public ScriptInstance Ship;

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                if (!(obj is ShipData))
                {
                    throw new Exception("Type missmatch");
                }

                ShipData type = (ShipData)obj;



                var thisSubType = Ship.GetVariableByName("SubType").Value;
                var thatSubType = type.Ship.GetVariableByName("SubType").Value;



                if (thisSubType > thatSubType)
                {
                    return -1;
                }

                if (thisSubType < thatSubType)
                {
                    return 1;
                }

                return 0;
            }
        }

        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set { m_MessengerFunction = value; } }
        public ScriptMemory_Sector_Panel()
        {
            InitializeComponent();
            for (int i = 0; i < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Background); i++)
            {
                comboBox1.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Background, i));
            }
        }

        ScriptInstance m_ScriptInstance;

        public void LoadObject(ScriptInstance ScriptInstance, bool reload = true)
        {
            if (!ScriptInstance.ScriptInstanceType.InheritsFrom("Sector"))
                throw new NotSupportedException("Object doesn't inherit from Sector");
            m_ScriptInstance = ScriptInstance;
            if (reload) Reload();
        }

        public struct stringObj
        {
            public string text;
            public object obj;

            public override string ToString()
            {
                return text;
            }
        }
        public void Reload()
        {
            vector2Display1.X = m_ScriptInstance.GetVariableByName("Sector_X").Value;
            vector2Display1.Y = m_ScriptInstance.GetVariableByName("Sector_Y").Value;

            #region Ships
            lstShips.Items.Clear();

            List<ShipData> ships = new List<ShipData>();
            foreach (DynamicValue shipID in m_ScriptInstance.GetVariableByName("ShipScriptInstanceIDHashTable").GetAsHashTableObject().hashTable.ScanContents())
            {
                ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(shipID.Value);
                if (ScriptingObject.ScriptInstanceType == null)
                {
                    m_MessengerFunction(string.Format("ScriptInstance type undefined, expected ship : {0}", ScriptingObject.pSub.obj.Class));
                }
                else if (!ScriptingObject.ScriptInstanceType.InheritsFrom("Ship"))
                {
                    m_MessengerFunction(string.Format("ScriptInstance type \"{0}\" invalid, expected ship : {1}", ScriptingObject.ScriptInstanceType.Name, ScriptingObject.pSub.obj.Class));
                }
                else
                {
                    ships.Add(new ShipData()
                    {
                        Ship = ScriptingObject
                    });
                }
            }
            try
            {
                ships.Sort();
                ships.Reverse();
            }
            catch (Exception)
            {

            }

            foreach (ShipData ship in ships)
            {
                lstShips.Items.Add(new ListItem()
                {
                    obj = ship.Ship,
                    txt = SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, ship.Ship.GetVariableByName("SubType").Value)
                }); ;
            }

            #endregion
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
        }
    }
}
