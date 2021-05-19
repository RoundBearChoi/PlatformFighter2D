using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class Debugger
    {
        static ILogger logger = new UnityLog();

        public static void Log(object message)
        {
            logger.Log(message);
        }
    }
}