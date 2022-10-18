namespace Extreal.Core.Logging
{
    /// <summary>
    /// Interface for implementation checking if logs should be output according to LogLevel and log category.
    /// </summary>
    public interface ILogOutputChecker
    {
        /// <summary>
        /// Initializes LogOutputChecker according to LogLevel.
        /// </summary>
        /// <param name="logLevel">LogLevel used to initialize.</param>
        void Initialize(LogLevel logLevel);

        /// <summary>
        /// Checks if debug logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log debug, false otherwise.</returns>
        bool IsDebug(string logCategory);

        /// <summary>
        /// Checks if infomation logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log infomation, false otherwise.</returns>
        bool IsInfo(string logCategory);

        /// <summary>
        /// Checks if warning logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log warning, false otherwise.</returns>
        bool IsWarn(string logCategory);

        /// <summary>
        /// Checks if error logs are output.
        /// </summary>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if it is set to log error, false otherwise.</returns>
        bool IsError(string logCategory);
    }
}
