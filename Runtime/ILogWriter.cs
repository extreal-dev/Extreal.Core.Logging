using System;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// Interface for implementation how to log.
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Logs debug.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        void LogDebug(string logCategory, string message);

        /// <summary>
        /// Logs debug with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        void LogDebug(string logCategory, string message, Exception exception);

        /// <summary>
        /// Logs infomation.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        void LogInfo(string logCategory, string message);

        /// <summary>
        /// Logs infomation with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        void LogInfo(string logCategory, string message, Exception exception);

        /// <summary>
        /// Logs warning.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        void LogWarn(string logCategory, string message);

        /// <summary>
        /// Logs warning with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        void LogWarn(string logCategory, string message, Exception exception);

        /// <summary>
        /// Logs error.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        void LogError(string logCategory, string message);

        /// <summary>
        /// Logs error with exception.
        /// </summary>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        void LogError(string logCategory, string message, Exception exception);
    }
}
