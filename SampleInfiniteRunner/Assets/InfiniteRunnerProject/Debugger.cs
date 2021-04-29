using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class Debugger
    {
        public const bool debug = true;

        public static void Log(object message)
        {
            if (debug)
            {
                Debug.Log(message);
            }
        }
    }
}