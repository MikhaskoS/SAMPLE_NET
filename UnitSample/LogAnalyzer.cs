namespace UnitSample
{
    public class LogAnalyzer
    {
        public static bool IsInvalidLogFileName(string fileName)
        {
            if (!fileName.EndsWith(".SLF", System.StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
