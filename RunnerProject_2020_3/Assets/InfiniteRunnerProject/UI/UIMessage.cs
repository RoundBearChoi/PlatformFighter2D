using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIMessage : BaseMessage
    {
        public static UI ui = null;

        public UIMessage(MessageType messageType)
        {
            mMessageType = messageType;
        }

        public override void Register()
        {
            ui.AddMessage(this);
        }
    }
}