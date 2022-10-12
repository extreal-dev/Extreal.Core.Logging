namespace Extreal.Core.Logging.Test
{
    public static class LoggingManagerInitializer
    {
        public static void Initialize()
        {
            LoggingManager.SetLogLevel(LogLevel.INFO);
            LoggingManager.SetLogOutputChecker(new LogLevelLogOutputChecker());
            LoggingManager.SetLogWriter(new UnityDebugLogWriter());
        }
    }
}
