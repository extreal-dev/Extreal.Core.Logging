using System;
using System.Text;
using UnityEngine;

namespace Extreal.Core.Logging.Test
{
    public class AppLogWriter : ILogWriter
    {
        public void Log(LogLevel logLevel, string logCategory, string message, Exception exception = null)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    Debug.Log(LogFormat("o-o", logCategory, message, exception));
                    break;

                case LogLevel.Info:
                    Debug.Log(LogFormat("(^_^)", logCategory, message, exception));
                    break;

                case LogLevel.Warn:
                    Debug.LogWarning(LogFormat("(--;", logCategory, message, exception));
                    break;

                case LogLevel.Error:
                    Debug.LogError(LogFormat("(*A*;", logCategory, message, exception));
                    break;

                default:
                    throw new Exception("Undefined LogLevel was input");
            }
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
