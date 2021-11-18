using System.IO;
using XCommonLib.RAM.Bases.Sector;

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
        private string _SectorObjectTypesDir = "SectorObject Types";
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
            return type.ToString(); ;
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
            result.TypeID = int.Parse(lines[0]);
            if (!string.IsNullOrWhiteSpace(lines[1]))
            {
                result.Parent = GetScriptInstanceType(lines[1]);
            }

            result.LocalVariableNames = new string[lines.Length - 2];
            for (int i = 2; i < lines.Length; i++)
            {
                result.LocalVariableNames[i - 2] = lines[i];
            }
            return result;
        }
        #endregion
    }
}
