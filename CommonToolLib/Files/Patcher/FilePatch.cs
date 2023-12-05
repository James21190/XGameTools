using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files.Patcher
{
    public struct FilePatch
    {
        public enum PatchMethod
        {
            COPY,
            XOR
        }

        public struct SectionVariable
        {
            public string Name;
            public int Offset;
            public int Length;
        }
        public struct Section
        {
            public int Address;
            public byte[] Bytes;
            public SectionVariable[] Variables;
            public SectionVariable GetVariable(string name)
            {
                foreach (var variable in Variables)
                    if (variable.Name == name)
                        return variable;
                throw new Exception();
            }
        }

        public string Name;
        public string Description;

        public PatchMethod Method;
        public Section[] Sections;

        private Section _GetSectionWithVariable(string name)
        {
            foreach (var section in Sections)
            {
                foreach (var variable in section.Variables)
                {
                    if (variable.Name == name)
                    {
                        return section;
                    }
                }
            }
            throw new Exception($"Variable of name \"{name}\" not found.");
        }

        private SectionVariable _GetSectionVariable(string name)
        {
            foreach (var section in Sections)
            {
                foreach (var variable in section.Variables)
                {
                    if (variable.Name == name)
                    {
                        return variable;
                    }
                }
            }
            throw new Exception($"Variable of name \"{name}\" not found.");
        }

        public byte[] GetVariable(string name)
        {
            var section = _GetSectionWithVariable(name);
            var variable = section.GetVariable(name);

            var result = new byte[variable.Length];

            Array.Copy(section.Bytes, variable.Offset, result, 0, variable.Length);
            return result;

        }
        public void SetVariable(string name, byte[] value)
        {
            var section = _GetSectionWithVariable(name);
            var variable = section.GetVariable(name);

            if (value.Length != variable.Length)
                throw new ArgumentException();

            Array.Copy(value, 0, section.Bytes, variable.Offset, variable.Length);
        }
        public static FilePatch LoadFromFile(string filePath)
        {
            FilePatch patch = new FilePatch();
            List<FilePatch.Section> sections = new List<FilePatch.Section>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Header
                patch.Name = reader.ReadLine();
                patch.Description = reader.ReadLine();
                patch.Method = (FilePatch.PatchMethod)Enum.Parse(typeof(FilePatch.PatchMethod), reader.ReadLine());

                // Section
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int address = Convert.ToInt32(line, 16);

                    string[] byteStrings = reader.ReadLine().Split(',');
                    byte[] bytes = new byte[byteStrings.Length];
                    for (int i = 0; i < byteStrings.Length; i++)
                    {
                        bytes[i] = Convert.ToByte(byteStrings[i], 16);
                    }

                    // Variables
                    line = reader.ReadLine();
                    List<FilePatch.SectionVariable> variables = new List<FilePatch.SectionVariable>();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] variableStrings = line.Split(',');
                        for (int i = 0; i < variableStrings.Length; i += 3)
                        {
                            FilePatch.SectionVariable variable = new FilePatch.SectionVariable();
                            variable.Name = variableStrings[i];
                            variable.Offset = Convert.ToInt32(variableStrings[i + 1]);
                            variable.Length = Convert.ToInt32(variableStrings[i + 2]);
                            variables.Add(variable);
                        }
                    }
                    else
                    {
                        variables = new List<FilePatch.SectionVariable>();
                    }

                    sections.Add(new FilePatch.Section()
                    {
                        Address = address,
                        Bytes = bytes,
                        Variables = variables.ToArray()
                    });
                }
            }

            patch.Sections = sections.ToArray();

            return patch;
        }
    }
}
