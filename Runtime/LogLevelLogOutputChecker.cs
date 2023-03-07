using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class used by default to check if logs should be output.
    /// </summary>
    public class LogLevelLogOutputChecker : ILogOutputChecker
    {
        private LogLevel logLevel = LogLevel.Info;
        private readonly ICollection<string> categories;

        /// <summary>
        /// Creates LogLevelLogOutputChecker.
        /// </summary>
        /// <param name="categories">Category to output logs.</param>
        [SuppressMessage("Usage", "CC0057")]
        public LogLevelLogOutputChecker(ICollection<string> categories = null)
        {
            if (categories != null && categories.Count != 0)
            {
                this.categories = new HashSet<string>(categories);
            }
        }

        /// <summary>
        /// Initializes LogLevelLogOutputChecker.
        /// </summary>
        /// <param name="logLevel">LogLevel to be set.</param>
        public void Initialize(LogLevel logLevel)
            => this.logLevel = logLevel;

        /// <summary>
        /// Checks if logs should be output.
        /// </summary>
        /// <param name="logLevel">LogLevel used to check.</param>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if logs should be output, false otherwise.</returns>
        public bool IsOutput(LogLevel logLevel, string logCategory)
            => this.logLevel <= logLevel && (categories?.Contains(logCategory) ?? true);
    }
}
