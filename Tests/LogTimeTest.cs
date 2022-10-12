using System.Diagnostics;
using NUnit.Framework;

namespace Extreal.Core.Logging.Test
{
    public class LogTimeTest
    {
        private const string LOG_CATEGORY = "TIMETEST";

        [SetUp]
        public void Initialize()
        {
            LoggingManagerInitializer.Initialize();

            // Change LogLevel
            LoggingManager.SetLogLevel(LogLevel.DEBUG);
        }

        /// <summary>
        /// Test to see if 10,000 log outputs are executed within 7,500 milliseconds
        /// </summary>
        [Test]
        public void Test()
        {
            // Make logger
            var logger = LoggingManager.GetLogger(LOG_CATEGORY);

            // Start timer
            var timer = new Stopwatch();
            timer.Start();

            // Log 10,000 times
            for (var i = 0; i < 10_000; i++)
            {
                logger.LogDebug("TIMETEST");
            }

            // Stop timer
            timer.Stop();

            // Assert that execution time is within 7,500 milliseconds
            Assert.Less(timer.ElapsedMilliseconds, 7_500);
        }
    }
}
