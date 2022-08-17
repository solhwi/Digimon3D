using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if UNITY_EDITOR
using UnityEngine;
#endif

namespace ServerLib
{
    public enum LogLevel
    {
        Temp,
        Warning,
        Error
    }

    public class AdamLogger
    {
        static Dictionary<LogLevel, ConsoleColor> LogLevelConsoleColorMap = new Dictionary<LogLevel, ConsoleColor>()
        {
            { LogLevel.Temp, ConsoleColor.White },
            { LogLevel.Warning, ConsoleColor.DarkGreen },
            { LogLevel.Error, ConsoleColor.Red },
        };

        public static void Log(LogLevel Level, string LogString)
        {
#if UNITY_EDITOR
            Debug.Log($"[Logger] [{DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()}] {Level.ToString()} {LogString}");
#else
            Console.ForegroundColor = LogLevelConsoleColorMap[Level];
            Console.WriteLine($"[Logger] [{DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()}] {Level.ToString()} {LogString}");
            Console.ForegroundColor = ConsoleColor.White;
#endif
        }
    }
}
