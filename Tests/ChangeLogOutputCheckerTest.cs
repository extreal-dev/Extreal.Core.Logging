using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Extreal.Core.Logging.Test
{
    public class ChangeLogOutputCheckerTest
    {
        private const string LOG_CATEGORY = "CHECKERTEST";
        private Exception _exception = new Exception();

        [SetUp]
        public void Initialize()
        {
            LoggingManagerInitializer.Initialize();

            // Change LogOutputChecker
            LoggingManager.SetLogOutputChecker(new TestLogOutputChecker());
        }

        /// <summary>
        /// Test to see if LogOutputChecker can be changed
        /// </summary>
        [Test]
        public void Test()
        {
            // Make logger
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.DEBUG}:{LOG_CATEGORY}] {message}");
            logger.LogDebug(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.DEBUG}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        // Customized LogOutputChecker class
        private class TestLogOutputChecker : ILogOutputChecker
        {
            private bool _isDebug;
            private bool _isInfo;
            private bool _isWarn;
            private bool _isError;

            public bool IsDebug(string logCategory)
            {
                return _isDebug || logCategory == "CHECKERTEST";
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

            public void SetLogLevel(LogLevel logLevel)
            {
                _isDebug = logLevel <= LogLevel.DEBUG;
                _isInfo = logLevel <= LogLevel.INFO;
                _isWarn = logLevel <= LogLevel.WARN;
                _isError = logLevel <= LogLevel.ERROR;
            }
        }
    }
}
