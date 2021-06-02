using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Sector;
using X3Tools.RAM.Bases.Story.Scripting;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class ScriptMemory_Ship_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set => m_MessengerFunction = value; }
        public ScriptMemory_Ship_Panel()
        {
            InitializeComponent();

            for (int i = 0; i < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, i));
            }
        }

        private ScriptInstance m_ScriptInstance;

        public void LoadObject(ScriptInstance ScriptInstance, bool reload = true)
        {
            if (!ScriptInstance.ScriptInstanceType.InheritsFrom("Ship"))
            {
                throw new NotSupportedException("Object doesn't inherit from Ship");
            }

            m_ScriptInstance = ScriptInstance;
            if (reload)
            {
                Reload();
            }
        }

        public void Reload()
        {
            cmbSubType.SelectedIndex = m_ScriptInstance.GetVariableByName("SubType").Value;

            ScriptTableObject_Inner cargotable = m_ScriptInstance.GetVariableByName("Cargo").GetAsHashTableObject().hashTable;
            List<CargoEntry> lst = new List<CargoEntry>();
            foreach (DynamicValue cargoitem in cargotable.ScanContents())
            {
                lst.Add(new CargoEntry()
                {
                    Type = new SectorObject.SectorObjectType(cargoitem.Value >> 16, cargoitem.Value & 0xffff),
                    Count = cargotable.GetObject(cargoitem).Value
                });
            }
            lst.Sort();
            lst.Reverse();
            cargo_Panel1.Cargo = lst.ToArray();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(m_ScriptInstance.GetVariableByName("CurrentSectorScriptingObjectID").Value);
            display.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(m_ScriptInstance.GetVariableByName("PreviousSectorScriptingObjectID").Value);
            display.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(m_ScriptInstance.GetVariableByName("OwningRaceDataScriptingObjectID").Value);
            display.Show();
        }

        private void IScriptMemoryObject_Ship_Panel_Load(object sender, System.EventArgs e)
        {

        }
    }
}
