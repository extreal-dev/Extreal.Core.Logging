using System;
using NUnit.Framework;

namespace Extreal.Core.Logging.Test
{
    public class UnityDebugLogWriterTest
    {
        private Exception _exception = new Exception();

        [SetUp]
        public void Initialize()
        {
            LoggingManager.Initialize(writer: new UnityDebugLogWriter(), checker: new LogLevelLogOutputChecker());
        }

        [Test]
        public void LogLevelIsUndefined()
        {
            // Make writer
            var writer = new UnityDebugLogWriter();

            // Test to log with undefined LogLevel
            // Exception is thrown
            const string LOG_CATEGORY = "LogLevelUndefinedTest";
            const string Message = "Fatal";
            var undefinedLogLevel = Enum.Parse<LogLevel>("4");
            var expectedMessage = $"{nameof(Exception)}: Undefined LogLevel was input";
            Assert.Throws<Exception>(() => writer.Log(undefinedLogLevel, LOG_CATEGORY, Message));
        }
    }
}
