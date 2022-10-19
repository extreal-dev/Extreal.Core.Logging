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
        /// <para>Logs message and exception.</para>
        /// Logs exception in console of Unity Editor when ILogWriter throws one.
        /// </summary>
        /// <param name="logLevel">LogLevel used in logs</param>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void Log(LogLevel logLevel, string message, Exception exception = null)
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

        /// <summary>
        /// <para>Checks if logs should be output.</para>
        /// Logs exception in console of Unity Editor when ILogOutputChecker throws one.
        /// </summary>
        /// <param name="logLevel">LogLevel used to check.</param>
        /// <returns>True if logs should be output, false otherwise.</returns>
        public bool IsOutput(LogLevel logLevel)
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
