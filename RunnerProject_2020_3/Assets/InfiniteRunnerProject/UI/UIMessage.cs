using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIMessage : BaseMessage
    {
        public static UI ui = null;
        
        private string _message = string.Empty;

        public UIMessage(string message)
        {
            _message = message;
        }

        public override void Register()
        {
            ui.AddMessage(this);
        }

        public override string GetStringMessage()
        {
            return _message;
        }
    }
}