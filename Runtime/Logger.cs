using System;

namespace Extreal.Core.Logging
{
    public class Logger
    {
        public string LogCategory { get; set; }
        public LogLevel LogLevel { get; set; }

        private ILogWriter _writer;
        private ILogOutputChecker _checker;

        public Logger(
            string logCategory,
            LogLevel logLevel,
            ILogWriter logWriter,
            ILogOutputChecker logOutputChecker
        )
        {
            LogCategory = logCategory;
            LogLevel = logLevel;
            _writer = logWriter;
            _checker = logOutputChecker;
        }

        public void LogDebug(string message)
        {
            if (_checker.IsDebug(this))
            {
                _writer.LogDebug(this, message);
            }
        }

        public void LogDebug(string message, Exception exception)
        {
            if (_checker.IsDebug(this))
            {
                _writer.LogDebug(this, message, exception);
            }
        }

        public void LogInfo(string message)
        {
            if (_checker.IsInfo(this))
            {
                _writer.LogInfo(this, message);
            }
        }

        public void LogInfo(string message, Exception exception)
        {
            if (_checker.IsInfo(this))
            {
                _writer.LogInfo(this, message, exception);
            }
        }

        public void LogWarn(string message)
        {
            if (_checker.IsWarn(this))
            {
                _writer.LogWarn(this, message);
            }
        }

        public void LogWarn(string message, Exception exception)
        {
            if (_checker.IsWarn(this))
            {
                _writer.LogWarn(this, message, exception);
            }
        }

        public void LogError(string message)
        {
            if (_checker.IsError(this))
            {
                _writer.LogError(this, message);
            }
        }

        public void LogError(string message, Exception exception)
        {
            if (_checker.IsError(this))
            {
                _writer.LogError(this, message, exception);
            }
        }
    }
}
