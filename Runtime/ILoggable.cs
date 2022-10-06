namespace Extreal.Core.Logging
{
    public interface ILoggable
    {
        void SetLogConfig(LogConfig logConfig);
        void PrintDebug(string message);
        void PrintInfo(string message);
        void PrintWarn(string message);
        void PrintError(string message);
    }
}
