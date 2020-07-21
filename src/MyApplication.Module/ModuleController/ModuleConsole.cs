using System;
using System.ComponentModel;
using Moryx.Runtime.Modules;

namespace MyApplication.Module.ModuleController
{
    [ServerModuleConsole]
    public class ModuleConsole : IServerModuleConsole
    {
        public string ExportDescription(DescriptionExportFormat format)
        {
            return "Console of MyModule. Possible commands:" + Environment.NewLine +
                   "- hello {name}: Says hello";
        }

        public void ExecuteCommand(string[] args, Action<string> outputStream)
        {
            if (args.Length < 2)
            {
                outputStream("Insufficient arguments!");
                return;
            }

            if (args[0] == "hello")
                outputStream(SayHello(args[1]));
        }

        [EditorBrowsable]
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}