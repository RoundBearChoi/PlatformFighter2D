using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Wince_Message : BaseMessage
    {
        private Unit _receiverUnit = null;
        private Unit _attacker = null;

        public Wince_Message(Unit receiverUnit, Unit attacker)
        {
            _receiverUnit = receiverUnit;
            _attacker = attacker;
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
    }
}