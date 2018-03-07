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

            var manager = new CommandManager(bash, file);

            manager.Connect();

            #region unusage
            //var fileName = "sc3.txt";
            //var rootDirectory = Directory.GetCurrentDirectory();
            //var filePath = $"{Directory.GetCurrentDirectory()}//{fileName}";


            //Console.WriteLine(rootDirectory);
            //Console.WriteLine(filePath);

            //var isFile = File.Exists(filePath);
            //Console.WriteLine(isFile);
            //if (!isFile)
            //    using (StreamWriter writer = new StreamWriter(fileName))
            //    {
            //        //writer.NewLine = "\n";
            //        writer.NewLine = Environment.NewLine;
            //        writer.WriteLine("#!/bin/bash");
            //        writer.WriteLine("osascript <<EOF");
            //        writer.WriteLine("tell application \"System Events\"");
            //        writer.WriteLine("tell current location of network preferences");
            //        writer.WriteLine("set myVPN to the service \"UniVPN\"");
            //        writer.WriteLine("if myVPN is not null then");
            //        writer.WriteLine("if current configuration of myVPN is not connected then");
            //        writer.WriteLine("connect myVPN");
            //        writer.WriteLine("end if");
            //        writer.WriteLine("end if");
            //        writer.WriteLine("end tell");
            //        writer.WriteLine("return 120");
            //        writer.WriteLine("end tell");
            //        writer.WriteLine("EOF");
            //        writer.Flush();
            //    }

            //var cmd = $"./{fileName}";

            //$"chmod 700 {filePath}".Bash();
            //var output = cmd.Bash();

            #endregion

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



//var appleScriptCmd = //"#!/bin/bash" +
//        "osascript <<EOF" +
//        "tell application \"System Events\"" +
//        "tell current location of network preferences" +
//            "set myVPN to the service \"UniVPN\"" +
//            "if myVPN is not null then " +
//            "if current configuration of myVPN is not connected then" +
//                "connect myVPN" +
//            "end if" +
//            "end if" +
//        "end tell" +
//        "return 120 " +
//        "end tell" +
//        "EOF";

//var appleScriptDemo = "osascript -e 'tell application \"Finder\"\ndisplay dialog \"Hello World\"\nend tell";

//var ifconfigCmd = "ifconfig";
//using (StreamWriter writer = new StreamWriter(fileName))
//{
//    writer.Write("Word ");
//    writer.WriteLine("word 2");
//    writer.WriteLine("Line");
//}