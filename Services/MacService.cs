using System;
using System.Diagnostics;
using System.IO;

namespace CoreApp.Services
{
    public class MacService : ICommandLineService
    {
        private readonly string _rootDirectory;

        public MacService() => _rootDirectory = Directory.GetCurrentDirectory();

        public string Connect(string fileName)
        {
            Bash($"chmod 700 {_rootDirectory}//{fileName}");
            var output = Bash($"./{fileName}");

            return output;
        }

        public string Disonnect(string fileName)
        {
            var output = string.Empty;
            return output;
        }

        public bool Status(string fileName)
        {
            throw new NotImplementedException();
        }

        private string Bash(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}