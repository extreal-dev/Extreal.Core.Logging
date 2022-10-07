namespace Extreal.Core.Logging
{
    public interface ILogOutputChecker
    {
        bool IsDebug(Logger logger);
        bool IsInfo(Logger logger);
        bool IsWarn(Logger logger);
        bool IsError(Logger logger);
    }
}
