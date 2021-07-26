using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShakeCameraOnPositionMessage : BaseMessage
    {
        private uint _totalShakeFrames = 0;

        public ShakeCameraOnPositionMessage(uint totalShakeFrames)
        {
            _totalShakeFrames = totalShakeFrames;
            mMessageType = MessageType.SHAKE_CAMERA_ONPOSITION;
        }

        public override void Register()
        {
            GameInitializer.current.GetStage().cameraScript.messageHandler.Register(this);
        }

        public override uint GetUnsignedIntMessage()
        {
            return _totalShakeFrames;
        }
    }
}