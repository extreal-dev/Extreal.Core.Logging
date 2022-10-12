namespace Extreal.Core.Logging
{
    public static class LoggingManager
    {
        private static ILogWriter s_writer = new UnityDebugLogWriter();
        private static ILogOutputChecker s_checker = new LogLevelLogOutputChecker();
        private static LogLevel s_logLevel = LogLevel.INFO;

        public static Logger GetLogger(string logCategory)
        {
            return new Logger(logCategory, s_writer, s_checker);
        }

        public static void SetLogLevel(LogLevel logLevel)
        {
            s_logLevel = logLevel;
            s_checker.SetLogLevel(logLevel);
        }

        public static void SetLogOutputChecker(ILogOutputChecker logOutputChecker)
        {
            s_checker = logOutputChecker;
            s_checker.SetLogLevel(s_logLevel);
        }

        public static void SetLogWriter(ILogWriter logWriter)
        {
            s_writer = logWriter;
        }
    }
}
