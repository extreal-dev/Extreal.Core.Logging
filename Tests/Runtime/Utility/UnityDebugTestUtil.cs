namespace Extreal.Core.Logging.Test
{
    using UnityEngine;

    public static class UnityDebugTestUtil
    {
        public static string LogText { get; private set; }

        public static void StartLogReceive()
        {
            Application.logMessageReceived += OnLogMessageReceived;
            LogText = string.Empty;
        }

        public static void StopLogReceive()
            => Application.logMessageReceived -= OnLogMessageReceived;

        public static void ClearLogText()
            => LogText = string.Empty;

        private static void OnLogMessageReceived(string logText, string stackTrace, LogType logType)
            => LogText = logText;
    }
}
