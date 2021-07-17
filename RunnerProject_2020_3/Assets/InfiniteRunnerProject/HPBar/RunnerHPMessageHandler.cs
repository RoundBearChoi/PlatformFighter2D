using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerHPMessageHandler : BaseMessageHandler
    {
        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.UPDATE_RUNNER_HP_UI)
                {

                }
            }
        }
    }
}