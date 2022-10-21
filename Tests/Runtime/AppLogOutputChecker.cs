namespace Extreal.Core.Logging.Test
{
    public class AppLogOutputChecker : ILogOutputChecker
    {
        private LogLevel _logLevel;

        public void Initialize(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public bool IsOutput(LogLevel logLevel, string logCategory)
        {
            return _logLevel <= logLevel
                    || (logLevel == LogLevel.Debug && logCategory == "Debugger");
        }
    }
}
