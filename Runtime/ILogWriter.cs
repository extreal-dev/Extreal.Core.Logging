using System;

namespace Extreal.Core.Logging
{
    public interface ILogWriter
    {
        ILogWriter Clone();
        void LogDebug(string logCategory, string message);
        void LogDebug(string logCategory, string message, Exception exception);
        void LogInfo(string logCategory, string message);
        void LogInfo(string logCategory, string message, Exception exception);
        void LogWarn(string logCategory, string message);
        void LogWarn(string logCategory, string message, Exception exception);
        void LogError(string logCategory, string message);
        void LogError(string logCategory, string message, Exception exception);
    }
}
