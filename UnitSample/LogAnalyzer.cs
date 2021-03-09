using System;


namespace UnitSample
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public  bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Имя файла должно быть задано!");
            }

            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;

            return true;
        }
    }
}
