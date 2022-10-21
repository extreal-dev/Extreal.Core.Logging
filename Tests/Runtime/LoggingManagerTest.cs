﻿using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Extreal.Core.Logging.Test.Utility;

namespace Extreal.Core.Logging.Test
{
    public class LoggingManagerTest
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
        public void DefaultLogger()
        {
            #region Setting

            // Initialize LoggingManager
            LoggingManager.Initialize();

            // Make logger
            const string LOG_CATEGORY = "DefaultTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            Assert.IsFalse(logger.IsDebug());

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsInfo());

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsWarn());

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsError());
        }

        [Test]
        public void ChangeLogLevel2Debug()
        {
            #region Settings

            // Set log level to DEBUG
            LoggingManager.Initialize(LogLevel.Debug);

            // Make logger
            const string LOG_CATEGORY = "DebugTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{LOG_CATEGORY}] {message}");
            logger.LogDebug(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void ChangeLogLevel2Info()
        {
            #region Settings

            // Set log level to INFO
            LoggingManager.Initialize(LogLevel.Info);

            // Make logger
            const string LOG_CATEGORY = "InfoTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void ChangeLogLevel2Warn()
        {
            #region Settings

            // Set log level to WARN
            LoggingManager.Initialize(LogLevel.Warn);

            // Make logger
            const string LOG_CATEGORY = "WarnTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogInfo(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void ChangeLogLevel2Error()
        {
            #region Settings

            // Set log level to ERROR
            LoggingManager.Initialize(LogLevel.Error);

            // Make logger
            const string LOG_CATEGORY = "ErrorTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogInfo(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogWarn(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void ChangeLogOutputChecker()
        {
            #region Settings

            // Change LogOutputChecker
            LoggingManager.Initialize(checker: new AppLogOutputChecker());

            // Make logger
            const string LOG_CATEGORY = "Debugger";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{LOG_CATEGORY}] {message}");
            logger.LogDebug(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Debug}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsDebug());

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsInfo());

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsWarn());

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
            Assert.IsTrue(logger.IsError());
        }

        [Test]
        public void ChangeLogWriter()
        {
            #region Settings

            // Change LogWriter
            LoggingManager.Initialize(writer: new AppLogWriter());

            // Make logger
            const string LOG_CATEGORY = "ChangeWriterTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"(^_^) {LOG_CATEGORY}: {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect
            (
                LogType.Log,
                $"(^_^) {LOG_CATEGORY}: {message}"
                    + "\n---- Exception ----\n"
                    + _exception
                    + "\n-------------------\n"
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
                    + "\n---- Exception ----\n"
                    + _exception
                    + "\n-------------------\n"
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
                    + "\n---- Exception ----\n"
                    + _exception
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
            const string LOG_CATEGORY = "SameCategoryTest";
            var loggerA = LoggingManager.GetLogger(LOG_CATEGORY);
            var loggerB = LoggingManager.GetLogger(LOG_CATEGORY);

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
            const string LOG_CATEGORY = "CheckerNullTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void LogWriterIsNull()
        {
            #region settings

            // Set checker null
            LoggingManager.Initialize(writer: null);

            // Make logger
            // Logger behaves the same as default logger
            const string LOG_CATEGORY = "WriterNullTest";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Test to print debug
            var message = "Debug";
            logger.LogDebug(message);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);
            logger.LogDebug(message, _exception);
            Assert.IsEmpty(UnityDebugTestUtil.LogText);

            // Test to print info
            message = "Info";
            logger.LogInfo(message);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}");
            logger.LogInfo(message, _exception);
            LogAssert.Expect(LogType.Log, $"[{LogLevel.Info}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print warn
            message = "Warn";
            logger.LogWarn(message);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}");
            logger.LogWarn(message, _exception);
            LogAssert.Expect(LogType.Warning, $"[{LogLevel.Warn}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");

            // Test to print error
            message = "Error";
            logger.LogError(message);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}");
            logger.LogError(message, _exception);
            LogAssert.Expect(LogType.Error, $"[{LogLevel.Error}:{LOG_CATEGORY}] {message}\n----------\n{_exception}");
        }

        [Test]
        public void LogCategoryIsNull()
        {
            // Making logger throws ArgumentNullException exception
            const string LOG_CATEGORY = null;
            Assert.Throws<ArgumentNullException>(() => LoggingManager.GetLogger(LOG_CATEGORY));
        }
    }
}
