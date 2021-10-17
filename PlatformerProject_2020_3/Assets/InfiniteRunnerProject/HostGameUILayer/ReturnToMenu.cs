using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ReturnToMenu : UIOption
    {
        public override void OnEnterKey()
        {
            Debugger.Log("returning to menu");

            Return();
        }

        public static void Return()
        {
            BaseInitializer.CURRENT.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));

            if (RB.Server.ServerManager.CURRENT != null)
            {
                RB.Server.ServerManager.CURRENT.serverController.EndServer();
            }

            if (RB.Client.ClientManager.CURRENT != null)
            {
                RB.Client.ClientManager.CURRENT.EndClient();
            }
        }
    }
}