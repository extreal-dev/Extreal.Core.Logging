namespace Extreal.Core.Logging
{
    /// <summary>
    /// Class used by default to check if logs should be output.
    /// </summary>
    public class LogLevelLogOutputChecker : ILogOutputChecker
    {
        private bool _isDebug = false;
        private bool _isInfo = true;
        private bool _isWarn = true;
        private bool _isError = true;

        /// <summary>
        /// Initializes LogOutputChecker according to LogLevel.
        /// </summary>
        /// <param name="logLevel">LogLevel used to initialize.</param>
        public void Initialize(LogLevel logLevel)
        {
            _isDebug = logLevel <= LogLevel.Debug;
            _isInfo = logLevel <= LogLevel.Info;
            _isWarn = logLevel <= LogLevel.Warn;
            _isError = logLevel <= LogLevel.Error;
        }

        /// <summary>
        /// Checks if debug logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log debug, false otherwise.</returns>
        public bool IsDebug(string logCategory)
        {
            return _isDebug;
        }

        /// <summary>
        /// Checks if information logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log information, false otherwise.</returns>
        public bool IsInfo(string logCategory)
        {
            return _isInfo;
        }

        /// <summary>
        /// Checks if warning logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log warning, false otherwise.</returns>
        public bool IsWarn(string logCategory)
        {
            return _isWarn;
        }

        /// <summary>
        /// Checks if error logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log error, false otherwise.</returns>
        public bool IsError(string logCategory)
        {
            return _isError;
        }
    }
}
