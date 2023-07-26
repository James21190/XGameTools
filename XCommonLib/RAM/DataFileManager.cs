using System.IO;
using XCommonLib.RAM.Bases.Sector;
using CommonToolLib.ProcessHooking;

namespace XCommonLib.RAM
{
    public class DataFileManager
    {
        public readonly string DataFilePath;

        public DataFileManager(string path)
        {
            DataFilePath = path;
        }

        #region SectorObject Types
        private const string _SectorObjectTypesDir = "SectorObject Types";
        public string GetSectorObjectTypeName(short mainType, short subType)
        {
            return GetSectorObjectTypeName(new SectorObject.SectorObjectType() { MainType = mainType, SubType = subType });
        }
        public string GetSectorObjectTypeName(SectorObject.SectorObjectType type)
        {
            var path = Path.Combine(DataFilePath, _SectorObjectTypesDir, type.MainType + ".txt");
            if (File.Exists(path))
            {
                var file = File.ReadAllLines(path);
                if (file.Length > type.SubType)
                {
                    var name = file[type.SubType];
                    if (!string.IsNullOrEmpty(name))
                    {
                        return name;
                    }
                }
            }
            return type.ToString();
        }
        #endregion

        #region ScriptInstance Types
        private string _ScriptInstanceTypesDir = "ScriptInstance Types";
        public XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceType GetScriptInstanceType(int typeID)
        {
            if (!Directory.Exists(Path.Combine(DataFilePath, _ScriptInstanceTypesDir)))
            {
                return null;
            }

            return _GetScriptInstanceType(typeID, Path.Combine(DataFilePath, _ScriptInstanceTypesDir));

        }
        private XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceType _GetScriptInstanceType(int typeID, string startPath)
        {
            foreach (var file in Directory.GetFiles(startPath))
            {
                var lines = File.ReadAllLines(file);
                var id = int.Parse(lines[0]);
                if (id == typeID)
                {
                    return _GetScriptInstanceTypeFromFile(file);
                }
            }
            foreach (var dir in Directory.GetDirectories(startPath))
            {
                var dirResult = _GetScriptInstanceType(typeID, dir);
                if (dirResult != null)
                {
                    return dirResult;
                }
            }
            return null;
        }

        public XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceType GetScriptInstanceType(string name)
        {
            if (!Directory.Exists(Path.Combine(DataFilePath, _ScriptInstanceTypesDir)))
            {
                return null;
            }

            return _GetScriptInstanceType(name, Path.Combine(DataFilePath, _ScriptInstanceTypesDir));
        }
        private XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceType _GetScriptInstanceType(string name, string startPath)
        {
            foreach (var file in Directory.GetFiles(startPath))
            {
                if (Path.GetFileNameWithoutExtension(file) == name)
                {
                    return _GetScriptInstanceTypeFromFile(file);
                }
            }
            foreach (var dir in Directory.GetDirectories(startPath))
            {
                var dirResult = _GetScriptInstanceType(name, dir);
                if (dirResult != null)
                {
                    return dirResult;
                }
            }
            return null;
        }

        private XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceType _GetScriptInstanceTypeFromFile(string path)
        {
            var result = new XCommonLib.RAM.Bases.Story.Scripting.ScriptInstanceType();
            var lines = File.ReadAllLines(path);
            if (lines.Length < 2)
                return null;
            result.Name = Path.GetFileNameWithoutExtension(path);
            result.TypeID = int.Parse(lines[0]);

            if (!string.IsNullOrWhiteSpace(lines[1]))
            {
                result.ParentType = GetScriptInstanceType(lines[1]);
            }

            result.LocalVariables = new Bases.Story.Scripting.ScriptInstanceType.VariableData[lines.Length - 2];
            for (int i = 2; i < lines.Length; i++)
            {
                var newVariable = new Bases.Story.Scripting.ScriptInstanceType.VariableData();
                // Split line into type and name
                var splitLine = lines[i].Split(' ');
                // If no type is provided
                if (splitLine.Length == 1)
                {
                    newVariable.Name = splitLine[0];
                }
                // If type and name is provided
                else if (splitLine.Length == 2)
                {
                    newVariable.Name = splitLine[1];
                    switch (splitLine[0].ToUpper())
                    {
                        case "SCRIPTINSTANCEID":
                            newVariable.Type = Bases.Story.Scripting.ScriptInstanceType.VariableType.ScriptInstanceID;
                            break;
                        case "SECTOROBJECTID":
                            newVariable.Type = Bases.Story.Scripting.ScriptInstanceType.VariableType.SectorObjectID;
                            break;
                        case "ARRAY":
                            newVariable.Type = Bases.Story.Scripting.ScriptInstanceType.VariableType.Array;
                            break;
                        case "NONE":
                            newVariable.Type = Bases.Story.Scripting.ScriptInstanceType.VariableType.None;
                            break;
                        case "TABLE":
                            newVariable.Type = Bases.Story.Scripting.ScriptInstanceType.VariableType.Table;
                            break;
                        default:
                            throw new InvalidDataException("Type is invalid in ScriptInstanceType file " + path + " at line " + i + ".");
                    }
                }
                // If name and type with additional information is provided
                else if(splitLine.Length == 3)
                {
                    newVariable.Name = splitLine[2];
                    switch(splitLine[0].ToUpper())
                    {
                        case "OBJECT":
                            newVariable.Type = Bases.Story.Scripting.ScriptInstanceType.VariableType.Object;
                            newVariable.Additional = splitLine[1];
                            break;
                        default:
                            throw new InvalidDataException("Type is invalid in ScriptInstanceType file " + path + " at line " + i + ".");
                    }
                }
                // If invalid
                else
                {
                    throw new InvalidDataException("Line is invalid in ScriptInstanceType file " + path + " at line " + i + ".");
                }
                result.LocalVariables[i-2] = newVariable;
            }
            return result;
        }
        #endregion

        #region Mods
        private const string _ModsDir = "Mods";

        public string[] GetModFiles()
        {
            var files = Directory.GetFiles(Path.Combine(DataFilePath, _ModsDir));
            for(int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            return files;
        }

        public ScriptAssembler.ScriptCode GetMod(string fileName)
        {
            return ScriptAssembler.ParseScript(Path.Combine(DataFilePath, _ModsDir, fileName));
        }
        #endregion
    }
}
