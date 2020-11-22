using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using X3TCTools;
using X3TCTools.Sector_Objects;

namespace TypeNameDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameHook m_GameHook;
            // Hook into the game memory
            Process processX3TC = Process.GetProcessesByName("X3TC").FirstOrDefault();
            Process processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();
            Process processX3R = Process.GetProcessesByName("X3").FirstOrDefault();


            if (processX3TC != null)
            {
                m_GameHook = new GameHook(processX3TC, GameHook.GameVersions.X3TC);
            }
            else if (processX3AP != null)
            {
                m_GameHook = new GameHook(processX3AP, GameHook.GameVersions.X3AP);
            }
            else if (processX3R != null)
            {
                m_GameHook = new GameHook(processX3R, GameHook.GameVersions.X3R);
            }
            else
            {
                return;
            }

            int SubTypeCount = 0;

            for (int mainType = 0; mainType < SectorObject.MAIN_TYPE_COUNT; mainType++)
            {
                if (GameHook.GetTypeDataCount(mainType) > SubTypeCount) SubTypeCount = GameHook.GetTypeDataCount(mainType);
            }


            string[] lines = new string[SubTypeCount];
            for (int subType = 0; subType < SubTypeCount; subType++)
            {
                string[] names = new string[SectorObject.MAIN_TYPE_COUNT];
                for (int mainType = 0; mainType < SectorObject.MAIN_TYPE_COUNT; mainType++)
                {
                    string name = "";
                    if (subType < GameHook.GetTypeDataCount(mainType))
                    {
                        try
                        {
                            switch ((SectorObject.Main_Type)mainType)
                            {
                                //case SectorObject.Main_Type.Dock:
                                //    var dockData = (TypeData_Dock)GameHook.GetTypeData(mainType, subType);
                                //    name = dockData.OriginRace + "_" + dockData.DefaultName;
                                //    break;
                                case SectorObject.Main_Type.Factory:
                                    var factoryData = (TypeData_Factory)GameHook.GetTypeData(mainType, subType);
                                    name = factoryData.OriginRace + "_" + factoryData.DefaultName;
                                    break;
                                case SectorObject.Main_Type.Ship:
                                    var shipData = (TypeData_Ship)GameHook.GetTypeData(mainType, subType);
                                    name = shipData.OriginRace + "_" + shipData.DefaultName;
                                    break;
                                case SectorObject.Main_Type.Background:
                                    var backgroundData = (TypeData_Background)GameHook.GetTypeData(mainType, subType);
                                    name = backgroundData.pName.obj.value;
                                    break;
                                default: name = GameHook.GetTypeData(mainType, subType).DefaultName; break;
                            }
                            name = name.Replace(' ', '_');
                            name = name.Replace('-', '_');
                            name = name.Trim('_');
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(string.Format("Unable to process {0} - {1}", mainType, subType));
                        }
                    }
                    names[mainType] = name;
                }
                lines[subType] = string.Join(",", names);
                Console.WriteLine(string.Format("Processed subtype {0}/{1} with result {2}", subType , SubTypeCount, lines[subType]));
            }

            File.Delete("./output.csv");
            File.WriteAllLines("./output.csv", lines);

            Console.Read();
        }
    }
}
