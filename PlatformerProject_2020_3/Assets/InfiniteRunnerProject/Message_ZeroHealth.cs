using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ZeroHealth : BaseMessage
    {
        private Unit _targetUnit = null;

        public Message_ZeroHealth(Unit targetUnit)
        {
            _targetUnit = targetUnit;
            mMessageType = MessageType.ZERO_HEALTH;
        }

        public override void Register()
        {
            if (_targetUnit.messageHandler != null)
            {
                _targetUnit.messageHandler.Register(this);
            }
        }
    }
}