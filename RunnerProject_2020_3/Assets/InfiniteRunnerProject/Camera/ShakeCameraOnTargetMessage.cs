using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShakeCameraOnTargetMessage : BaseMessage
    {
        private uint _totalShakeFrames = 0;

        public ShakeCameraOnTargetMessage(uint totalShakeFrames)
        {
            _totalShakeFrames = totalShakeFrames;
            mMessageType = MessageType.SHAKE_CAMERA_ONTARGET;
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