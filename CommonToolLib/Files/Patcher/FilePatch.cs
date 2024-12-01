using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files.Patcher
{
    /// <summary>
    /// Structure for a patch to be applied to a file. Supports multiple blocks of data that can be applied to different addresses.
    /// </summary>
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
            /// <summary>
            /// The offset in the section that the variable is.
            /// </summary>
            public int Offset;
            /// <summary>
            /// The size of the variable in bytes.
            /// </summary>
            public int Length;
        }
        /// <summary>
        /// A block of data that is applied to a specific address.
        /// </summary>
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

        /// <summary>
        /// The name of the patch.
        /// </summary>
        public string Name;
        /// <summary>
        /// A description of what the patch does.
        /// </summary>
        public string Description;

        /// <summary>
        /// The method used to store data.
        /// </summary>
        public PatchMethod Method;
        public Section[] Sections;

        /// <summary>
        /// Searches all sections for a variable with a given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>First instance of a variable with a given name.</returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Get the value of a variable.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public byte[] GetVariable(string name)
        {
            var section = _GetSectionWithVariable(name);
            var variable = section.GetVariable(name);

            var result = new byte[variable.Length];

            Array.Copy(section.Bytes, variable.Offset, result, 0, variable.Length);
            return result;

        }
        /// <summary>
        /// Set a variable to a given array of bytes.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value to set the variable to.</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetVariable(string name, byte[] value)
        {
            var section = _GetSectionWithVariable(name);
            var variable = section.GetVariable(name);

            if (value.Length != variable.Length)
                throw new ArgumentException();

            Array.Copy(value, 0, section.Bytes, variable.Offset, variable.Length);
        }

        /// <summary>
        /// Reads a file from disk and creates a patch.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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
