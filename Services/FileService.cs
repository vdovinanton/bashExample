using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class FileService : IFileService
    {
        private readonly string _rootDirectory;
        public FileService() => _rootDirectory = Directory.GetCurrentDirectory();
        public Task CreateConnectScriptAsync(string fileName)
        {
            var task = Task.Run(() => {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    //writer.NewLine = "\n";
                    writer.NewLine = Environment.NewLine;
                    writer.WriteLine("#!/bin/bash");
                    writer.WriteLine("osascript <<EOF");
                    writer.WriteLine("tell application \"System Events\"");
                    writer.WriteLine("tell current location of network preferences");
                    writer.WriteLine("set myVPN to the service \"UniVPN\"");
                    writer.WriteLine("if myVPN is not null then");
                    writer.WriteLine("if current configuration of myVPN is not connected then");
                    writer.WriteLine("connect myVPN");
                    writer.WriteLine("end if");
                    writer.WriteLine("end if");
                    writer.WriteLine("end tell");
                    writer.WriteLine("return 120");
                    writer.WriteLine("end tell");
                    writer.WriteLine("EOF");
                    writer.Flush();
                }
            });

            return task;
        }

        public Task<string> CreateDisconnectScriptAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool IsContains(string fileName) => File.Exists($"{_rootDirectory}//{fileName}");

        public Task<string> RemoveConnectScriptAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveDisconnectScriptAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        private string RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
