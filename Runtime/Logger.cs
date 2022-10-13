using System;

namespace Extreal.Core.Logging
{
    public class Logger
    {
        private readonly ILogWriter _writer;
        private readonly ILogOutputChecker _checker;
        private readonly string _logCategory;

        public Logger(
            string logCategory,
            ILogWriter logWriter,
            ILogOutputChecker logOutputChecker
        )
        {
            _logCategory = logCategory;
            _writer = logWriter;
            _checker = logOutputChecker;
        }

        public void LogDebug(string message)
        {
            if (IsDebug())
            {
                _writer.LogDebug(_logCategory, message);
            }
        }

        public void LogDebug(string message, Exception exception)
        {
            if (IsDebug())
            {
                _writer.LogDebug(_logCategory, message, exception);
            }
        }

        public void LogInfo(string message)
        {
            if (IsInfo())
            {
                _writer.LogInfo(_logCategory, message);
            }
        }

        public void LogInfo(string message, Exception exception)
        {
            if (IsInfo())
            {
                _writer.LogInfo(_logCategory, message, exception);
            }
        }

        public void LogWarn(string message)
        {
            if (IsWarn())
            {
                _writer.LogWarn(_logCategory, message);
            }
        }

        public void LogWarn(string message, Exception exception)
        {
            if (IsWarn())
            {
                _writer.LogWarn(_logCategory, message, exception);
            }
        }

        public void LogError(string message)
        {
            if (IsError())
            {
                _writer.LogError(_logCategory, message);
            }
        }

        public void LogError(string message, Exception exception)
        {
            if (IsError())
            {
                _writer.LogError(_logCategory, message, exception);
            }
        }

        public bool IsDebug()
        {
            return _checker.IsDebug(_logCategory);
        }

        public bool IsInfo()
        {
            return _checker.IsInfo(_logCategory);
        }

        public bool IsWarn()
        {
            return _checker.IsWarn(_logCategory);
        }

        public bool IsError()
        {
            return _checker.IsError(_logCategory);
        }
    }
}
