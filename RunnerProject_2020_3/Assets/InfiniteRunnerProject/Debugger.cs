using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Messages
    {
        public virtual void Say(string str)
        {

        }
    }

    public class ConsoleMessage : Messages
    {
        object somereceiver;

        public ConsoleMessage(object rec)
        {
            somereceiver = rec;
        }

        public override void Say(string str)
        {
            //send message to somereceiver;
        }
    }

    public class SHOWUI : Messages
    {
        public override void Say(string str)
        {

        }
    }

    public static class Debugger
    {
        public const bool debug = true;

        public static void Log(object message)
        {
            if (debug)
            {
                UnityEngine.Debug.Log(message);
            }
        }
    }
}