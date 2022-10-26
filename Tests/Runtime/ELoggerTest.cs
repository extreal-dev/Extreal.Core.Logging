namespace Extreal.Core.Logging.Test
{
    using System;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.TestTools;

    public class ELoggerTest
    {
        private Exception exception = new Exception();

        [SetUp]
        public void Initialize()
            => LoggingManager.Initialize(writer: new UnityDebugLogWriter(), checker: new LogLevelLogOutputChecker());

        [Test]
        public void LogMessageIsNull()
        {
            #region settings

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string logCategory = "LogMessageNullTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print info
            // Logs are output except message
            const string message = null;
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] ");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] \n----------\n{exception}");
        }

        [Test]
        public void LogExceptionIsNull()
        {
            #region settings

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string logCategory = "LogExceptionNullTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print info
            // Logs that are the same as ones with only message are output
            const string message = "Info";
            const Exception exception = null;
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
        }

        [Test]
        public void LogOutputCheckerThrowsException()
        {
            #region Settings

            // Initialize LoggingManager
            LoggingManager.Initialize(checker: new CheckerMock());

            // Make logger
            const string logCategory = "CheckerThrowsExceptionTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test using mock of ILogOutputChecker whose method named 'IsOutput' throws exception
            // Exception logs are output in console of Unity Editor and main execution doesn't stop
            const string message = "Info";
            var expectedMessage = $"{nameof(Exception)}: {exception.Message}";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Exception, expectedMessage);
            Assert.IsFalse(logger.IsInfo());
            LogAssert.Expect(LogType.Exception, expectedMessage);
        }

        [Test]
        public void LogWriterThrowsException()
        {
            #region Settings

            // Initialize LoggingManager
            LoggingManager.Initialize(writer: new WriterMock());

            // Make logger
            const string logCategory = "CheckerThrowsExceptionTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test using mock of ILogWriter whose method named 'Log' throws exception
            // Exception logs are output in console of Unity Editor and main execution doesn't stop
            const string message = "Info";
            var expectedMessage = $"{nameof(Exception)}: {exception.Message}";
            logger.LogInfo(message);
            Debug.Log(expectedMessage);
            LogAssert.Expect(LogType.Exception, expectedMessage);
        }
    }

    public class CheckerMock : ILogOutputChecker
    {
        public void Initialize(LogLevel logLevel) { }

        public bool IsOutput(LogLevel logLevel, string logCategory)
            => throw new Exception();
    }

    public class WriterMock : ILogWriter
    {
        public void Log(LogLevel logLevel, string logCategory, string message, Exception exception = null)
            => throw new Exception();
    }
}
