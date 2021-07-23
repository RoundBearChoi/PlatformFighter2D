using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ZeroHealth_Message : BaseMessage
    {
        private Unit _targetUnit = null;

        public ZeroHealth_Message(Unit targetUnit)
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