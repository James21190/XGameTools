using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCMultiplayerComponents.OOS;
using X3TCTools;

namespace MultiplayerTester
{
    public static class Timer
    {
        public static DateTime time;
        public static void Start()
        {
            time = DateTime.Now;
        }
        public static int Stop()
        {
            var endTime = DateTime.Now;
            var difference = endTime - time;
            return difference.Seconds;
        }
    }
    class Program
    {
        private static GameHook m_GameHook;
        static void Main(string[] args)
        {
            // Hook into the game memory
            Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            Process processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();


            if (processX3TC != null)
            {
                m_GameHook = new GameHook(processX3TC, GameHook.GameVersions.X3TC);
            }
            else if (processX3AP != null)
            {
                m_GameHook = new GameHook(processX3AP, GameHook.GameVersions.X3AP);
            }
            else
            {
                throw new Exception();
            }

            var oosManager = new OOSManager();

            Timer.Start();
            var races = oosManager.GetRaces();
            Console.WriteLine(string.Format("Got all races in {0} seconds", Timer.Stop()));
            Console.ReadKey();
        }
    }
}
