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
}