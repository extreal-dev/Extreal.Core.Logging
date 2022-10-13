namespace Extreal.Core.Logging.Test
{
    public class AppLogOutputChecker : ILogOutputChecker
    {
        private LogLevel _logLevel;
        private bool _isDebug;
        private bool _isInfo;
        private bool _isWarn;
        private bool _isError;

        public ILogOutputChecker Clone()
        {
            var checkerClone = new AppLogOutputChecker();
            checkerClone.SetLogLevel(_logLevel);
            return checkerClone;
        }

        public void SetLogLevel(LogLevel logLevel)
        {
            _logLevel = logLevel;
            _isDebug = logLevel <= LogLevel.DEBUG;
            _isInfo = logLevel <= LogLevel.INFO;
            _isWarn = logLevel <= LogLevel.WARN;
            _isError = logLevel <= LogLevel.ERROR;
        }

        public bool IsDebug(string logCategory)
        {
            return _isDebug || logCategory == "Debugger";
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
