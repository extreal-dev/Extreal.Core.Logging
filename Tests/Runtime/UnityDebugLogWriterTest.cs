using System;
using NUnit.Framework;

namespace Extreal.Core.Logging.Test
{
    public class UnityDebugLogWriterTest
    {
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
            Assert.That(() => writer.Log(undefinedLogLevel, logCategory, message),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .With.Message.Contains($"Undefined LogLevel was input"));
        }
    }
}
