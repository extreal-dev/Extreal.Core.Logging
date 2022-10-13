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
            Debug.Log($"[{LogLevel.DEBUG}:{logCategory}] {message}");
        }

        public void LogDebug(string logCategory, string message, Exception exception)
        {
            Debug.Log($"[{LogLevel.DEBUG}:{logCategory}] {message}\n----------\n{exception}");
        }

        public void LogInfo(string logCategory, string message)
        {
            Debug.Log($"[{LogLevel.INFO}:{logCategory}] {message}");
        }

        public void LogInfo(string logCategory, string message, Exception exception)
        {
            Debug.Log($"[{LogLevel.INFO}:{logCategory}] {message}\n----------\n{exception}");
        }

        public void LogWarn(string logCategory, string message)
        {
            Debug.LogWarning($"[{LogLevel.WARN}:{logCategory}] {message}");
        }

        public void LogWarn(string logCategory, string message, Exception exception)
        {
            Debug.LogWarning($"[{LogLevel.WARN}:{logCategory}] {message}\n----------\n{exception}");
        }

        public void LogError(string logCategory, string message)
        {
            Debug.LogError($"[{LogLevel.ERROR}:{logCategory}] {message}");
        }

        public void LogError(string logCategory, string message, Exception exception)
        {
            Debug.LogError($"[{LogLevel.ERROR}:{logCategory}] {message}\n----------\n{exception}");
        }
    }
}
