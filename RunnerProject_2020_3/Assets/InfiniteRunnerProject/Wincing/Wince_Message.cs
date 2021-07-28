using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Wince_Message : BaseMessage
    {
        private Unit _receiverUnit = null;
        private Unit _attacker = null;
        private Vector2 _pushForce = Vector2.zero;

        public Wince_Message(Unit receiverUnit, Vector2 pushForce, Unit attacker)
        {
            _receiverUnit = receiverUnit;
            _attacker = attacker;
            _pushForce = pushForce;
            mMessageType = MessageType.WINCE;
        }

        public override void Register()
        {
            _receiverUnit.messageHandler.Register(this);
        }

        public override Unit GetUnitMessage()
        {
            return _attacker;
        }

        public override Vector2 GetVector2Message()
        {
            return _pushForce;
        }
    }
}