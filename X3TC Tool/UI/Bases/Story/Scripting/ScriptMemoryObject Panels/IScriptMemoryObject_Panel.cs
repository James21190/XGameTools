
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public interface IScriptMemoryObject_Panel : IReloadableDisplay
    {
        void LoadObject(ScriptInstance ScriptingObject);
    }
}
