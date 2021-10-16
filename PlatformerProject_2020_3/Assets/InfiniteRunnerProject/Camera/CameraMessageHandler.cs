using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraMessageHandler : BaseMessageHandler
    {
        CameraScript _cameraScript = null;

        public CameraMessageHandler(CameraScript cameraScript)
        {
            _cameraScript = cameraScript;
        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.SHAKE_CAMERA_ONTARGET)
                {
                    _cameraScript.SetCameraState(new Camera_Shake_OnTarget(_cameraScript, message.GetUnsignedIntMessage(), message.GetFloatMessage()), false);
                }
                else if (message.MESSAGE_TYPE == MessageType.SHAKE_CAMERA_ONPOSITION)
                {
                    _cameraScript.SetCameraState(new Camera_Shake_OnPosition(_cameraScript, message.GetUnsignedIntMessage(), message.GetFloatMessage()), false);
                }
            }
        }
    }
}