namespace OOP.Logger
{
    public interface ILogger
    {
        void Log(string Message);
        void LogError(string Message);
        void LogInformation(string Message);
        void LogWarning(string Message);
    }
}