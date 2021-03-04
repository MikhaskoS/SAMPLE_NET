using System.Diagnostics;

namespace OOP.Logger
{
    public class SampleLogger
    {

        // Демонстрация логгера
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
}
