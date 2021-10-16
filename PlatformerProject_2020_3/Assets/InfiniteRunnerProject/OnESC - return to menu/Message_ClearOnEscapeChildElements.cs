using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ClearOnEscapeChildElements : BaseMessage
    {
        public static BaseMessageHandler onESCMessageHandler = null;

        public Message_ClearOnEscapeChildElements()
        {
            mMessageType = MessageType.CLEAR_ONESCAPE_CHILD_ELEMENTS;
        }

        public override void Register()
        {
            if (onESCMessageHandler != null)
            {
                onESCMessageHandler.Register(this);
            }
        }
    }
}