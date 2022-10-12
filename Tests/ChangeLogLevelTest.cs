using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Extreal.Core.Logging.Test
{
    public class ChangeLogLevelTest
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

        /// <summary>
        /// Test where LogLevel is DEBUG
        /// </summary>
        [Test]
        public void DebugTest()
        {
            // Set log level to DEBUG
            LoggingManager.SetLogLevel(LogLevel.DEBUG);

            // Make logger
            const string LOG_CATEGORY = "DEBUGTEST";
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

        /// <summary>
        /// Test where LogLevel is INFO
        /// </summary>
        [Test]
        public void InfoTest()
        {
            // Set log level to INFO
            LoggingManager.SetLogLevel(LogLevel.INFO);

            // Make logger
            const string LOG_CATEGORY = "INFOTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

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

        /// <summary>
        /// Test where LogLevel is WARN
        /// </summary>
        [Test]
        public void WarnTest()
        {
            // Set log level to WARN
            LoggingManager.SetLogLevel(LogLevel.WARN);

            // Make logger
            const string LOG_CATEGORY = "WARNTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

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

        /// <summary>
        /// Test where LogLevel is ERROR
        /// </summary>
        [Test]
        public void ErrorTest()
        {
            // Set log level to ERROR
            LoggingManager.SetLogLevel(LogLevel.ERROR);

            // Make logger
            const string LOG_CATEGORY = "ERRORTEST";
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

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
    }
}
