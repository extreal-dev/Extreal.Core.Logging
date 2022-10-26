namespace Extreal.Core.Logging.Test
{
    using System.Diagnostics;
    using NUnit.Framework;

    public class LogOutputCheckerTest
    {
        [SetUp]
        public void Initialize()
            => LoggingManager.Initialize(writer: new UnityDebugLogWriter(), checker: new LogLevelLogOutputChecker());

        [Test]
        public void OutputCheck10kTimesWithin10Milliseconds()
        {
            #region Settings

            // Change LogLevel
            const string logCategory = "TimeTest";
            LoggingManager.Initialize(LogLevel.Debug);

            // Make logger
            var logger = LoggingManager.GetLogger(logCategory);

            #endregion

            // Start timer
            var timer = new Stopwatch();
            timer.Start();

            // Log 10,000 times
            for (var i = 0; i < 10_000; i++)
            {
                _ = logger.IsDebug();
            }

            // Stop timer
            timer.Stop();

            // Assert that execution time is within 10 milliseconds
            Assert.Less(timer.ElapsedMilliseconds, 10);
        }
    }
}
