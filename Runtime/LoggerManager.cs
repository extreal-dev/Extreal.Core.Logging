namespace Extreal.Core.Logging
{
    public static class LoggerManager
    {
        private static ILogWriter s_writer = new UnityDebugLogWriter();
        private static ILogOutputChecker s_checker = new LogLevelLogOutputChecker();
        private static LogLevel s_logLevel = new LogLevel();

        public static Logger Create(string logCategory)
        {
            return new Logger(logCategory, s_logLevel, s_writer, s_checker);
        }

        public static void SetLogWriter(ILogWriter logWriter)
        {
            s_writer = logWriter;
        }

        public static void SetLogOutputChecker(ILogOutputChecker logOutputChecker)
        {
            s_checker = logOutputChecker;
        }

        public static void SetLogLevel(LogLevel logLevel)
        {
            s_logLevel = logLevel;
        }
    }
}
