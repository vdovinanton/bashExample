using CoreApp.Services;
using System;
using System.Diagnostics;
using System.IO;

namespace CoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = DateTime.Now;
            Console.WriteLine($"Run at  {time.ToShortTimeString()}");

            var file = new FileService();
            var bash = new MacService();

            var console = new CommandManager(bash, file);

            console.Connect();

            Console.ReadKey();
        }
    }

    public static class ShellHelper
    {
        public static string Bash(this string cmd)
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