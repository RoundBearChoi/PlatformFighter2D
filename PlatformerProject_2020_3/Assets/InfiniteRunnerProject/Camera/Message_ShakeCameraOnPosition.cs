using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Message_ShakeCameraOnPosition : BaseMessage
    {
        private CameraScript _cameraScript = null;
        private uint _totalShakeFrames = 0;
        private float _shakeAmount = 0f;

        public Message_ShakeCameraOnPosition(CameraScript cameraScript, uint totalShakeFrames, float shakeAmount)
        {
            _cameraScript = cameraScript;

            _totalShakeFrames = totalShakeFrames;
            _shakeAmount = shakeAmount;
            mMessageType = MessageType.SHAKE_CAMERA_ONPOSITION;
        }

        public override void Register()
        {
            _cameraScript.messageHandler.Register(this);
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