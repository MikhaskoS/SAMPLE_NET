using System.Text;

namespace OOP.Logger
{

    public abstract class Logger : ILogger
    {
        public abstract void Log(string Message);

        public void LogInformation(string Message)
        {
            Log($"[Info]:{Message}");
        }
        public void LogWarning(string Message)
        {
            Log($"[Warning]:{Message}");
        }
        public void LogError(string Message)
        {
            Log($"[Error]:{Message}");
        }
    }
}
