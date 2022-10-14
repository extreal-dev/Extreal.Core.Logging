using System.Diagnostics;
using NUnit.Framework;

namespace Extreal.Core.Logging.Test
{
    public class LogOutputChekerTest
    {
        [Test]
        public void OutputCheck10kTimesWithin15Millisec()
        {
            #region Settings

            // Change LogLevel
            const string LOG_CATEGORY = "TIMETEST";
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
                logger.IsDebug();
            }

            // Stop timer
            timer.Stop();

            // Assert that execution time is within 15 milliseconds
            Assert.Less(timer.ElapsedMilliseconds, 15);
        }
    }
}
