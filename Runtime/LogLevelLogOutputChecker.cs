namespace Extreal.Core.Logging
{
    public class LogLevelLogOutputChecker : ILogOutputChecker
    {
        private LogLevel _logLevel;
        private bool _isDebug = false;
        private bool _isInfo = true;
        private bool _isWarn = true;
        private bool _isError = true;

        public void SetLogLevel(LogLevel logLevel)
        {
            _logLevel = logLevel;
            _isDebug = logLevel <= LogLevel.Debug;
            _isInfo = logLevel <= LogLevel.Info;
            _isWarn = logLevel <= LogLevel.Warn;
            _isError = logLevel <= LogLevel.Error;
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
