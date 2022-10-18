using System;
using System.Text;
using UnityEngine;

namespace Extreal.Core.Logging.Test
{
    public class AppLogWriter : ILogWriter
    {
        public void LogDebug(string logCategory, string message)
        {
            Debug.Log(LogFormat("o-o", logCategory, message));
        }

        public void LogDebug(string logCategory, string message, Exception exception)
        {
            Debug.Log(LogFormat("o-o", logCategory, message, exception));
        }

        public void LogInfo(string logCategory, string message)
        {
            Debug.Log(LogFormat("(^_^)", logCategory, message));
        }

        public void LogInfo(string logCategory, string message, Exception exception)
        {
            Debug.Log(LogFormat("(^_^)", logCategory, message, exception));
        }

        public void LogWarn(string logCategory, string message)
        {
            Debug.LogWarning(LogFormat("(--;", logCategory, message));
        }

        public void LogWarn(string logCategory, string message, Exception exception)
        {
            Debug.LogWarning(LogFormat("(--;", logCategory, message, exception));
        }

        public void LogError(string logCategory, string message)
        {
            Debug.LogError(LogFormat("(*A*;", logCategory, message));
        }

        public void LogError(string logCategory, string message, Exception exception)
        {
            Debug.LogError(LogFormat("(*A*;", logCategory, message, exception));
        }

        private string LogFormat(string logLevel, string logCategory, string message, Exception exception = null)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append(logLevel)
                .Append(" ")
                .Append(logCategory)
                .Append(": ")
                .Append(message);
            if (exception != null)
            {
                stringBuilder.Append("\n---- Exception ----\n").Append(exception).Append("\n-------------------\n");
            }
            return stringBuilder.ToString();
        }
    }
}
