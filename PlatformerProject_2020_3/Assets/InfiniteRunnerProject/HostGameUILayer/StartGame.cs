using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StartGame : UIOption
    {
        public override void OnEnterKey()
        {
            Debugger.Log("starting multiplayer game");

            RB.Server.BaseNetworkControl.CURRENT.serverSend.EnterMultiplayerStage();

            GameInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.MULTIPLAYER_SERVER_STAGE, GameInitializer.current));
        }
    }
}