using NUnit.Framework;

namespace AutoTestBase
{
    public static class Log
    {
        public enum Level { Debug, Info, Success, Warn, Error }

        private static void LogMessage(Level level, string message)
        {
            string logMessage = $"{level.ToString().ToUpper()} | {message}";
            TestContext.Progress.Write(logMessage);
            Console.WriteLine(logMessage);

            if (level == Level.Error) throw new Exception(logMessage);
        }


        public static void Debug(string message) => LogMessage(Level.Debug, message);
        public static void Info(string message) => LogMessage(Level.Info, message);
        public static void Success(string message) => LogMessage(Level.Success, message);
        public static void Warn(string message) => LogMessage(Level.Warn, message);
        public static void Error(string message) => LogMessage(Level.Error, message);
    }

    // TODO: Add TC Name
    // TODO: Add timings
    // TODO: Add Allure reporting
}
