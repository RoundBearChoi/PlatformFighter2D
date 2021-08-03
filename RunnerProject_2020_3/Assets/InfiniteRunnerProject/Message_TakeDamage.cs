using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_TakeDamage : BaseMessage
    {
        private Unit _targetUnit = null;
        private uint _damageAmount = 0;

        public Message_TakeDamage(Unit targetUnit, uint damageAmount)
        {
            _targetUnit = targetUnit;
            _damageAmount = damageAmount;
            mMessageType = MessageType.TAKE_DAMAGE;
        }

        public override void Register()
        {
            _targetUnit.messageHandler.Register(this);
        }

        public override uint GetUnsignedIntMessage()
        {
            return _damageAmount;
        }
    }
}