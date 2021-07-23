using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Wince_Message : BaseMessage
    {
        private Unit _receiverUnit = null;

        public Wince_Message(Unit receiverUnit)
        {
            _receiverUnit = receiverUnit;
            mMessageType = MessageType.WINCE;
        }

        public override void Register()
        {
            _receiverUnit.messageHandler.Register(this);
        }
    }
}