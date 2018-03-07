namespace CoreApp.Services
{
    public interface ICommandLineService
    {
        string Connect(string fileName);
        string Disonnect(string fileName);
        bool Status(string fileName);
    }
}
