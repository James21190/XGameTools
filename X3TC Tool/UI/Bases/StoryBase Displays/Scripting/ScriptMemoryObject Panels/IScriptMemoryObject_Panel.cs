
using X3TCTools.Bases.StoryBase_Objects.Scripting;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public interface IScriptMemoryObject_Panel : IReloadableDisplay
    {
        void LoadObject(EventObject eventObject);
    }
}
