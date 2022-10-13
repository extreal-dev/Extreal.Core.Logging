namespace Extreal.Core.Logging
{
    public interface ILogOutputChecker
    {
        ILogOutputChecker Clone();
        void SetLogLevel(LogLevel logLevel);
        bool IsDebug(string logCategory);
        bool IsInfo(string logCategory);
        bool IsWarn(string logCategory);
        bool IsError(string logCategory);
    }
}
