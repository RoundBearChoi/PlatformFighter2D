using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraMessageHandler : BaseMessageHandler
    {
        private RunnerCam _runnerCam = null;
        
        public CameraMessageHandler(RunnerCam runnerCam)
        {
            _runnerCam = runnerCam;
        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.SHAKE_CAMERA)
                {
                    _runnerCam.mTotalShakeFrames += message.GetUnsignedIntMessage();
                }
            }
        }
    }
}