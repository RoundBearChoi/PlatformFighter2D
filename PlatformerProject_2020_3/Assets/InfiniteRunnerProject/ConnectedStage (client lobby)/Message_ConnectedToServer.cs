using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class Message_ConnectedToServer : BaseMessage
    {
        public static BaseMessageHandler stageTransitionerMessageHandler = null;

        public Message_ConnectedToServer()
        {
            mMessageType = MessageType.TRANSITION_TO_CONNECTED_STAGE;
        }

        public override void Register()
        {
            if (stageTransitionerMessageHandler != null)
            {
                stageTransitionerMessageHandler.Register(this);
            }
        }
    }
}