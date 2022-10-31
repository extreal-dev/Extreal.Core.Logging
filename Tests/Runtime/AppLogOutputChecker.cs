namespace Extreal.Core.Logging.Test
{
    public class AppLogOutputChecker : ILogOutputChecker
    {
        private LogLevel logLevel;

        public void Initialize(LogLevel logLevel)
            => this.logLevel = logLevel;

        public bool IsOutput(LogLevel logLevel, string logCategory)
            => this.logLevel <= logLevel
                || (logLevel == LogLevel.Debug && logCategory == "Debugger");
    }
}
