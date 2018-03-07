using CoreApp.Services;

namespace CoreApp
{
    public class CommandManager
    {
        private readonly ICommandLineService _terminalService;
        private readonly IFileService _fileService;

        private readonly string _fileNameConnect;
        private readonly string _fileNameDisconnect;
        public CommandManager(ICommandLineService terminalService, IFileService fileService)
        {
            _terminalService = terminalService;
            _fileService = fileService;

            _fileNameConnect = "scriptConnect";
            _fileNameDisconnect = "scriptDisconnect";
        }

        public string Connect()
        {
            CreateOrUpdateAsync(_fileNameConnect);
            var result = _terminalService.Connect(_fileNameConnect);
            return result;
        }

        public string Disconnect()
        {
            CreateOrUpdateAsync(_fileNameDisconnect);
            var result = _terminalService.Disonnect(_fileNameDisconnect);
            return result;
        }

        private void CreateOrUpdateAsync(string fileName)
        {
            var isContains = _fileService.IsContains(fileName);
            if (!isContains)
                _fileService.CreateConnectScriptAsync(fileName).Wait();
        }
    }
}
