using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;
        private uint _totalShakeFrames = 0;
        
        public CameraMessageHandler(Unit unit)
        {
            _unit = unit;
        }

        public override void HandleMessages()
        {
            if (_totalShakeFrames > 0)
            {
                _totalShakeFrames--;
            }
            else
            {

            }

            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.SHAKE_CAMERA)
                {
                    _totalShakeFrames = message.GetUnsignedIntMessage();
                }
            }
        }
    }
}