using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Extreal.Core.Logging.Test
{
    public class LoggingManagerTest
    {
        private Exception exception = new Exception();

        [SetUp]
        public void Initialize()
        {
            UnityDebugTestUtil.StartLogReceive();
            LoggingManager.Initialize(writer: new UnityDebugLogWriter(), checker: new LogLevelLogOutputChecker());
        }

        [TearDown]
        public void Dispose()
            => UnityDebugTestUtil.StopLogReceive();

        [Test]
        public void DefaultLogger()
        {
            #region Setting

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string logCategory = "DefaultTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            Assert.IsFalse(logger.IsDebug());

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsInfo());

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsWarn());

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsError());
        }

        [Test]
        public void ChangeLogLevel2Debug()
        {
            #region Settings

            // Set log level to DEBUG
            LoggingManager.Initialize(LogLevel.Debug);

            // Make logger
            const string logCategory = "DebugTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{logCategory}] {message}");
            logger.LogDebug(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
        }

        [Test]
        public void ChangeLogLevel2Info()
        {
            #region Settings

            // Set log level to INFO
            LoggingManager.Initialize(LogLevel.Info);

            // Make logger
            const string logCategory = "InfoTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
        }

        [Test]
        public void ChangeLogLevel2Warn()
        {
            #region Settings

            // Set log level to WARN
            LoggingManager.Initialize(LogLevel.Warn);

            // Make logger
            const string logCategory = "WarnTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogInfo(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
        }

        [Test]
        public void ChangeLogLevel2Error()
        {
            #region Settings

            // Set log level to ERROR
            LoggingManager.Initialize(LogLevel.Error);

            // Make logger
            const string logCategory = "ErrorTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogInfo(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogWarn(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
        }

        [Test]
        public void ChangeLogOutputChecker()
        {
            #region Settings

            // Change LogOutputChecker
            LoggingManager.Initialize(checker: new AppLogOutputChecker());

            // Make logger
            const string logCategory = "Debugger";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{logCategory}] {message}");
            logger.LogDebug(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsDebug());

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsInfo());

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsWarn());

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
            Assert.IsTrue(logger.IsError());
        }

        [Test]
        public void ChangeLogWriter()
        {
            #region Settings

            // Change LogWriter
            LoggingManager.Initialize(writer: new AppLogWriter());

            // Make logger
            const string logCategory = "ChangeWriterTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"(^_^) {logCategory}: {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect
            (
                LogType.Log,
                $"(^_^) {logCategory}: {message}"
                    + "\n---- Exception ----\n"
                    + exception
                    + "\n-------------------\n"
            );

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"(--; {logCategory}: {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect
            (
                LogType.Warning,
                $"(--; {logCategory}: {message}"
                    + "\n---- Exception ----\n"
                    + exception
                    + "\n-------------------\n"
            );

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"(*A*; {logCategory}: {message}");
            logger.LogError(message, exception);
            LogAssert.Expect
            (
                LogType.Error,
                $"(*A*; {logCategory}: {message}"
                    + "\n---- Exception ----\n"
                    + exception
                    + "\n-------------------\n"
            );
        }

        [Test]
        public void SameCategoryLoggerIsSame()
        {
            #region Setting

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string logCategory = "SameCategoryTest";
            var loggerA = LoggingManager.GetLogger(logCategory);
            var loggerB = LoggingManager.GetLogger(logCategory);

            #endregion

            Assert.AreSame(loggerA, loggerB);
        }

        [Test]
        public void LogOutputCheckerIsNull()
        {
            #region settings

            // Set checker null
            LoggingManager.Initialize(checker: null);

            // Make logger
            // Logger behaves the same as default logger
            const string logCategory = "CheckerNullTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
        }

        [Test]
        public void LogWriterIsNull()
        {
            #region settings

            // Set checker null
            LoggingManager.Initialize(writer: null);

            // Make logger
            // Logger behaves the same as default logger
            const string logCategory = "WriterNullTest";
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}");
            logger.LogInfo(message, exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}");
            logger.LogWarn(message, exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{logCategory}] {message}\n----------\n{exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}");
            logger.LogError(message, exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{logCategory}] {message}\n----------\n{exception}");
        }

        [Test]
        public void LogCategoryIsNull()
        {
            // Making logger throws ArgumentNullException exception
            const string logCategory = null;
            _ = Assert.Throws<ArgumentNullException>(() => LoggingManager.GetLogger(logCategory));
        }
    }
}
