namespace Extreal.Core.Logging.Test
{
    public class AppLogOutputChecker : ILogOutputChecker
    {
        private bool _isDebug;
        private bool _isInfo;
        private bool _isWarn;
        private bool _isError;

        public void Initialize(LogLevel logLevel)
        {
            _isDebug = logLevel <= LogLevel.Debug;
            _isInfo = logLevel <= LogLevel.Info;
            _isWarn = logLevel <= LogLevel.Warn;
            _isError = logLevel <= LogLevel.Error;
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
