using System.Collections.Generic;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class for managing logs.
    /// </summary>
    public static class LoggingManager
    {
        private static ILogWriter s_writer = new UnityDebugLogWriter();
        private static ILogOutputChecker s_checker = new LogLevelLogOutputChecker();
        private static Dictionary<string, Logger> s_loggers = new Dictionary<string, Logger>();

        /// <summary>
        /// Get Logger created with same category past if any.
        /// Otherwise get newly created Logger.
        /// </summary>
        /// <param name="logCategory">Category to log.</param>
        /// <returns>Logger with logCategory.</returns>
        public static Logger GetLogger(string logCategory)
        {
            if (s_loggers.ContainsKey(logCategory))
            {
                return s_loggers[logCategory];
            }
            return s_loggers[logCategory] = new Logger(logCategory, s_writer, s_checker);
        }

        /// <summary>
        /// Initializes LoggingManager.
        /// As default, let logLevel be Info, let checker be LogLevelLogOutputChecker
        /// and let writer be UnityDebugLogWriter.
        /// In addition, clear Logger history.
        /// </summary>
        /// <param name="logLevel">LogLevel to be set.</param>
        /// <param name="checker">LogOutputChecker to be set.</param>
        /// <param name="writer">LogWriter to be set.</param>
        public static void Initialize(LogLevel logLevel = LogLevel.Info, ILogOutputChecker checker = null, ILogWriter writer = null)
        {
            s_checker = checker ?? new LogLevelLogOutputChecker();
            s_writer = writer ?? new UnityDebugLogWriter();
            s_checker.Initialize(logLevel);
            s_loggers.Clear();
        }
    }
}
