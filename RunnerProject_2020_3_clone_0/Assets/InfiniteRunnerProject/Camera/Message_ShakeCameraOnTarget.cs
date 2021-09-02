using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShakeCameraOnTarget : BaseMessage
    {
        private uint _totalShakeFrames = 0;
        private float _shakeAmount = 0f;

        public Message_ShakeCameraOnTarget(uint totalShakeFrames, float shakeAmount)
        {
            _totalShakeFrames = totalShakeFrames;
            _shakeAmount = shakeAmount;
            mMessageType = MessageType.SHAKE_CAMERA_ONTARGET;
        }

        public override void Register()
        {
            BaseInitializer.current.GetStage().cameraScript.messageHandler.Register(this);
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