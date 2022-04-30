using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Lib.Files.CatDat;
using X3TCAPLib.Files.CatDat;
using XCommonLib.Files.CatDat;

namespace CatDatExporter
{
    internal class Program
    {
        enum GameVersion
        {
            X2,
            X3R,
            X3TC,
            X3AP,
            X3FL
        }
        struct GameInstall
        {
            public string Name;
            public string Path;
            public GameVersion Version;
            
            public GameInstall(string name, string path, GameVersion version)
            {
                Name = name;
                Path = path;
                Version = version;
            }
        }

        static void Main(string[] args)
        {
            GameInstall[] Installs = new GameInstall[]
            {
                new GameInstall("X2", @"J:\Steam\steamapps\common\X2 - The Threat", GameVersion.X2),
                new GameInstall("X3R",@"J:\Steam\steamapps\common\X3 - Reunion", GameVersion.X3R),
                new GameInstall("X3TC",@"J:\Steam\steamapps\common\X3 Terran Conflict", GameVersion.X3TC),
                new GameInstall("X3AP",@"J:\Steam\steamapps\common\x3 terran conflict\addon", GameVersion.X3AP),
                new GameInstall("X3FL",@"J:\Steam\steamapps\common\x3 terran conflict\addon2", GameVersion.X3FL),
            };
            List<Task> tasks = new List<Task>();
            foreach(var install in Installs)
            {
                var currentInstall = install;
                var newTask = new Task(() =>
                {
                    Console.WriteLine(string.Format("Finding files for \"{0}\" at \"{1}\" as version \"{2}\".", currentInstall.Name, currentInstall.Path, currentInstall.Version.ToString()));
                    // Get cat files
                    var collectionNames = new List<string>();
                    foreach(var file in Directory.GetFiles(currentInstall.Path))
                    {
                        if(Path.GetExtension(file) == ".cat")
                        {
                            collectionNames.Add(Path.GetFileNameWithoutExtension(file));
                        }
                    }

                    Console.WriteLine(string.Format("Found {0} files for \"{1}\".", collectionNames.Count,currentInstall.Name));

                    string targetDir = Path.Combine(@".\exports\", currentInstall.Name);

                    AbstractCatDatPair catDatPair;

                    foreach(var collectionName in collectionNames)
                    {
                        switch (currentInstall.Version)
                        {
                            case GameVersion.X2:
                                catDatPair = new CatDatPair<X2CatFile, X2DatFile, X2CompressedFile>(Path.Combine(currentInstall.Path, collectionName));
                                break;
                            case GameVersion.X3R:
                            case GameVersion.X3TC:
                            case GameVersion.X3AP:
                            case GameVersion.X3FL:
                                catDatPair = new CatDatPair<X3CatFile, X3DatFile, X3CompressedFile>(Path.Combine(currentInstall.Path, collectionName));
                                break;
                            default:
                                throw new NotImplementedException();
                        }

                        Console.WriteLine(string.Format("Extracting {0}-{1}...", currentInstall.Name,collectionName));
                        try
                        {
                            catDatPair.ExtractAll(targetDir, AbstractCatDatPair.ExtractionMode.Decrypt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed extraction.");
                            Console.WriteLine(ex.ToString());
                        }
                    }
                });
                newTask.Start();
                tasks.Add(newTask);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
