using System;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class for handling logs.
    /// </summary>
    public class Logger
    {
        private readonly ILogWriter _writer;
        private readonly ILogOutputChecker _checker;
        private readonly string _logCategory;

        /// <summary>
        /// Creates a new Logger with given logCategory, logWriter and logOutputChecker.
        /// </summary>
        /// <param name="logCategory">Category to log.</param>
        /// <param name="logWriter">Used that logs are output.</param>
        /// <param name="logOutputChecker">Used to check if logs are output according to LogLevel.</param>
        internal Logger
        (
            string logCategory,
            ILogWriter logWriter,
            ILogOutputChecker logOutputChecker
        )
        {
            _logCategory = logCategory;
            _writer = logWriter;
            _checker = logOutputChecker;
        }

        /// <summary>
        /// Logs debug.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void LogDebug(string message)
        {
            if (IsDebug())
            {
                _writer.LogDebug(_logCategory, message);
            }
        }

        /// <summary>
        /// Logs debug with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogDebug(string message, Exception exception)
        {
            if (IsDebug())
            {
                _writer.LogDebug(_logCategory, message, exception);
            }
        }

        /// <summary>
        /// Logs information with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void LogInfo(string message)
        {
            if (IsInfo())
            {
                _writer.LogInfo(_logCategory, message);
            }
        }

        /// <summary>
        /// Logs information with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogInfo(string message, Exception exception)
        {
            if (IsInfo())
            {
                _writer.LogInfo(_logCategory, message, exception);
            }
        }

        /// <summary>
        /// Logs warning with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void LogWarn(string message)
        {
            if (IsWarn())
            {
                _writer.LogWarn(_logCategory, message);
            }
        }

        /// <summary>
        /// Logs warning with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogWarn(string message, Exception exception)
        {
            if (IsWarn())
            {
                _writer.LogWarn(_logCategory, message, exception);
            }
        }

        /// <summary>
        /// Logs error with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void LogError(string message)
        {
            if (IsError())
            {
                _writer.LogError(_logCategory, message);
            }
        }

        /// <summary>
        /// Logs error with exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogError(string message, Exception exception)
        {
            if (IsError())
            {
                _writer.LogError(_logCategory, message, exception);
            }
        }

        /// <summary>
        /// Checks if debug logs are output.
        /// </summary>
        /// <returns>True if it is set to log debug, false otherwise.</returns>
        public bool IsDebug()
        {
            return _checker.IsDebug(_logCategory);
        }

        /// <summary>
        /// Checks if information logs are output.
        /// </summary>
        /// <returns>True if it is set to log information, false otherwise.</returns>
        public bool IsInfo()
        {
            return _checker.IsInfo(_logCategory);
        }

        /// <summary>
        /// Checks if warning logs are output.
        /// </summary>
        /// <returns>True if it is set to log warning, false otherwise.</returns>
        public bool IsWarn()
        {
            return _checker.IsWarn(_logCategory);
        }

        /// <summary>
        /// Checks if error logs are output.
        /// </summary>
        /// <returns>True if it is set to log error, false otherwise.</returns>
        public bool IsError()
        {
            return _checker.IsError(_logCategory);
        }
    }
}
