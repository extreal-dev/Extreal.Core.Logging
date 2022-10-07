using System;
namespace Extreal.Core.Logging
{
    public interface ILogWriter
    {
        void LogDebug(Logger logger, string message);
        void LogDebug(Logger logger, string message, Exception exception);
        void LogInfo(Logger logger, string message);
        void LogInfo(Logger logger, string message, Exception exception);
        void LogWarn(Logger logger, string message);
        void LogWarn(Logger logger, string message, Exception exception);
        void LogError(Logger logger, string message);
        void LogError(Logger logger, string message, Exception exception);
    }
}
