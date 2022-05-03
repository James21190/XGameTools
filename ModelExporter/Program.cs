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
                new GameInstall("X2", @".\X2", GameVersion.X2, "v", "cut"),
                //new GameInstall("X3R",@"J:\Steam\steamapps\common\X3 - Reunion", GameVersion.X3R,"objects/v", "objects/cut"),
                //new GameInstall("X3TC",@"J:\Steam\steamapps\common\X3 Terran Conflict", GameVersion.X3TC,"objects/v", "objects/cut"),
                //new GameInstall("X3AP",@"J:\Steam\steamapps\common\x3 terran conflict\addon", GameVersion.X3AP,"objects/v", "objects/cut"),
                //new GameInstall("X3FL",@"J:\Steam\steamapps\common\x3 terran conflict\addon2", GameVersion.X3FL,"objects/v", "objects/cut"),
            };

#if !DEBUG
            List<Task> tasks = new List<Task>();
#endif
            foreach (var install in Installs)
            {
                if (!Directory.Exists(install.Path))
                {
                    Console.WriteLine("Unable to find path \"" + install.Path + "\" for " +install.Name);
                    continue;
                }
                var currentInstall = install;
#if !DEBUG
                var newTask = new Task(() =>
                {
#endif
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
#if !DEBUG
                    try
                    {
#endif
                            Console.WriteLine(string.Format("Extracting {0}-{1} Textures...", currentInstall.Name, collectionName));
                            var textureDest = Path.Combine(destDir, "Textures");
                            if (!Directory.Exists(textureDest))
                                Directory.CreateDirectory(textureDest);
                            // Extract textures
                            foreach(var file in catDatPair.GetInternalFiles("tex/true"))
                            {
                                var filedata = catDatPair.GetInternalFile(file, AbstractCatDatPair.ExtractionMode.None);
                                File.WriteAllBytes(Path.Combine(textureDest,Path.GetFileNameWithoutExtension(file) + ".jpg"), filedata);
                            }

                            // Extract models
                            Console.WriteLine(string.Format("Extracting {0}-{1} Models...", currentInstall.Name, collectionName));
                            var modelDest = Path.Combine(destDir, "Models");
                            if (!Directory.Exists(modelDest))
                                Directory.CreateDirectory(modelDest);

                            foreach(var file in catDatPair.GetInternalFiles(currentInstall.ModelPath))
                            {
                                if (Path.GetExtension(file).ToLower() != ".pbd")
                                    continue;
                                var bodFile = new BODFile();
                                var filedata = Encoding.Default.GetString(catDatPair.GetInternalFile(file, AbstractCatDatPair.ExtractionMode.DecryptAndExtract));
                                bodFile.FromText(filedata);
                                // Convert to .obj
                                bodFile.ExportAsOBJ(Path.Combine(modelDest, Path.GetFileNameWithoutExtension(file)+".obj"), "..\\Textures");
                            }

                            // Extract collections
                            Console.WriteLine(string.Format("Extracting {0}-{1} Collections...", currentInstall.Name, collectionName));
                            var collectionDest = Path.Combine(destDir, "Collections");
                            if (!Directory.Exists(collectionDest))
                                Directory.CreateDirectory(collectionDest);

                            foreach (var file in catDatPair.GetInternalFiles(currentInstall.CutPath))
                            {
#if !DEBUG
                                try
                                {
#endif
                                    if (Path.GetExtension(file).ToLower() != ".bob")
                                        continue;
                                    //if (file != "cut/04191.bob")
                                    //    continue;
                                    var bobFile = new BOBFile(catDatPair);
                                    bobFile.FromFile(file);
                                    var convertedBob = bobFile.ConvertToBOD();
                                    if (convertedBob != null)
                                        convertedBob.ExportAsOBJ(Path.Combine(collectionDest, Path.GetFileNameWithoutExtension(file) + ".obj"), "..\\Textures");
#if !DEBUG
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error while extracting " + file);
                                    Console.WriteLine(ex.ToString());
                                }
#endif
                            }
#if !DEBUG
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(string.Format("Failed Extracting {0}-{1}!", currentInstall.Name, collectionName));
                            Console.WriteLine(ex.ToString());
                        }
#endif
                    }

                    Console.WriteLine(string.Format("Completed extraction of {0}.", currentInstall.Name));
#if !DEBUG
                });
                newTask.Start();
                tasks.Add(newTask);
#endif
            }
#if !DEBUG
            Task.WaitAll(tasks.ToArray());
#endif
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
