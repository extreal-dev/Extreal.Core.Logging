using System;
using UnityEngine;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// <para>Class for handling logs.</para>
    /// Checks automatically using ILogOutputChecker if logs should be output before logs are output.
    /// Logs are output using ILogWriter.
    /// </summary>
    public class ELogger
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
        internal ELogger
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
        /// Logs debug with/without exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogDebug(string message, Exception exception = null)
        {
            Log(LogLevel.Debug, message, exception);
        }

        /// <summary>
        /// Logs information with/without exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogInfo(string message, Exception exception = null)
        {
            Log(LogLevel.Info, message, exception);
        }

        /// <summary>
        /// Logs warning with/without exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogWarn(string message, Exception exception = null)
        {
            Log(LogLevel.Warn, message, exception);
        }

        /// <summary>
        /// Logs error with/without exception.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void LogError(string message, Exception exception = null)
        {
            Log(LogLevel.Error, message, exception);
        }

        /// <summary>
        /// Checks if debug logs should be output.
        /// </summary>
        /// <returns>True if it is set to log debug, false otherwise.</returns>
        public bool IsDebug()
        {
            return IsOutput(LogLevel.Debug);
        }

        /// <summary>
        /// Checks if information logs should be output.
        /// </summary>
        /// <returns>True if it is set to log information, false otherwise.</returns>
        public bool IsInfo()
        {
            return IsOutput(LogLevel.Info);
        }

        /// <summary>
        /// Checks if warning logs should be output.
        /// </summary>
        /// <returns>True if it is set to log warning, false otherwise.</returns>
        public bool IsWarn()
        {
            return IsOutput(LogLevel.Warn);
        }

        /// <summary>
        /// Checks if error logs should be output.
        /// </summary>
        /// <returns>True if it is set to log error, false otherwise.</returns>
        public bool IsError()
        {
            return IsOutput(LogLevel.Error);
        }

        private void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            if (IsOutput(logLevel))
            {
                try
                {
                    _writer.Log(logLevel, _logCategory, message, exception);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        private bool IsOutput(LogLevel logLevel)
        {
            try
            {
                return _checker.IsOutput(logLevel, _logCategory);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return false;
        }
    }
}
