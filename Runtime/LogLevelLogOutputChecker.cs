namespace Extreal.Core.Logging
{
    public class LogLevelLogOutputChecker : ILogOutputChecker
    {
        bool ILogOutputChecker.IsDebug(Logger logger)
        {
            return logger.LogLevel <= LogLevel.Debug;
        }

        bool ILogOutputChecker.IsInfo(Logger logger)
        {
            return logger.LogLevel <= LogLevel.Info;
        }

        bool ILogOutputChecker.IsWarn(Logger logger)
        {
            return logger.LogLevel <= LogLevel.Warn;
        }

        bool ILogOutputChecker.IsError(Logger logger)
        {
            return logger.LogLevel <= LogLevel.Error;
        }
    }
}
