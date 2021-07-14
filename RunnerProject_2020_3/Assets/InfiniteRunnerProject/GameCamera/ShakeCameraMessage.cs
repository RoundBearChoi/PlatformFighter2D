using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShakeCameraMessage : BaseMessage
    {
        private uint _totalShakeFrames = 0;

        public ShakeCameraMessage(uint totalShakeFrames)
        {
            _totalShakeFrames = totalShakeFrames;
            mMessageType = MessageType.SHAKE_CAMERA;
        }

        public override void Register()
        {
            GameCameraController.current.unitMessageHandler.RegisterMessage(this);
        }

        public override uint GetUnsignedIntMessage()
        {
            return _totalShakeFrames;
        }
    }
}