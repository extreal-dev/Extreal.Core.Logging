namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class used by default to check if logs should be output.
    /// </summary>
    public class LogLevelLogOutputChecker : ILogOutputChecker
    {
        private LogLevel _logLevel;

        /// <summary>
        /// Initializes LogOutputChecker.
        /// </summary>
        /// <param name="logLevel">LogLevel to be set.</param>
        public void Initialize(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        /// <summary>
        /// Checks if logs should be output.
        /// </summary>
        /// <param name="logLevel">LogLevel used to check.</param>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if logs should be output, false otherwise.</returns>
        public bool IsOutput(LogLevel logLevel, string logCategory)
        {
            return _logLevel <= logLevel;
        }
    }
}
