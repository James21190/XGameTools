using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Lib.Files.CatDat;
using X3TCAPLib.Files.CatDat;
using XCommonLib.Files;
using XCommonLib.Files.CatDat;

namespace ModelExporter
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
            public string ModelPath;
            public string CutPath;

            public GameInstall(string name, string path, GameVersion version, string modelPath, string cutPath)
            {
                Name = name;
                Path = path;
                Version = version;
                ModelPath = modelPath;
                CutPath = cutPath;
            }
        }

        static void Main(string[] args)
        {
            GameInstall[] Installs = new GameInstall[]
            {
                new GameInstall("X2", @"J:\Steam\steamapps\common\X2 - The Threat", GameVersion.X2, "v", "cut"),
                //new GameInstall("X3R",@"J:\Steam\steamapps\common\X3 - Reunion", GameVersion.X3R,"objects/v"),
                //new GameInstall("X3TC",@"J:\Steam\steamapps\common\X3 Terran Conflict", GameVersion.X3TC,"objects/v"),
                //new GameInstall("X3AP",@"J:\Steam\steamapps\common\x3 terran conflict\addon", GameVersion.X3AP,"objects/v"),
                //new GameInstall("X3FL",@"J:\Steam\steamapps\common\x3 terran conflict\addon2", GameVersion.X3FL,"objects/v"),
            };
            //List<Task> tasks = new List<Task>();
            foreach (var install in Installs)
            {
                var currentInstall = install;
                //var newTask = new Task(() =>
                //{
                    var destDir = Path.Combine(".","Exports", currentInstall.Name);
                    if (!Directory.Exists(destDir))
                    {
                        Directory.CreateDirectory(destDir);
                    }
                    Console.WriteLine(string.Format("Finding files for \"{0}\" at \"{1}\" as version \"{2}\".", currentInstall.Name, currentInstall.Path, currentInstall.Version.ToString()));
                    // Get cat files
                    var collectionNames = new List<string>();
                    foreach (var file in Directory.GetFiles(currentInstall.Path))
                    {
                        if (Path.GetExtension(file) == ".cat")
                        {
                            collectionNames.Add(Path.GetFileNameWithoutExtension(file));
                        }
                    }

                    Console.WriteLine(string.Format("Found {0} files for \"{1}\".", collectionNames.Count, currentInstall.Name));

                    string targetDir = Path.Combine(@".\exports\", currentInstall.Name);

                    AbstractCatDatPair catDatPair;

                    foreach (var collectionName in collectionNames)
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

                        Console.WriteLine(string.Format("Extracting {0}-{1}...", currentInstall.Name, collectionName));
                        //try
                        //{
                            var texturePath = Path.Combine(destDir, "Textures");
                            if (!Directory.Exists(texturePath))
                            {
                                Directory.CreateDirectory(texturePath);
                            }
                            // Extract textures
                            foreach(var file in catDatPair.GetInternalFiles("tex/true"))
                            {
                                var filedata = catDatPair.GetInternalFile(file, AbstractCatDatPair.ExtractionMode.None);
                                File.WriteAllBytes(Path.Combine(texturePath,Path.GetFileNameWithoutExtension(file) + ".jpg"), filedata);
                            }
                            // Extract models
                            //foreach(var file in catDatPair.GetInternalFiles(currentInstall.ModelPath))
                            //{
                            //    if (Path.GetExtension(file).ToLower() != ".pbd")
                            //        continue;
                            //    var bodFile = new BODFile();
                            //    var filedata = Encoding.Default.GetString(catDatPair.GetInternalFile(file, AbstractCatDatPair.ExtractionMode.DecryptAndExtract));
                            //    bodFile.FromText(filedata);
                            //    // Convert to .obj
                            //    bodFile.ExportAsOBJ(Path.Combine(destDir, Path.GetFileNameWithoutExtension(file)+".obj"), "Textures");
                            //}

                            foreach(var file in catDatPair.GetInternalFiles(currentInstall.CutPath))
                            {
                                if (Path.GetExtension(file).ToLower() != ".bob")
                                    continue;
                                var bobFile = new BOBFile();
                                bobFile.FromBytes(catDatPair.GetInternalFile(file, AbstractCatDatPair.ExtractionMode.None));
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine("Failed extraction.");
                        //    Console.WriteLine(ex.ToString());
                        //}
                    }
                //});
                //newTask.Start();
                //tasks.Add(newTask);
            }
            //Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
