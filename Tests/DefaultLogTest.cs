using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Extreal.Core.Logging.Test
{
    public class DefaultLogTest
    {
        private const string LOG_CATEGORY = "Default";
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
        /// Test to see if defaults are correct
        /// </summary>
        [Test]
        public void Test()
        {
            // Make logger
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
    }
}
