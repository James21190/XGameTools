
using X3Tools.Bases.StoryBase_Objects.Scripting;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public interface IScriptMemoryObject_Panel : IReloadableDisplay
    {
        void LoadObject(ScriptingObject ScriptingObject);
    }
}
