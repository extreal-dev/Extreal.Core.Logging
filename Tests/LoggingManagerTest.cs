using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Extreal.Core.Logging.Test
{
    public class LoggingManagerTest
    {
        private Exception _exception = new Exception();

        [SetUp]
        public void Initialize()
        {
            LoggingManagerInitializer.Initialize();
            LogGetter.Initialize();
        }

        [TearDown]
        public void Dispose()
        {
            LogGetter.Dispose();
        }

        [Test]
        public void DefaultLogger()
        {
            #region Setting

            // Make logger
            const string LOG_CATEGORY = "DEFAULTTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);
            Assert.IsFalse(logger.IsDebug());

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.INFO}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsInfo());

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.WARN}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsWarn());

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsError());
        }

        [Test]
        public void ChangeLogLevel2Debug()
        {
            #region Settings

            // Set log level to DEBUG
            LoggingManager.SetLogLevel(LogLevel.DEBUG);

            // Make logger
            const string LOG_CATEGORY = "DEBUGTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

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

        [Test]
        public void ChangeLogLevel2Info()
        {
            #region Settings

            // Set log level to INFO
            LoggingManager.SetLogLevel(LogLevel.INFO);

            // Make logger
            const string LOG_CATEGORY = "INFOTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

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

        [Test]
        public void ChangeLogLevel2Warn()
        {
            #region Settings

            // Set log level to WARN
            LoggingManager.SetLogLevel(LogLevel.WARN);

            // Make logger
            const string LOG_CATEGORY = "WARNTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogInfo(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

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

        [Test]
        public void ChangeLogLevel2Error()
        {
            #region Settings

            // Set log level to ERROR
            LoggingManager.SetLogLevel(LogLevel.ERROR);

            // Make logger
            const string LOG_CATEGORY = "ERRORTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogInfo(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogWarn(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.ERROR}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void ChangeLogOutputChecker()
        {
            #region Settings

            // Change LogOutputChecker
            LoggingManager.SetLogOutputChecker(new AppLogOutputChecker());

            // Make logger
            const string LOG_CATEGORY = "Debugger";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

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

        [Test]
        public void ChangeLogWriter()
        {
            #region Settings

            // Change LogWriter
            LoggingManager.SetLogWriter(new AppLogWriter());

            // Make logger
            const string LOG_CATEGORY = "WRITERTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(LogGetter.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(LogGetter.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"(^_^) {LOG_CATEGORY}: {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect
            (
                LogType.Log,
                $"(^_^) {LOG_CATEGORY}: {message}"
                    + "---- Exception ----"
                    + _exception
                    + "-------------------"
            );

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"(--; {LOG_CATEGORY}: {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect
            (
                LogType.Warning,
                $"(--; {LOG_CATEGORY}: {message}"
                    + "---- Exception ----"
                    + _exception
                    + "-------------------"
            );

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"(*A*; {LOG_CATEGORY}: {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect
            (
                LogType.Error,
                $"(*A*; {LOG_CATEGORY}: {message}"
                    + "---- Exception ----"
                    + _exception
                    + "-------------------"
            );
        }

        [Test]
        public void SameCategoryLoggerIsSame()
        {
            #region Setting

            // Make logger
            const string LOG_CATEGORY = "SAMECATEGORYTEST";
            var loggerA = LoggingManager.GetLogger(LOG_CATEGORY);
            var loggerB = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            Assert.AreSame(loggerA, loggerB);
        }
    }
}
