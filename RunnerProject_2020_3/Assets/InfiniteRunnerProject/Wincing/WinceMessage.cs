using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class WinceMessage : BaseMessage
    {
        private Unit _receiverUnit = null;

        public WinceMessage(Unit receiverUnit)
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