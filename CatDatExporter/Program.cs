using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Lib.Files.CatDat;
using XCommonLib.Files.CatDat;

namespace CatDatExporter
{
    internal class Program
    {
        enum GameVersion
        {
            X2,
            X3TCAP
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
                new GameInstall("X2", @"J:\Steam\steamapps\common\X2 - The Threat", GameVersion.X2)
            };
            foreach(var install in Installs)
            {
                Console.WriteLine(string.Format("Finding files for {0} at \"{1}\" as version \"{2}\".",install.Name, install.Path,install.Version.ToString()));
                // Get cat files
                var collectionNames = new List<string>();
                foreach(var file in Directory.GetFiles(install.Path))
                {
                    if(Path.GetExtension(file) == ".cat")
                    {
                        collectionNames.Add(Path.GetFileNameWithoutExtension(file));
                    }
                }

                Console.WriteLine(string.Format("Found {0} files.", collectionNames.Count));

                string targetDir = Path.Combine(@".\exports\", install.Name);

                Console.WriteLine(string.Format("Extracting to \"{0}\"", targetDir));

                AbstractCatDatPair catDatPair;

                foreach(var collectionName in collectionNames)
                {
                    switch (install.Version)
                    {
                        case GameVersion.X2:
                            catDatPair = new CatDatPair<X2CatFile, X2DatFile, X2PckFile>(Path.Combine(install.Path, collectionName));
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    Console.WriteLine(string.Format("Extracting {0}.", collectionName));
                    catDatPair.ExtractAll(targetDir, AbstractCatDatPair.ExtractionMode.DecryptAndExtract);
                }
                Console.WriteLine("Done.");
                Console.ReadKey();
            }
        }
    }
}
