using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.IO;

using X3TCTools;
using X3TCTools.SectorObjects;

using Common.Memory;

namespace X3TC_TypeFinder
{
    class Program
    {

        private static GameHook m_GameHook;
        private static Thread m_Worker;

        private static bool m_Stop = false;

        private static List<int> m_Processed = new List<int>();

        private static StreamWriter sw = new StreamWriter("./result.csv");


        static void Main(string[] args)
        {
            m_GameHook = new GameHook(Process.GetProcessesByName("X3TC")[0]);
            m_Worker = new Thread(WorkMethod);

            m_Worker.Start();
            Console.ReadKey();

            m_Stop = true;

            sw.Flush();
            sw.Close();

        }

        public static void AddLine(string Line)
        {
            Console.WriteLine(Line);
            sw.WriteLine(Line);
        }

        public static void WorkMethod()
        {
            
            while (!m_Stop)
            {
                m_GameHook.ReloadAll();
                var space = m_GameHook.SectorObjectManager.GetSpace();
                var sectorObjects = space.GetAllChildren(true);

                foreach(var sectorObject in sectorObjects)
                {
                    if (m_Stop)
                        return;
                    var type = SectorObject.ToFullType(sectorObject.MainType, sectorObject.SubType);
                    if (!m_Processed.Contains(type))
                    {
                        AddLine(string.Format("{0},{1},{2}", sectorObject.GetSubTypeAsString(), MemoryControl.ReadNullTerminatedString(m_GameHook.hProcess, sectorObject.pDefaultName).Split(',')[0], string.Join(",",sectorObject.GetValuesAsStrings())));
                        m_Processed.Add(type);

                    }
                }
                Thread.Sleep(3000);
            }
        }

    }
}
