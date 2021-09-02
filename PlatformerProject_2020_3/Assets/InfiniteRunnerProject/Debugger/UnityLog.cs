using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnityLog : ILogger
    {
        public void Log(object message)
        {
            Debug.Log(message);
        }
    }
}