using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BloodMessage : BaseMessage
    {
        bool _faceRightSide = true;
        
        public BloodMessage(bool faceRightSide)
        {
            _faceRightSide = faceRightSide;
            mMessageType = MessageType.NONE;
        }

        public override void Register()
        {
            Stage.currentStage.units.unitsMessageHandler.RegisterMessage(this);
        }

        public override bool GetBoolMessage()
        {
            return _faceRightSide;
        }
    }
}