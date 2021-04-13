using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory
{
    public static class ScriptInstanceTypeLibrary
    {
        public class ScriptInstanceType
        {

            public int ID;
            public string Name;
            // Base type this type inherits from.
            public ScriptInstanceType BaseType
            {
                get
                {
                    return GetScriptInstanceType(m_BaseTypeName);
                }
            }
            private string m_BaseTypeName;

            public string[] InheritanceStack
            {
                get
                {
                    if (BaseType != null)
                    {
                        var baseStack = BaseType.InheritanceStack;
                        var array = new string[baseStack.Length + 1];
                        Array.Copy(baseStack,0, array,1, baseStack.Length);
                        array[0] = Name;
                        return array;
                    }
                    return new string[] { Name };
                }
            }

            public bool InheritsFrom(string name)
            {
                return InheritanceStack.Contains(name);
            }

            public int GetIndexOfVariable(string variable)
            {
                var variables = Variables;
                for (int i = 0; i < variables.Length; i++)
                    if (variables[i] == variable)
                        return i;
                throw new IndexOutOfRangeException();
            }

            public string[] Variables
            {
                get
                {
                    if (BaseType != null)
                    {
                        var baseVariables = BaseType.Variables;
                        var array = new string[baseVariables.Length + m_Variables.Length];
                        Array.Copy(baseVariables,0, array,0, baseVariables.Length);
                        Array.Copy(m_Variables, 0, array, baseVariables.Length, m_Variables.Length);
                        return array;
                    }
                    return m_Variables;
                }
            }

            private string[] m_Variables;

            public ScriptInstanceType()
            {

            }
            public ScriptInstanceType(string path)
            {
                Name = Path.GetFileNameWithoutExtension(path);
                var file = File.OpenText(path);
                ID = int.Parse(file.ReadLine());
                m_BaseTypeName = file.ReadLine();
                if (string.IsNullOrWhiteSpace(m_BaseTypeName)) m_BaseTypeName = null;

                if (!file.EndOfStream)
                {
                    m_Variables = file.ReadToEnd().Split('\n');
                    for (int i = 0; i < m_Variables.Length; i++)
                        m_Variables[i] = m_Variables[i].Trim('\r');
                }
                else
                    m_Variables = new string[0];
            }

            public string GetVariableName(int index)
            {
                if (index < Variables.Length)
                {
                    var name = Variables[index];
                    return string.IsNullOrWhiteSpace(name) ? index.ToString() : name;
                }
                return index.ToString();
            }

            public override string ToString()
            {
                if (m_BaseTypeName != null)
                {
                    if(BaseType != null)
                        return string.Format("{0} - {1} : {2}", ID, Name, m_BaseTypeName);
                    return string.Format("{0} - {1} : {2} Not Found!", ID, Name, m_BaseTypeName);
                }
                return string.Format("{0} - {1}", ID, Name);
            }
        }

        public const string TCTypeLibDir = ".\\RAM\\Data\\TC\\ScriptInstanceTypes";

        private static ScriptInstanceType[] LoadFromDir(string dir)
        {
            List<ScriptInstanceType> lst = new List<ScriptInstanceType>();
            foreach (var item in Directory.GetFiles(dir))
            {
                lst.Add(new ScriptInstanceType(item));
            }
            foreach(var item in Directory.GetDirectories(dir))
            {
                lst.AddRange(LoadFromDir(item));
            }
            return lst.ToArray();
        }

        public static void Load()
        {
            string path;
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    path = TCTypeLibDir;
                    break;
                default:
                    throw new GameVersionNotImplementedException();
            }
            m_Types = LoadFromDir(path);
        }

        private static ScriptInstanceType[] m_Types;
        public static ScriptInstanceType GetScriptInstanceType(int id)
        {
            foreach (var type in m_Types)
                if (type.ID == id)
                    return type;
            return null;
        }

        public static ScriptInstanceType GetScriptInstanceType(string name)
        {
            foreach (var type in m_Types)
                if (type.Name == name)
                    return type;
            return null;
        }

        public static string[] GetAllNames()
        {
            if (m_Types == null || m_Types.Length == 0)
                return new string[0];
            string[] names = new string[m_Types.Length];
            for (int i = 0; i < m_Types.Length; i++)
                names[i] = m_Types[i].Name;
            return names;
        }
    }
}
