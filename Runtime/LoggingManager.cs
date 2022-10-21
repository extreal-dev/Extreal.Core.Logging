using System;
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
        private static readonly Dictionary<string, ELogger> s_loggers = new Dictionary<string, ELogger>();

        /// <summary>
        /// Get Logger created with same category past if any.
        /// Otherwise get newly created Logger.
        /// </summary>
        /// <param name="logCategory">Category to log.</param>
        /// <returns>Logger with logCategory.</returns>
        public static ELogger GetLogger(string logCategory)
        {
            if (logCategory == null)
            {
                throw new ArgumentNullException(nameof(logCategory));
            }
            if (s_loggers.ContainsKey(logCategory))
            {
                return s_loggers[logCategory];
            }
            return s_loggers[logCategory] = new ELogger(logCategory, s_writer, s_checker);
        }

        /// <summary>
        /// Initializes LoggingManager.
        /// By default, let logLevel be Info, let checker be LogLevelLogOutputChecker
        /// and let writer be UnityDebugLogWriter.
        /// In addition, clear Logger history.
        /// </summary>
        /// <param name="logLevel">LogLevel to be set.</param>
        /// <param name="checker">LogOutputChecker to be set.</param>
        /// <param name="writer">LogWriter to be set.</param>
        public static void Initialize(LogLevel logLevel = LogLevel.Info, ILogOutputChecker checker = null, ILogWriter writer = null)
        {
            s_checker = checker ?? s_checker;
            s_writer = writer ?? s_writer;
            s_checker.Initialize(logLevel);
            s_loggers.Clear();
        }
    }
}
