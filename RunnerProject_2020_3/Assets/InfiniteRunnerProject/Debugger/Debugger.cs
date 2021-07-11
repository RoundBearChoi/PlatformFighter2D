using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class Debugger
    {
        public static bool useLog = true;
        static ILogger logger = new UnityLog();

        public static void Log(object message)
        {
            if (useLog)
            {
                logger.Log(message);
            }
        }
    }
}