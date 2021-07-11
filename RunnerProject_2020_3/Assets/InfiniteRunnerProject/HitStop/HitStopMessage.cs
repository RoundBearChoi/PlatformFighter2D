using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HitStopMessage : BaseMessage
    {
        uint _totalHitStopFrames = 0;

        public HitStopMessage(uint totalHitStopFrames, MessageType messageType)
        {
            _totalHitStopFrames = totalHitStopFrames;
            mMessageType = messageType;
        }

        public override void Register()
        {
            Stage.currentStage.units.listMessages.Add(this);
        }

        public override uint GetUnsignedIntMessage()
        {
            return _totalHitStopFrames;
        }
    }
}