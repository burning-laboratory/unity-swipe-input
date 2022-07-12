using UnityEngine;

namespace BurningLab.SwipeDetector.Utils
{
    /// <summary>
    /// Unity console tool.
    /// </summary>
    public static class UnityConsole
    {
        /// <summary>
        /// Draw log record to console.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="message">Message</param>
        public static void PrintLog(string className, string methodName, string message)
        {
#if UNITY_EDITOR
            Debug.Log($"{{<b><color=white>Burning-</color><color=lime>Lab</color></b>}} => [{className}] - (<color=yellow>{methodName}</color>) -> {message}");
#else
            Debug.Log($"{{Burning-Lab}} => [{className}] - ({methodName}) -> {message}");
#endif
        }
        
        /// <summary>
        /// Draw log record to console.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="message">Message</param>
        /// <param name="context">GameObject context.</param>
        public static void PrintLog(string className, string methodName, string message, GameObject context)
        {
#if UNITY_EDITOR
            Debug.Log($"{{<b><color=white>Burning-</color><color=lime>Lab</color></b>}} => [{className}] - (<color=yellow>{methodName}</color>) -> {message}", context);
#else
            Debug.Log($"{{Burning-Lab}} => [{className}] - ({methodName}) -> {message}");
#endif
        }
        
        /// <summary>
        /// Print log to console.
        /// </summary>
        /// <param name="moduleName">Application module name</param>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="message">Message to console</param>
        public static void PrintLog(string moduleName,string className, string methodName, string message)
        {
#if UNITY_EDITOR
            Debug.Log($"{{<b><color=white>{moduleName}</color></b>}} => [{className}] - (<color=yellow>{methodName}</color>) -> {message}");
#else
            Debug.Log($"{moduleName} => [{className}] - ({methodName}) -> {message}");
#endif
        }
        
        /// <summary>
        /// Print log to console.
        /// </summary>
        /// <param name="moduleName">Application module name</param>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="message">Message to console</param>
        /// <param name="context">Game object context</param>
        public static void PrintLog(string moduleName,string className, string methodName, string message, GameObject context)
        {
#if UNITY_EDITOR
            Debug.Log($"{{<b><color=white>{moduleName}</color></b>}} => [{className}] - (<color=yellow>{methodName}</color>) -> {message}", context);
#else
            Debug.Log($"{moduleName} => [{className}] - ({methodName}) -> {message}");
#endif
        }
    }
}