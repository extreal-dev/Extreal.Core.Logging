namespace Extreal.Core.Logging
{
    using System;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Class used by default for logging.
    /// </summary>
    public class UnityDebugLogWriter : ILogWriter
    {
        /// <summary>
        /// Logs message and exception.
        /// </summary>
        /// <param name="logLevel">LogLevel used in logs.</param>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void Log(LogLevel logLevel, string logCategory, string message, Exception exception = null)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                case LogLevel.Info:
                {
                    Debug.Log(LogFormat(logCategory, logLevel, message, exception));
                    break;
                }
                case LogLevel.Warn:
                {
                    Debug.LogWarning(LogFormat(logCategory, logLevel, message, exception));
                    break;
                }
                case LogLevel.Error:
                {
                    Debug.LogError(LogFormat(logCategory, logLevel, message, exception));
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(logLevel), "Undefined LogLevel was input");
                }
            }
        }

        private string LogFormat(string logCategory, LogLevel logLevel, string message, Exception exception = null)
        {
            var stringBuilder = new StringBuilder();
            _ = stringBuilder
                .Append("[")
                .Append(logLevel)
                .Append(":")
                .Append(logCategory)
                .Append("] ")
                .Append(message);
            if (exception != null)
            {
                _ = stringBuilder.Append("\n----------\n").Append(exception);
            }
            return stringBuilder.ToString();
        }
    }
}
