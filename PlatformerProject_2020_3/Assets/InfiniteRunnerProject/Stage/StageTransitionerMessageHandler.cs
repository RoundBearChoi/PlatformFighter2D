using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StageTransitionerMessageHandler : BaseMessageHandler
    {
        public StageTransitionerMessageHandler()
        {

        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.TRANSITION_TO_CONNECTED_STAGE)
                {
                    BaseInitializer.CURRENT.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.CONNECTED_STAGE));
                }
            }
        }
    }
}