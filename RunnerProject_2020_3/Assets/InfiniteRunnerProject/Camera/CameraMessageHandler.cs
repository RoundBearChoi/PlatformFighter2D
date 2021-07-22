using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraMessageHandler : BaseMessageHandler
    {
        public CameraMessageHandler()
        {

        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.SHAKE_CAMERA_ONTARGET)
                {
                    CameraScript.current.SetCameraState(new Camera_Shake_OnTarget(message.GetUnsignedIntMessage()));
                }
                else if (message.MESSAGE_TYPE == MessageType.SHAKE_CAMERA_ONPOSITION)
                {
                    CameraScript.current.SetCameraState(new Camera_Shake_OnPosition(message.GetUnsignedIntMessage()));
                }
            }
        }
    }
}