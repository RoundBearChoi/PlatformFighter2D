using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIMessage : BaseMessage
    {
        public UIMessage(MessageType messageType)
        {
            mMessageType = messageType;
        }

        public override void Register()
        {
            UITest.tempUI.currentUI.listMessages.Add(this);
        }
    }
}