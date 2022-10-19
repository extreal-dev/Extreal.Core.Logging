namespace Extreal.Core.Logging
{
    /// <summary>
    /// <para>Interface for implementation checking if logs should be output according to LogLevel and log category.</para>
    /// Implementation of this should not throw exceptions to avoid stopping main execution.
    /// </summary>
    public interface ILogOutputChecker
    {
        /// <summary>
        /// Initializes LogOutputChecker.
        /// </summary>
        /// <param name="logLevel">LogLevel to be set.</param>
        void Initialize(LogLevel logLevel);

        /// <summary>
        /// Checks if logs should be output.
        /// </summary>
        /// <param name="logLevel">LogLevel used to check.</param>
        /// <param name="logCategory">Log category used to check.</param>
        /// <returns>True if logs should be output, false otherwise.</returns>
        bool IsOutput(LogLevel logLevel, string logCategory);
    }
}
