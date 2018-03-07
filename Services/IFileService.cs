using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IFileService
    {
        bool IsContains(string fileName);
        Task CreateConnectScriptAsync(string fileName);
        Task<string> CreateDisconnectScriptAsync(string fileName);
        Task<string> RemoveConnectScriptAsync(string fileName);
        Task<string> RemoveDisconnectScriptAsync(string fileName);
    }
}
