using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools;
using X3TCTools.SectorObjects;
using System.IO;
using Common.Memory;

namespace X3TCTypeCollector
{
    class Program
    {


        static void Main(string[] args)
        {
            try {

                List<int> types = new List<int>();
                const string outputFile = "./results.csv";

                // If file already exists, add types and update
                if (File.Exists(outputFile))
                {
                    var lines = File.ReadAllLines(outputFile);
                    var updatedLines = new string[lines.Length];
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var seperated = lines[i].Split(',');
                        int maintype, subtype;

                        if (int.TryParse(seperated[0], out maintype) && int.TryParse(seperated[1], out subtype))
                        {
                            // If valid type, add to list so it is not reprocessed
                            types.Add((int)(maintype << 16 | subtype));

                            // If enumeration of subtype has changed, update it
                            seperated[3] = SectorObject.GetSubTypeAsString((SectorObject.Main_Type)maintype, subtype);
                        }

                        updatedLines[i] = string.Join(",", seperated);

                        if (updatedLines[i] != lines[i])
                            Console.WriteLine("(In File Updated) " + updatedLines[i]);
                        else
                            Console.WriteLine("(In File) " + updatedLines[i]);
                    }
                    // Update file to ensure enumerations are up to date
                    File.WriteAllLines(outputFile, updatedLines);
                }

                // Get the game process
                var processes = Process.GetProcessesByName("X3TC");
                
                if(processes.Length == 0)
                {
                    Console.WriteLine("X3TC process not found!");
                    Console.ReadKey();
                    return;
                }
                
                if (processes[0] == null)
                {
                    // If not found, exit
                    Console.WriteLine("X3TC not found!");
                    Console.ReadKey();
                    return;
                }
                // Create the hook
                var hook = new GameHook(processes[0], GameHook.GameVersion.X3TC);

                var sw = new StreamWriter(outputFile, true);

                // Loop until a key is pressed
                do
                {
                    var space = hook.sectorObjectManager.GetSpace();

                    // If space is not null, get all children objects and process
                    if (space != null)
                    {
                        // Fetch all objects
                        var objects = space.GetAllChildren(true);

                        foreach (var sectorObject in objects)
                        {
                            // Check if object is valid
                            if (sectorObject.IsValid)
                            {
                                // Convert MainType and SubType into a single int
                                int type = (int)(((ushort)sectorObject.MainType << 16) | (ushort)sectorObject.SubType);

                                // If not already processed, process
                                if (!types.Contains(type))
                                {
                                    string outputStr = string.Format("{0},{1},{5},{2},{3},{4}\n", (int)sectorObject.MainType, sectorObject.SubType, sectorObject.GetSubTypeAsString(), sectorObject.RaceID, MemoryControl.ReadNullTerminatedString(hook.hProcess, sectorObject.pDefaultName), sectorObject.MainType);

                                    // Write result to file
                                    sw.Write(outputStr);

                                    // Write result to console
                                    Console.Write(outputStr);
                                    // Add to list to prevent processing the same type twice
                                    types.Add(type);
                                }
                            }
                        }
                    }
                    // Flush to ensure file is up to date
                    sw.Flush();
                } while (!Console.KeyAvailable);

                sw.Close();

            }
            catch(Exception e)
            {
                Console.Write(e.Message + "\n" + e.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
