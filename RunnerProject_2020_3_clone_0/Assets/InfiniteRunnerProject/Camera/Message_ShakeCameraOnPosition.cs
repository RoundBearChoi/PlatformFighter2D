using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShakeCameraOnPosition : BaseMessage
    {
        private uint _totalShakeFrames = 0;

        public Message_ShakeCameraOnPosition(uint totalShakeFrames)
        {
            _totalShakeFrames = totalShakeFrames;
            mMessageType = MessageType.SHAKE_CAMERA_ONPOSITION;
        }

        public override void Register()
        {
            BaseInitializer.current.GetStage().cameraScript.messageHandler.Register(this);
        }

        public override uint GetUnsignedIntMessage()
        {
            return _totalShakeFrames;
        }
    }
}