using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

namespace Extreal.Core.Logging.Test
{
    public class ELoggerTest
    {
        private Exception _exception = new Exception();

        [SetUp]
        public void Initialize()
        {
            UnityDebugTestUtil.StartLogReceive();
            LoggingManager.Initialize(writer: new UnityDebugLogWriter(), checker: new LogLevelLogOutputChecker());
        }

        [TearDown]
        public void Dispose()
        {
            UnityDebugTestUtil.StopLogReceive();
        }

        [Test]
        public void LogMessageIsNull()
        {
            #region settings

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string LOG_CATEGORY = "LogMessageNullTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print info
            // Logs are output except message
            const string Message = null;
            logger.Log(LogLevel.Info, Message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] ");
            logger.Log(LogLevel.Info, Message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] \n----------\n{_exception}");
        }

        [Test]
        public void LogExceptionIsNull()
        {
            #region settings

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string LOG_CATEGORY = "LogExceptionNullTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print info
            // Logs that are the same as ones with only message are output
            const string Message = "Info";
            const Exception Exception = null;
            logger.Log(LogLevel.Info, Message, Exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {Message}");
        }

        [Test]
        public void LogLevelIsUndefined()
        {
            #region Settings

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string LOG_CATEGORY = "LogLevelUndefinedTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print with undefined LogLevel
            // Except is thrown
            const string Message = "Fatal";
            var undefinedLogLevel = Enum.Parse<LogLevel>("4");
            var expectedMessage = $"{nameof(Exception)}: Undefined LogLevel was input";
            logger.Log(undefinedLogLevel, Message);
            LogAssert.Expect(LogType.Exception, expectedMessage);
        }

        [Test]
        public void LogOutputCheckerThrowsException()
        {
            #region MakeMock

            // Make mock of ILogOutputChecker
            var mock = new Mock<ILogOutputChecker>();
            mock.Setup(m => m.IsOutput(It.IsAny<LogLevel>(), It.IsAny<string>())).Throws(_exception);
            var checkerMock = mock.Object;

            #endregion

            #region Settings

            // Initialize LoggingManager
            LoggingManager.Initialize(checker: checkerMock);

            // Make logger
            const string LOG_CATEGORY = "CheckerThrowsExceptionTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test using mock of ILogOutputChecker whose method named 'IsOutput' throws exception
            // Exception logs are output in console of Unity Editor and main execution doesn't stop
            const string Message = "Info";
            var expectedMessage = $"{nameof(Exception)}: {_exception.Message}";
            logger.Log(LogLevel.Info, Message);
            LogAssert.Expect(LogType.Exception, expectedMessage);
            Assert.IsFalse(logger.IsOutput(LogLevel.Info));
            LogAssert.Expect(LogType.Exception, expectedMessage);

            #region VerifyMock

            mock.Verify(m => m.IsOutput(It.IsAny<LogLevel>(), It.IsAny<string>()), Times.Exactly(2));

            #endregion
        }

        [Test]
        public void LogWriterThrowsException()
        {
            #region MakeMock

            // Make mock of ILogWriter
            var mock = new Mock<ILogWriter>();
            mock
                .Setup(m => m.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Exception>()))
                .Throws(_exception);
            var writerMock = mock.Object;

            #endregion

            #region Settings

            // Initialize LoggingManager
            LoggingManager.Initialize(writer: writerMock);

            // Make logger
            const string LOG_CATEGORY = "CheckerThrowsExceptionTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test using mock of ILogWriter whose method named 'Log' throws exception
            // Exception logs are output in console of Unity Editor and main execution doesn't stop
            const string Message = "Info";
            var expectedMessage = $"{nameof(Exception)}: {_exception.Message}";
            logger.Log(LogLevel.Info, Message);
            Debug.Log(expectedMessage);
            LogAssert.Expect(LogType.Exception, expectedMessage);

            #region VerifyMock

            mock.Verify(
                m => m.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Exception>()),
                Times.Once());

            #endregion
        }
    }
}
