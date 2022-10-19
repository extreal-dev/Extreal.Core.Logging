using UnityEngine;

namespace Extreal.Core.Logging.Test
{
    public static class UnityDebugTestUtil
    {
        public static string LogText { get; private set; }

        public static void StartLogReceive()
        {
            Application.logMessageReceived += OnLogMessageReceived;
            LogText = "";
        }

        public static void StopLogReceive()
        {
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        public static void ClearLogText()
        {
            LogText = "";
        }

        private static void OnLogMessageReceived(string logText, string stackTrace, LogType logType)
        {
            LogText = logText;
        }
    }
}
