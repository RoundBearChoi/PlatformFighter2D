using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIMessage : IMessage
    {
        public static UI ui = null;
        
        private string _message = string.Empty;

        public UIMessage(string message)
        {
            _message = message;
        }

        public void Register()
        {
            ui.AddMessage(this);
        }

        public string GetStringMessage()
        {
            return _message;
        }
    }
}