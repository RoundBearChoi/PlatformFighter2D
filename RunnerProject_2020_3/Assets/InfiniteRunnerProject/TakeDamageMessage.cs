using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TakeDamageMessage : BaseMessage
    {
        private Unit _targetUnit = null;
        private int _damageAmount = 0;

        public TakeDamageMessage(Unit targetUnit, int damageAmount)
        {
            _targetUnit = targetUnit;
            _damageAmount = damageAmount;
            mMessageType = MessageType.TAKE_DAMAGE;
        }

        public override void Register()
        {
            _targetUnit.unitMessageHandler.RegisterMessage(this);
        }

        public override int GetIntMessage()
        {
            return _damageAmount;
        }
    }
}