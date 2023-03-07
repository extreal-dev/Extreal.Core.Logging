using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class used by default for logging.
    /// </summary>
    public class UnityDebugLogWriter : ILogWriter
    {
        private readonly IDictionary<string, string> formats;

        /// <summary>
        /// Creates UnityDebugLogWriter.
        /// </summary>
        /// <param name="formats">Log format.</param>
        [SuppressMessage("Usage", "CC0057")]
        public UnityDebugLogWriter(ICollection<UnityDebugLogFormat> formats = null)
            => this.formats = formats?.ToDictionary(format => format.Category, format => format.ColorRGB);

        /// <summary>
        /// Logs message and exception.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If undefined LogLevel is input</exception>
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
            string colorRGB = null;
            formats?.TryGetValue(logCategory, out colorRGB);
            if (colorRGB != null)
            {
                stringBuilder.Append("<color=").Append(colorRGB).Append(">");
            }
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
            if (colorRGB != null)
            {
                stringBuilder.Append("</color>");
            }
            return stringBuilder.ToString();
        }
    }
}
