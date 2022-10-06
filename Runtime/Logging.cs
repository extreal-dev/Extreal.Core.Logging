using UnityEngine;

namespace Extreal.Core.Logging
{
    public class Logging : ILoggable
    {
        public static Logging Instance => s_instance;
        private static Logging s_instance = new Logging();

        private LogConfig _logConfig;

        public void SetLogConfig(LogConfig logConfig)
        {
            _logConfig = logConfig;
        }

        public void PrintDebug(string message)
        {
            if (_logConfig._useLogLevels.Contains(LogLevel.Debug))
            {
                Debug.Log($"[{LogLevel.Debug}] {message}");
            }
        }

        public void PrintInfo(string message)
        {
            if (_logConfig._useLogLevels.Contains(LogLevel.Info))
            {
                Debug.Log($"[{LogLevel.Info}] {message}");
            }
        }

        public void PrintWarn(string message)
        {
            if (_logConfig._useLogLevels.Contains(LogLevel.Warn))
            {
                Debug.Log($"[{LogLevel.Warn}] {message}");
            }
        }

        public void PrintError(string message)
        {
            if (_logConfig._useLogLevels.Contains(LogLevel.Error))
            {
                Debug.Log($"[{LogLevel.Error}] {message}");
            }
        }
    }
}
