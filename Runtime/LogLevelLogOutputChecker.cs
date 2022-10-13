namespace Extreal.Core.Logging
{
    public class LogLevelLogOutputChecker : ILogOutputChecker
    {
        private bool _isDebug = false;
        private bool _isInfo = true;
        private bool _isWarn = true;
        private bool _isError = true;

        public void SetLogLevel(LogLevel logLevel)
        {
            _isDebug = logLevel <= LogLevel.DEBUG;
            _isInfo = logLevel <= LogLevel.INFO;
            _isWarn = logLevel <= LogLevel.WARN;
            _isError = logLevel <= LogLevel.ERROR;
        }

        public bool IsDebug(string logCategory)
        {
            return _isDebug;
        }

        public bool IsInfo(string logCategory)
        {
            return _isInfo;
        }

        public bool IsWarn(string logCategory)
        {
            return _isWarn;
        }

        public bool IsError(string logCategory)
        {
            return _isError;
        }
    }
}
