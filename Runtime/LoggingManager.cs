using System.Collections.Generic;
namespace Extreal.Core.Logging
{
    public static class LoggingManager
    {
        private static ILogWriter s_writer = new UnityDebugLogWriter();
        private static ILogOutputChecker s_checker = new LogLevelLogOutputChecker();
        private static LogLevel s_logLevel = LogLevel.INFO;
        private static Dictionary<string, Logger> s_loggerDict = new Dictionary<string, Logger>();

        public static Logger GetLogger(string logCategory)
        {
            if (s_loggerDict.ContainsKey(logCategory))
            {
                return s_loggerDict[logCategory];
            }
            return s_loggerDict[logCategory] = new Logger(logCategory, s_writer, s_checker);
        }

        public static void SetLogLevel(LogLevel logLevel)
        {
            s_logLevel = logLevel;
            SetLogLevel2LogOutputChecker();
        }

        public static void SetLogOutputChecker(ILogOutputChecker logOutputChecker)
        {
            s_checker = logOutputChecker;
            SetLogLevel2LogOutputChecker();
        }

        public static void SetLogWriter(ILogWriter logWriter)
        {
            s_writer = logWriter;
        }

        private static void SetLogLevel2LogOutputChecker()
        {
            s_checker.SetLogLevel(s_logLevel);
        }
    }
}
