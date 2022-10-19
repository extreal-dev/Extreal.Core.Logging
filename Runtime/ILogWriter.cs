using System;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// <para>Interface for implementation how to log.</para>
    /// Implementation of this should not throw exceptions to avoid stopping main execution.
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Logs message and exception.
        /// </summary>
        /// <param name="logLevel">LogLevel used in logs.</param>
        /// <param name="logCategory">Category used in logs.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        void Log(LogLevel logLevel, string logCategory, string message, Exception exception);
    }
}
