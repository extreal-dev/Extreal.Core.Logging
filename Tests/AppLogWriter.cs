using System;
using UnityEngine;

namespace Extreal.Core.Logging.Test
{
    public class AppLogWriter : ILogWriter
    {
        public void LogDebug(string logCategory, string message)
        {
            Debug.Log($"(o-o) {logCategory}: {message}");
        }

        public void LogDebug(string logCategory, string message, Exception exception)
        {
            Debug.Log
            (
                $"(o-o) {logCategory}: {message}"
                + "---- Exception ----"
                + exception
                + "-------------------"
            );
        }

        public void LogInfo(string logCategory, string message)
        {
            Debug.Log($"(^_^) {logCategory}: {message}");
        }

        public void LogInfo(string logCategory, string message, Exception exception)
        {
            Debug.Log
            (
                $"(^_^) {logCategory}: {message}"
                + "---- Exception ----"
                + exception
                + "-------------------"
            );
        }

        public void LogWarn(string logCategory, string message)
        {
            Debug.LogWarning($"(--; {logCategory}: {message}");
        }

        public void LogWarn(string logCategory, string message, Exception exception)
        {
            Debug.LogWarning
            (
                $"(--; {logCategory}: {message}"
                + "---- Exception ----"
                + exception
                + "-------------------"
            );
        }

        public void LogError(string logCategory, string message)
        {
            Debug.LogError($"(*A*; {logCategory}: {message}");
        }

        public void LogError(string logCategory, string message, Exception exception)
        {
            Debug.LogError
            (
                $"(*A*; {logCategory}: {message}"
                + "---- Exception ----"
                + exception
                + "-------------------"
            );
        }
    }
}
