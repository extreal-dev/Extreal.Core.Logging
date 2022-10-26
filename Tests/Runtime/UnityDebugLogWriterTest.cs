using System;
using NUnit.Framework;

namespace Extreal.Core.Logging.Test
{
    public class UnityDebugLogWriterTest
    {
        private readonly Exception exception = new Exception();

        [SetUp]
        public void Initialize()
            => LoggingManager.Initialize(writer: new UnityDebugLogWriter(), checker: new LogLevelLogOutputChecker());

        [Test]
        public void LogLevelIsUndefined()
        {
            // Make writer
            var writer = new UnityDebugLogWriter();

            // Test to log with undefined LogLevel
            const string logCategory = "LogLevelUndefinedTest";
            const string message = "Fatal";
            var undefinedLogLevel = Enum.Parse<LogLevel>("4");
            var expectedMessage = $"{nameof(Exception)}: Undefined LogLevel was input";
            _ = Assert.Throws<ArgumentOutOfRangeException>(() => writer.Log(undefinedLogLevel, logCategory, message));
        }
    }
}
