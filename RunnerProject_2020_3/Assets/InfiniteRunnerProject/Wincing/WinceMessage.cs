using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class WinceMessage : BaseMessage
    {
        private Unit _receiverUnit = null;

        public WinceMessage(Unit receiverUnit, MessageType messageType)
        {
            _receiverUnit = receiverUnit;
            mMessageType = messageType;
        }

        public override void Register()
        {

        }
    }
}