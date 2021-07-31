using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ShakeCameraOnTargetMessage : BaseMessage
    {
        private uint _totalShakeFrames = 0;
        private float _shakeAmount = 0f;

        public ShakeCameraOnTargetMessage(uint totalShakeFrames, float shakeAmount)
        {
            _totalShakeFrames = totalShakeFrames;
            _shakeAmount = shakeAmount;
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

        public override float GetFloatMessage()
        {
            return _shakeAmount;
        }
    }
}