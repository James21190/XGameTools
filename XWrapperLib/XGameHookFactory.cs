using System.Diagnostics;
using System.Linq;
using X2Lib.RAM;
using X3TCAPLib.RAM;
using XBTFLib.RAM;
using XCommonLib.RAM;

namespace XWrapperLib
{
    public static class XGameHookFactory
    {
        public static GameHook GetGameHook()
        {
            // Hook into the game memory
            Process processXBTF = Process.GetProcessesByName("X").FirstOrDefault();
            Process processX2 = Process.GetProcessesByName("X2").FirstOrDefault();
            Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            Process processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            Process processX3FL = Process.GetProcessesByName("X3FL").FirstOrDefault();

            if(processXBTF != null)
            {
                return new XBTFGameHook(processXBTF);
            }
            else if (processX2 != null)
            {
                return new X2GameHook(processX2);
            }
            else if (processX3TC != null)
            {
                return new X3TCGameHook(processX3TC);
            }
            else if (processX3AP != null)
            {
                return new X3APGameHook(processX3AP);
            }

            return null;
        }
    }
}
