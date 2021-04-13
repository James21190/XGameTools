
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public delegate void MessengerFunction(string message);
    public interface IScriptMemoryObject_Panel : IReloadableDisplay
    {
        MessengerFunction MessengerFunction
        {
            get;
            set;
        }
        void LoadObject(ScriptInstance ScriptingObject, bool reload = true);
    }
}
