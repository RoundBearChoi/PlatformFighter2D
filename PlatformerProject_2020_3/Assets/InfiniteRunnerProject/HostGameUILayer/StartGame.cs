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

            RB.Server.ServerManager.CURRENT.serverSend.EnterMultiplayerStage();

            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.MULTIPLAYER_SERVER_STAGE));
        }
    }
}