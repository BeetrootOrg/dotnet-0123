namespace ConsoleApp.Helpers
{
    public static class Logger
    {
        public static readonly string LogFile = "./log.txt";

        public static void Log(string message, LoggerLevel loggerLevel)
        {
            CheckExist();
            message = $"{DateTime.Now}-{loggerLevel}-{message}\n";
            Console.WriteLine(message);
            File.AppendAllTextAsync(LogFile, message);
        }

        public static void LogError(Exception ex)
        {
            Log(ex.ToString(), LoggerLevel.Error);
        }

        public static void CheckExist()
        {
            if (!File.Exists(LogFile))
            {
                File.Create(LogFile);
            }
        }
    }

    public enum LoggerLevel
    {
        Debug = 0, Error = 1, Info = 2, Warning = 3,
    }
}