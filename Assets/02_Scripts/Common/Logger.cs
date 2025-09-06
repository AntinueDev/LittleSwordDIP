using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace LittleSword.Common
{
    public static class Logger
    {
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOP_MODE")]
        public static void Log(object message)
        {
            Debug.Log(message);
        }
        
        [Conditional("DEVELOP_MODE")]
        public static void LogWaring(object message)
        {
            Debug.LogWarning(message);
        }
        
        [Conditional("DEVELOP_MODE")]
        public static void LogError(object message)
        {
            Debug.LogError(message);
        }
    }
}