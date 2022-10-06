using System.Collections.Generic;
using UnityEngine;

namespace Extreal.Core.Logging
{
    [CreateAssetMenu(fileName = nameof(LogConfig), menuName = "Extreal/Core/Logging/" + nameof(LogConfig), order = 0)]
    public class LogConfig : ScriptableObject
    {
        public List<LogLevel> _useLogLevels;
    }
}
