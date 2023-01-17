using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib.SimpleScript;

namespace SimpleScriptCompiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = SimpleScript.LoadSource(File.ReadAllText("./test.simple"));
        }
    }
}
