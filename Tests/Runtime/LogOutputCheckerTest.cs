using System.Diagnostics;
using NUnit.Framework;

namespace Extreal.Core.Logging.Test
{
    public class LogOutputCheckerTest
    {
        [Test]
        public void OutputCheck10kTimesWithin10Milliseconds()
        {
            #region Settings

            // Change LogLevel
            const string LOG_CATEGORY = "TimeTest";
            LoggingManager.Initialize(LogLevel.Debug);

            // Make logger
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            #endregion

            // Start timer
            var timer = new Stopwatch();
            timer.Start();

            // Log 10,000 times
            for (var i = 0; i < 10_000; i++)
            {
                logger.IsOutput(LogLevel.Debug);
            }

            // Stop timer
            timer.Stop();

            // Assert that execution time is within 10 milliseconds
            Assert.Less(timer.ElapsedMilliseconds, 10);
        }
    }
}
