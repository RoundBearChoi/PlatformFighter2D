using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIMessage : IMessage
    {
        public static UI ui = null;
        public string message = string.Empty;

        public UIMessage(string str)
        {
            message = str;
        }

        public void Register()
        {
            ui.AddMessage(this);
        }
    }
}