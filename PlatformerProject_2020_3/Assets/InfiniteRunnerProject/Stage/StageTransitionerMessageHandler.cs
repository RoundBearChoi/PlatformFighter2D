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
                    GameInitializer.current.stageTransitioner.AddTransition(new ConnectedStageTransition(GameInitializer.current));

                    //string ip = message.GetStringMessage();
                    //Debugger.Log("host ip entered: " + ip);
                    //RB.Client.BaseClientControl.CURRENT.SetHostIP(ip);
                    //
                    //GameInitializer.current.stageTransitioner.AddTransition(new ConnectingStageTransition(GameInitializer.current));
                }
            }
        }
    }
}