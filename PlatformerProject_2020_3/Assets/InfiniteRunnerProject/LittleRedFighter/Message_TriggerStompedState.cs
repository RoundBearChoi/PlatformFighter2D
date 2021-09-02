using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_TriggerStompedState : BaseMessage
    {
        Unit _targetUnit = null;

        public Message_TriggerStompedState(Unit targetUnit)
        {
            _targetUnit = targetUnit;
            mMessageType = MessageType.TRIGGER_STOMPEDSTATE;
        }

        public override void Register()
        {
            _targetUnit.messageHandler.Register(this);
        }
    }
}