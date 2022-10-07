using System;
using UnityEngine;

namespace Extreal.Core.Logging
{
    public class UnityDebugLogWriter : ILogWriter
    {
        public void LogDebug(Logger logger, string message)
        {
            Debug.Log($"[{LogLevel.Debug}:{logger.LogCategory}] {message}");
        }

        public void LogDebug(Logger logger, string message, Exception exception)
        {
            Debug.Log($"[{LogLevel.Debug}:{logger.LogCategory}] {message}\n----------\n{exception}");
        }

        public void LogInfo(Logger logger, string message)
        {
            Debug.Log($"[{LogLevel.Info}:{logger.LogCategory}] {message}");
        }

        public void LogInfo(Logger logger, string message, Exception exception)
        {
            Debug.Log($"[{LogLevel.Info}:{logger.LogCategory}] {message}\n----------\n{exception}");
        }

        public void LogWarn(Logger logger, string message)
        {
            Debug.LogWarning($"[{LogLevel.Warn}:{logger.LogCategory}] {message}");
        }

        public void LogWarn(Logger logger, string message, Exception exception)
        {
            Debug.LogWarning($"[{LogLevel.Warn}:{logger.LogCategory}] {message}\n----------\n{exception}");
        }

        public void LogError(Logger logger, string message)
        {
            Debug.LogError($"[{LogLevel.Error}:{logger.LogCategory}] {message}");
        }

        public void LogError(Logger logger, string message, Exception exception)
        {
            Debug.LogError($"[{LogLevel.Error}:{logger.LogCategory}] {message}\n----------\n{exception}");
        }
    }
}
