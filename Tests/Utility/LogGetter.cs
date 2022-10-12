using UnityEngine;

namespace Extreal.Core.Logging.Test
{
    public static class LogGetter
    {
        public static string LogText { get; private set; }

        public static void Initialize()
        {
            Application.logMessageReceived += OnLogMessageReceived;
            LogText = "";
        }

        public static void Dispose()
        {
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        public static void LogTextClear()
        {
            LogText = "";
        }

        private static void OnLogMessageReceived(string logText, string stackTrace, LogType logType)
        {
            LogText = logText;
        }
    }
}
