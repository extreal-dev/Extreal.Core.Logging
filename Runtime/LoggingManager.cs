using System.Collections.Generic;

namespace Extreal.Core.Logging
{
    public static class LoggingManager
    {
        private static ILogWriter s_writer = new UnityDebugLogWriter();
        private static ILogOutputChecker s_checker = new LogLevelLogOutputChecker();
        private static Dictionary<string, Logger> s_loggers = new Dictionary<string, Logger>();

        public static Logger GetLogger(string logCategory)
        {
            if (s_loggers.ContainsKey(logCategory))
            {
                return s_loggers[logCategory];
            }
            return s_loggers[logCategory] = new Logger(logCategory, s_writer, s_checker);
        }

        public static void Initialize(LogLevel logLevel = LogLevel.Info, ILogOutputChecker checker = null, ILogWriter writer = null)
        {
            s_checker = checker ?? new LogLevelLogOutputChecker();
            s_writer = writer ?? new UnityDebugLogWriter();
            s_checker.SetLogLevel(logLevel);
            s_loggers.Clear();
        }
    }
}
