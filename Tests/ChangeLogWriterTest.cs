using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Extreal.Core.Logging.Test
{
    public class ChangeLogWriterTest
    {
        private const string LOG_CATEGORY = "WRITERTEST";
        private Exception _exception = new Exception();

        [SetUp]
        public void Initialize()
        {
            LoggingManagerInitializer.Initialize();
            LogGetter.Initialize();

            // Change LogWriter
            LoggingManager.SetLogWriter(new TestLogWriter());
        }

        [TearDown]
        public void Dispose()
        {
            LogGetter.Dispose();
        }

        /// <summary>
        /// Test to see if LogWriter can be changed
        /// </summary>
        [Test, Order(default)]
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

        // Customized LogWriter class
        private class TestLogWriter : ILogWriter
        {
            public void LogDebug(string logCategory, string message)
            {
                Debug.Log($"(o-o) {logCategory}: {message}");
            }

            public void LogDebug(string logCategory, string message, Exception exception)
            {
                Debug.Log
                (
                    $"(o-o) {logCategory}: {message}"
                    + "---- Exception ----"
                    + exception
                    + "-------------------"
                );
            }

            public void LogInfo(string logCategory, string message)
            {
                Debug.Log($"(^_^) {logCategory}: {message}");
            }

            public void LogInfo(string logCategory, string message, Exception exception)
            {
                Debug.Log
                (
                    $"(^_^) {logCategory}: {message}"
                    + "---- Exception ----"
                    + exception
                    + "-------------------"
                );
            }

            public void LogWarn(string logCategory, string message)
            {
                Debug.LogWarning($"(--; {logCategory}: {message}");
            }

            public void LogWarn(string logCategory, string message, Exception exception)
            {
                Debug.LogWarning
                (
                    $"(--; {logCategory}: {message}"
                    + "---- Exception ----"
                    + exception
                    + "-------------------"
                );
            }

            public void LogError(string logCategory, string message)
            {
                Debug.LogError($"(*A*; {logCategory}: {message}");
            }

            public void LogError(string logCategory, string message, Exception exception)
            {
                Debug.LogError
                (
                    $"(*A*; {logCategory}: {message}"
                    + "---- Exception ----"
                    + exception
                    + "-------------------"
                );
            }
        }
    }
}
