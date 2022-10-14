using System.Text;
using System;
using UnityEngine;

namespace Extreal.Core.Logging
{
    public class UnityDebugLogWriter : ILogWriter
    {
        public ILogWriter Clone()
        {
            return new UnityDebugLogWriter();
        }

        public void LogDebug(string logCategory, string message)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Debug, message));
        }

        public void LogDebug(string logCategory, string message, Exception exception)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Debug, message, exception));
        }

        public void LogInfo(string logCategory, string message)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Info, message));
        }

        public void LogInfo(string logCategory, string message, Exception exception)
        {
            Debug.Log(LogFormat(logCategory, LogLevel.Info, message, exception));
        }

        public void LogWarn(string logCategory, string message)
        {
            Debug.LogWarning(LogFormat(logCategory, LogLevel.Warn, message));
        }

        public void LogWarn(string logCategory, string message, Exception exception)
        {
            Debug.LogWarning(LogFormat(logCategory, LogLevel.Warn, message, exception));
        }

        public void LogError(string logCategory, string message)
        {
            Debug.LogError(LogFormat(logCategory, LogLevel.Error, message));
        }

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
