using System;
using System.Text;
using UnityEngine;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class used as default for logging.
    /// </summary>
    public class UnityDebugLogWriter : ILogWriter
    {
        /// <summary>
        /// Logs debug.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        public void LogDebug(string logCategory, string message)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Debug, message));
        }

        /// <summary>
        /// Logs debug with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogDebug(string logCategory, string message, Exception exception)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Debug, message, exception));
        }

        /// <summary>
        /// Logs infomation.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        public void LogInfo(string logCategory, string message)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Info, message));
        }

        /// <summary>
        /// Logs infomation with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogInfo(string logCategory, string message, Exception exception)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Info, message, exception));
        }

        /// <summary>
        /// Logs warning.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        public void LogWarn(string logCategory, string message)
        {
            Debug.LogWarning(LogFormat(logCategory, LogLevel.Warn, message));
        }

        /// <summary>
        /// Logs warning with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogWarn(string logCategory, string message, Exception exception)
        {
            Debug.LogWarning(LogFormat(logCategory, LogLevel.Warn, message, exception));
        }

        /// <summary>
        /// Logs error.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        public void LogError(string logCategory, string message)
        {
            Debug.LogError(LogFormat(logCategory, LogLevel.Error, message));
        }

        /// <summary>
        /// Logs error with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogError(string logCategory, string message, Exception exception)
        {
            Debug.LogError(LogFormat(logCategory, LogLevel.Error, message, exception));
        }

        private string LogFormat(string logCategory, LogLevel logLevel, string message, Exception exception = null)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append("[")
                .Append(logLevel)
                .Append(":")
                .Append(logCategory)
                .Append("] ")
                .Append(message);
            if (exception != null)
            {
                stringBuilder.Append("\n----------\n").Append(exception);
            }
            return stringBuilder.ToString();
        }
    }
}
