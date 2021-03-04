using System.Diagnostics;
using System.Text;

namespace OOP.Logger
{
    public class SampleLogger
    {
        public static void Demo()
        {
            //Logger logger = new ListLogger();

            //Logger logger = new FileLogger("Log.log");
            //Logger logger = new VisualStudioLogger();
            Logger logger = new TrasseLoger();
            Trace.Listeners.Add(new TextWriterTraceListener("tracelogger.log"));  //  <-------------

            logger.LogInformation("Start Programm!");
            for (int i = 0; i < 10; i++)
            {
                logger.LogInformation($"Do some work{i + 1}");
            }
            logger.LogInformation("Завершение работы!");

            // получение списка всех сообщений
            //var log_messages = ((ListLogger)logger).Messages;

            Trace.Flush();   //  <-------------
        }
    }

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
